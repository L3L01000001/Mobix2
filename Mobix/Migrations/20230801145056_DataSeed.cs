using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobix.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "edf19910-e7ec-43ff-af93-3db11fa63e6e", "Admin", "ADMIN" },
                    { "2", "302fb168-af8f-47f4-93cc-ec9abc9acb53", "Korisnik", "KORISNIK" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[,]
                {
                    { "1", 0, "d3919b31-b16b-4cfe-8a86-140b442374cf", "admin@mobix.com", true, "Admin", false, null, "ADMIN@MOBIX.COM", "ADMIN@MOBIX.COM", "AQAAAAEAACcQAAAAEOPCr3CY1mwslKd3BtLs6P+JPZuyRpnxKtXoKjoNEncmD9xfqMJ9yLnZvbiY7siG8A==", null, false, "Admin", "", false, "admin@mobix.com", null },
                    { "2", 0, "35b7703e-ec9b-41e7-ab2a-3a36a377744a", "korisnik@mobix.com", true, "Korisnik", false, null, "KORISNIK@MOBIX.COM", "KORISNIK@MOBIX.COM", "AQAAAAEAACcQAAAAEJvnPptXGC0QXJ4STVtnzxE1qNJpcwnk/ILo28yp3IgpBgUmEfE0DlCvDCThyfw9Xw==", null, false, "Korisnik", "", false, "korisnik@mobix.com", null }
                });

            migrationBuilder.InsertData(
                table: "Dobavljaci",
                columns: new[] { "DobavljacID", "Adresa", "BrojTelefona", "Naziv" },
                values: new object[,]
                {
                    { 1, "Dr Ante Starcevica 51, Mostar", "065111111", "Najbolji Dobavljac1" },
                    { 2, "Dr Ante Starcevica 52, Mostar", "062111111", "Najbolji Dobavljac2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "2" });

            migrationBuilder.InsertData(
                table: "Proizvodi",
                columns: new[] { "ProizvodID", "Cijena", "DobavljacProizvodaID", "Kolicina", "Naziv", "Opis", "SlikaProizvoda", "Stanje" },
                values: new object[] { 1, 700, 2, 1, "iPhone 11", "Apple iPhone 11 GREEN \r\n-Memorija 128 GB\r\n-Mobitel je kao nov (stanje 10/10)\r\n-Svi dijelovi originalni, ništa mijenjano \r\n-Face id i True tone rade \r\n-Apsolutno sve ispravno i otključano\r\n-Fabrička kutija, originalne Apple slušalice, kabal za punjenje, zaštitno staklo, papiri", "https://pcmarket.ba/wp-content/uploads/2021/09/Apple-iPhone-11-64GB-Green..jpg", "Polovno" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "Dobavljaci",
                keyColumn: "DobavljacID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "ProizvodID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Dobavljaci",
                keyColumn: "DobavljacID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "AspNetUsers");
        }
    }
}
