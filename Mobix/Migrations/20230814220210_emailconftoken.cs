using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobix.Migrations
{
    public partial class emailconftoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailVerificationToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "84fd883b-90f7-46ad-b847-3199904ad2a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ffa0d82f-2bf7-4a5e-ac6e-f592d96e285d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c08ca568-e0c0-4693-aa08-1b57a3fea7af", "AQAAAAEAACcQAAAAEINeyF+3Vjl8ZWN98F/kSJWLcWBVNLfi0PghrOPvZ9egkCIRinMg/ahg5bjOLOSMHg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6bf80d37-6856-4175-afc2-c6ea39da7a69", "AQAAAAEAACcQAAAAEK7O3y0FoAFM8xZUfV5tOcbs6FbhGvj7ADHK/mNTaXBDCBZowxhvJCVkskIe6NQtoQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailVerificationToken",
                table: "AspNetUsers");

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
    }
}
