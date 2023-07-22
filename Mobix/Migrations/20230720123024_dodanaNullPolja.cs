using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobix.Migrations
{
    public partial class dodanaNullPolja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorpaStavke_Korpa_KorpaId",
                table: "KorpaStavke");

            migrationBuilder.DropForeignKey(
                name: "FK_KorpaStavke_Proizvodi_ProizvodID",
                table: "KorpaStavke");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodi_Dobavljaci_DobavljacProizvodaID",
                table: "Proizvodi");

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

            migrationBuilder.AlterColumn<string>(
                name: "Stanje",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SlikaProizvoda",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Kolicina",
                table: "Proizvodi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DobavljacProizvodaID",
                table: "Proizvodi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Cijena",
                table: "Proizvodi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProizvodID",
                table: "KorpaStavke",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KorpaId",
                table: "KorpaStavke",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Kolicina",
                table: "KorpaStavke",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Korpa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Dobavljaci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BrojTelefona",
                table: "Dobavljaci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adresa",
                table: "Dobavljaci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_KorpaStavke_Korpa_KorpaId",
                table: "KorpaStavke",
                column: "KorpaId",
                principalTable: "Korpa",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KorpaStavke_Proizvodi_ProizvodID",
                table: "KorpaStavke",
                column: "ProizvodID",
                principalTable: "Proizvodi",
                principalColumn: "ProizvodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodi_Dobavljaci_DobavljacProizvodaID",
                table: "Proizvodi",
                column: "DobavljacProizvodaID",
                principalTable: "Dobavljaci",
                principalColumn: "DobavljacID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorpaStavke_Korpa_KorpaId",
                table: "KorpaStavke");

            migrationBuilder.DropForeignKey(
                name: "FK_KorpaStavke_Proizvodi_ProizvodID",
                table: "KorpaStavke");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodi_Dobavljaci_DobavljacProizvodaID",
                table: "Proizvodi");

            migrationBuilder.AlterColumn<string>(
                name: "Stanje",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SlikaProizvoda",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kolicina",
                table: "Proizvodi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DobavljacProizvodaID",
                table: "Proizvodi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cijena",
                table: "Proizvodi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProizvodID",
                table: "KorpaStavke",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KorpaId",
                table: "KorpaStavke",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kolicina",
                table: "KorpaStavke",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Korpa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Dobavljaci",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrojTelefona",
                table: "Dobavljaci",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adresa",
                table: "Dobavljaci",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "555346cf-2ab7-4405-bad7-423adab7c7c6", "Admin", "ADMIN" },
                    { "2", "7a6ace2e-440d-44e5-ae36-1a5816ab74b8", "Korisnik", "KORISNIK" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "14dc27ce-c45b-431b-b821-49c913c639a5", "admin@mobix.com", true, "Admin", false, null, "ADMIN@MOBIX.COM", "ADMIN@MOBIX.COM", "AQAAAAEAACcQAAAAEA+t6A9Ynpjmrt77NsfufGRCEDVkveFAQtwQgX1BQWfUwkyRPziwqupC7S0jZj7tFA==", null, false, "Admin", "", false, "admin@mobix.com" },
                    { "2", 0, "a6de2246-1fe1-4881-94ec-8870ff44d227", "korisnik@mobix.com", true, "Korisnik", false, null, "KORISNIK@MOBIX.COM", "KORISNIK@MOBIX.COM", "AQAAAAEAACcQAAAAECX98XHmcB9UPIg74UlXhw7E0DTs9IEN2EwqQs0nZRQ/vvfuTrKfRWtyhY4uIxoFvQ==", null, false, "Korisnik", "", false, "korisnik@mobix.com" }
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

            migrationBuilder.AddForeignKey(
                name: "FK_KorpaStavke_Korpa_KorpaId",
                table: "KorpaStavke",
                column: "KorpaId",
                principalTable: "Korpa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KorpaStavke_Proizvodi_ProizvodID",
                table: "KorpaStavke",
                column: "ProizvodID",
                principalTable: "Proizvodi",
                principalColumn: "ProizvodID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodi_Dobavljaci_DobavljacProizvodaID",
                table: "Proizvodi",
                column: "DobavljacProizvodaID",
                principalTable: "Dobavljaci",
                principalColumn: "DobavljacID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
