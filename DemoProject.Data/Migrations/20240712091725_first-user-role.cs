using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstuserrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7e51f693-ff34-49fe-a998-d53192b40e51", "7de6b658-4034-4dd8-9480-bb985e5j778e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7de6b658-4034-4dd8-9480-bb985e5j778e",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e982d101-c025-466a-a809-ecb8af704037", "b3501338-735b-4a77-9785-7d684ea6f922" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7e51f693-ff34-49fe-a998-d53192b40e51", "7de6b658-4034-4dd8-9480-bb985e5j778e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7de6b658-4034-4dd8-9480-bb985e5j778e",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "53229ab9-96fc-427a-bec7-9d44aa8f4d96", "59a316c9-8876-48fd-9010-2f96ffda1c71" });
        }
    }
}
