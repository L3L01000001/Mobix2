using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobix.Migrations
{
    public partial class dataseed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "edf19910-e7ec-43ff-af93-3db11fa63e6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "302fb168-af8f-47f4-93cc-ec9abc9acb53");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d3919b31-b16b-4cfe-8a86-140b442374cf", "AQAAAAEAACcQAAAAEOPCr3CY1mwslKd3BtLs6P+JPZuyRpnxKtXoKjoNEncmD9xfqMJ9yLnZvbiY7siG8A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "35b7703e-ec9b-41e7-ab2a-3a36a377744a", "AQAAAAEAACcQAAAAEJvnPptXGC0QXJ4STVtnzxE1qNJpcwnk/ILo28yp3IgpBgUmEfE0DlCvDCThyfw9Xw==" });
        }
    }
}
