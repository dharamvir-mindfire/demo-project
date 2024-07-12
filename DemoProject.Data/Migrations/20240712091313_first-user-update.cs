using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstuserupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7de6b658-4034-4dd8-9480-bb985e5j778e",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53229ab9-96fc-427a-bec7-9d44aa8f4d96", "DHARAMVIR1@MINDFIRESOLUTIONS.COM", "AQAAAAIAAYagAAAAEPIlhGUuGfhxth2NFR4AAyxAAMI7NnQ2rHjEJg1mlpOpscZD1fgdYGoOYGSj8Oqq/Q==", "59a316c9-8876-48fd-9010-2f96ffda1c71" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7de6b658-4034-4dd8-9480-bb985e5j778e",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1976680f-ce99-4794-b0ab-90041b5d78ac", null, "$2a$04$KA8l.hSjqUQ.lrB/29m.TOaIanvVyydGHsYrqaqOMamxDhL9aS9S6", "bf194ceb-3d24-4a2a-943c-196729cd75d0" });
        }
    }
}
