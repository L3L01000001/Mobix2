using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Mobix.Data;
using Microsoft.AspNetCore.Identity;
using Mobix.EntityModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentEmail;
using FluentEmail.Mailgun;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Mobix.JwtFeatures;
using System.Data;
using SignalR.Hubs;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;
using Mobix.EmailServis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddDbContext<MobixDbContext>(options =>
options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<Korisnik, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = true;
    options.SignIn.RequireConfirmedEmail = true;
})
                .AddEntityFrameworkStores<MobixDbContext>()
                .AddDefaultTokenProviders();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "Mobix", // Replace with your JWT issuer
        ValidAudience = "https://localhost:4200", // Replace with your JWT audience
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(jwtSettings.GetSection("securityKey").Value))
    };
    //options.Events = new JwtBearerEvents
    //{
    //    OnMessageReceived = context =>
    //    {
    //        var accessToken = context.Request.Query["access_token"];

    //        // If the request is for our hub...
    //        var path = context.HttpContext.Request.Path;
    //        if (!string.IsNullOrEmpty(accessToken) &&
    //            (path.StartsWithSegments("/Hubs/contactHub")))
    //        {
    //            // Read the token out of the query string
    //            context.Token = accessToken;
    //        }
    //        return Task.CompletedTask;
    //    }
    //};
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = new TimeSpan(0, 1, 0);
});

builder.Services.AddScoped<JwtHandler>();
builder.Services.AddScoped<EmailService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("https://localhost:44351", "https://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();

        });
    options.AddPolicy("AllowAnyOriginPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddSignalR();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseCors(builder =>
{
    builder
    .WithOrigins("https://localhost:44351", "https://localhost:4200", "http://localhost:7278", "http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseStaticFiles();


app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();
app.MapHub<ContactHub>("/contactHub");

app.MapControllers();

app.Run();
