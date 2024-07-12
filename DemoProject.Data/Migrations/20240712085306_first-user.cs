using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7de6b658-4034-4dd8-9480-bb985e5j778e", 0, "1976680f-ce99-4794-b0ab-90041b5d78ac", "dharamvir1@mindfiresolutions.com", false, "Dharamvir", false, null, null, null, "$2a$04$KA8l.hSjqUQ.lrB/29m.TOaIanvVyydGHsYrqaqOMamxDhL9aS9S6", null, false, "bf194ceb-3d24-4a2a-943c-196729cd75d0", false, "dharamvir1@mindfiresolutions.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7de6b658-4034-4dd8-9480-bb985e5j778e");
        }
    }
}
