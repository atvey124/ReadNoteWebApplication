using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReadNoteWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c17143a-4d1a-4e47-be77-d5edddb2e9f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6bfe573-982d-412d-af8c-7616856257fa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4012f654-fbde-440b-a967-e2899cec4f49", null, "Admin", "ADMIN" },
                    { "41bd38cc-0568-401c-b9d8-078257cd6840", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4012f654-fbde-440b-a967-e2899cec4f49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41bd38cc-0568-401c-b9d8-078257cd6840");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c17143a-4d1a-4e47-be77-d5edddb2e9f6", null, "Admin", "ADMIN" },
                    { "d6bfe573-982d-412d-af8c-7616856257fa", null, "User", "USER" }
                });
        }
    }
}
