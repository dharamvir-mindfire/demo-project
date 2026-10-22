using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "newSchema");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Persons",
                newSchema: "newSchema");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "newSchema");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "newSchema");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "newSchema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Persons",
                schema: "newSchema",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "newSchema",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "newSchema",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "newSchema",
                newName: "AspNetRoles");
        }
    }
}
