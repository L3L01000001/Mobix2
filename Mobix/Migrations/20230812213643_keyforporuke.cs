using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobix.Migrations
{
    public partial class keyforporuke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "fd4e0c5c-12d6-4ddd-819a-a83a4ce38052");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0d9efd98-aa34-4d04-b23c-e808fea167e1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7c297a35-77af-46ec-b2a9-9a09e090f8ab", "AQAAAAEAACcQAAAAEBeQriGX1FSxwyN76JxDCMtOT4O/Ip52Gx601/l70ITA7i4VX4ko9insWsVXQw0cIQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "52b6eb2a-3fad-4c89-ad5d-ee9cca4736e6", "AQAAAAEAACcQAAAAENgG8W90ORf4CMI2F1OEcd4WaAbTxJjFsZrVkpswbGtBxoQ9GAXFphnEDdBPyV/brg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
