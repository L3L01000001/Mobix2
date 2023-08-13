using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobix.Migrations
{
    public partial class PorukeZaAdmina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PorukeZaAdmina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PorukeZaAdmina", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "104a3515-1ce0-45b1-aa80-ddce83be9cc0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f7b5022f-8987-4b71-a66f-399ea626f8ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a5deb19c-9bb6-4b9e-9b5b-9010b06b8e11", "AQAAAAEAACcQAAAAEB6r73uHjvBp5eyvImqLfvhkAbF3FrRWl4U9rKe2n3Z5XMY2MX6JschAH215rNtcNQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4fc2ac6b-d27c-4680-ab77-aa77b83d9a79", "AQAAAAEAACcQAAAAEIgQ+1Zcm/ed7tui8y9LNq2L3stBOGGknBHMw2NcpvPiti8iJLK6aa2wBb//pe4IIw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PorukeZaAdmina");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "40a2c1a4-bdfe-40ec-abf2-bbabbf94e2ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "be1221a0-d180-4c60-a4f0-45a6e2bf137f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8b2bae7-ab82-44ee-8d53-4545868becb9", "AQAAAAEAACcQAAAAEJg1hRnnepEoCg1X7DrU95njx898hO78n1QTk24DoMSsT65PTlGQZjDKml2XM6JAfw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5e95f84-0450-4594-b716-314613fce0e6", "AQAAAAEAACcQAAAAEHYwqABZ07K0B2RX9MCd7jrZvd2DmunFPxaXiPn2Sy280vRTaz6e1kIOKeorgGDJ9w==" });
        }
    }
}
