using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mobix.EntityModels;
using MobixWebShop.EntityModels;
using System.Reflection.Emit;

namespace Mobix.Data
{
    public class MobixDbContext : IdentityDbContext<Korisnik>
    {
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Dobavljac> Dobavljaci { get; set; }
        public DbSet<Korpa> Korpa { get; set; }
        public DbSet<KorpaStavke> KorpaStavke { get; set; }
        public MobixDbContext(DbContextOptions<MobixDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<Korisnik>();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2", Name = "Korisnik", NormalizedName = "KORISNIK" });


            modelBuilder.Entity<Korisnik>().HasData(new Korisnik
            {
                Id = "1",
                Ime = "Admin",
                UserName = "admin@mobix.com",
                NormalizedUserName = "admin@mobix.com".ToUpper(),
                Email = "admin@mobix.com",
                NormalizedEmail = "admin@mobix.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Test123."),
                SecurityStamp = string.Empty,
                Prezime = "Admin"
            });

            modelBuilder.Entity<Korisnik>().HasData(new Korisnik
            {
                Id = "2",
                Ime = "Korisnik",
                UserName = "korisnik@mobix.com",
                NormalizedUserName = "korisnik@mobix.com".ToUpper(),
                Email = "korisnik@mobix.com",
                NormalizedEmail = "korisnik@mobix.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Test123."),
                SecurityStamp = string.Empty,
                Prezime = "Korisnik"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = "1", RoleId = "1" });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = "2", RoleId = "2" });

            modelBuilder.Entity<Dobavljac>().HasData(new Dobavljac()
            {
                DobavljacID = 1,
                Adresa = "Dr Ante Starcevica 51, Mostar",
                BrojTelefona = "065111111",
                Naziv = "Najbolji Dobavljac1"
            });

            modelBuilder.Entity<Dobavljac>().HasData(new Dobavljac()
            {
                DobavljacID = 2,
                Adresa = "Dr Ante Starcevica 52, Mostar",
                BrojTelefona = "062111111",
                Naziv = "Najbolji Dobavljac2"
            });

            modelBuilder.Entity<Proizvod>().HasData(new Proizvod()
            {
                ProizvodID = 1,
                Cijena = 700,
                Naziv = "iPhone 11",
                Kolicina = 1,
                DobavljacProizvodaID = 2,
                Opis = "Apple iPhone 11 GREEN \r\n-Memorija 128 GB\r\n-Mobitel je kao nov (stanje 10/10)\r\n-Svi dijelovi originalni, ništa mijenjano \r\n-Face id i True tone rade \r\n-Apsolutno sve ispravno i otključano\r\n-Fabrička kutija, originalne Apple slušalice, kabal za punjenje, zaštitno staklo, papiri",
                Stanje = "Polovno",
                SlikaProizvoda = "https://pcmarket.ba/wp-content/uploads/2021/09/Apple-iPhone-11-64GB-Green..jpg"
            });


            base.OnModelCreating(modelBuilder);
        }
    }
    }
