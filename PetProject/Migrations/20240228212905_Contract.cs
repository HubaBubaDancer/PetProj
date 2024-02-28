using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Migrations
{
    /// <inheritdoc />
    public partial class Contract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cars",
                table: "Clients",
                newName: "Contracts");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Cars",
                newName: "Contract");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contracts",
                table: "Clients",
                newName: "Cars");

            migrationBuilder.RenameColumn(
                name: "Contract",
                table: "Cars",
                newName: "ClientId");
        }
    }
}
