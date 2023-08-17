using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobix.Migrations
{
    public partial class role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserRole" },
                values: new object[] { "dff8e60f-33d1-43d5-af5c-87cb970a7c2e", "AQAAAAEAACcQAAAAENbLLXLqE6CjPR4PwNMBKliUD8n3pnqrSwFkjEHd73p4O2rNZPc0UXJXB/V8qkGDEw==", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserRole" },
                values: new object[] { "7a64b955-abfa-4e84-9609-fe1bbe5ffc49", "AQAAAAEAACcQAAAAEANtTqNGVCnU7scqLyhXDAZzXHHpYhfOQX1ww3sAvX7KUS2Ot4eCmT4U0LZVBvOF3A==", "Korisnik" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserRole" },
                values: new object[] { "c08ca568-e0c0-4693-aa08-1b57a3fea7af", "AQAAAAEAACcQAAAAEINeyF+3Vjl8ZWN98F/kSJWLcWBVNLfi0PghrOPvZ9egkCIRinMg/ahg5bjOLOSMHg==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserRole" },
                values: new object[] { "6bf80d37-6856-4175-afc2-c6ea39da7a69", "AQAAAAEAACcQAAAAEK7O3y0FoAFM8xZUfV5tOcbs6FbhGvj7ADHK/mNTaXBDCBZowxhvJCVkskIe6NQtoQ==", null });
        }
    }
}
