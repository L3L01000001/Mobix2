using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobix.Migrations
{
    public partial class korisnikIdFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korpa_AspNetUsers_KorisnikId1",
                table: "Korpa");

            migrationBuilder.DropIndex(
                name: "IX_Korpa_KorisnikId1",
                table: "Korpa");

            migrationBuilder.DropColumn(
                name: "KorisnikId1",
                table: "Korpa");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId",
                table: "Korpa",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3b2f2d21-b37d-4dfa-907c-7af28e506e3b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f616c600-136f-4cd5-97ac-61095f36f93f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "295f885e-4124-4748-9c62-d350f3fec3e3", "AQAAAAEAACcQAAAAEJXqNv3w2pgnwQi/c0vHDr8BFCtfEIeXVXlrBjqnvRbclxMXteee3GfN1Ir07Xr1HA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b22a8c5-e01e-4f66-adde-6793abb09021", "AQAAAAEAACcQAAAAEKbhSEA+vZ3nsfLxE8u13nxvWExUTqIzaw+qkv6dF+/UWcQpuaVcaoPJudc8bvGRHw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_KorisnikId",
                table: "Korpa",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korpa_AspNetUsers_KorisnikId",
                table: "Korpa",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korpa_AspNetUsers_KorisnikId",
                table: "Korpa");

            migrationBuilder.DropIndex(
                name: "IX_Korpa_KorisnikId",
                table: "Korpa");

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Korpa",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KorisnikId1",
                table: "Korpa",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_KorisnikId1",
                table: "Korpa",
                column: "KorisnikId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Korpa_AspNetUsers_KorisnikId1",
                table: "Korpa",
                column: "KorisnikId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
