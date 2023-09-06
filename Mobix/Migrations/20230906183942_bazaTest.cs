using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobix.Migrations
{
    public partial class bazaTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "66a60d81-7507-441a-bcbb-3227cfd44ab8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8f37605f-2e73-4a9c-91f1-0471bff81473");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0179038a-cace-4fef-836d-87fe1fb3bad7", "AQAAAAEAACcQAAAAEIfD6b19qVlbSP7qNtoBo0i4eeZoLW7IBnv5AN09Z33pHUoDx+TfCY5/tq908JQT5Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d8348a7-8b95-4fb2-9ab0-15301b8cf363", "AQAAAAEAACcQAAAAEAltpIl+9QDwy4LThT3q1RBRDE7ewTWERwPzNGqRoE1BTSkwSfKMwBcclMIKN4/RIQ==" });

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "ProizvodID",
                keyValue: 1,
                column: "SlikaProizvoda",
                value: "595d98ff-849c-4c13-a341-5ccb384e9f0f.jpg");

            migrationBuilder.InsertData(
                table: "Proizvodi",
                columns: new[] { "ProizvodID", "Cijena", "DobavljacProizvodaID", "Kolicina", "Naziv", "Opis", "SlikaProizvoda", "Stanje" },
                values: new object[] { 2, 1500, 2, 2, "iPhone 12 Pro", "Novi telefon full pakovanje", "595d98ff-849c-4c13-a341-5ccb384e9f0f.jpg", "Novo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "ProizvodID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1b2a7b32-2fe3-4f8d-9648-d3da930c05c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e1ae5aba-1c12-4025-93ae-851481756394");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dff8e60f-33d1-43d5-af5c-87cb970a7c2e", "AQAAAAEAACcQAAAAENbLLXLqE6CjPR4PwNMBKliUD8n3pnqrSwFkjEHd73p4O2rNZPc0UXJXB/V8qkGDEw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a64b955-abfa-4e84-9609-fe1bbe5ffc49", "AQAAAAEAACcQAAAAEANtTqNGVCnU7scqLyhXDAZzXHHpYhfOQX1ww3sAvX7KUS2Ot4eCmT4U0LZVBvOF3A==" });

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "ProizvodID",
                keyValue: 1,
                column: "SlikaProizvoda",
                value: "https://pcmarket.ba/wp-content/uploads/2021/09/Apple-iPhone-11-64GB-Green..jpg");
        }
    }
}
