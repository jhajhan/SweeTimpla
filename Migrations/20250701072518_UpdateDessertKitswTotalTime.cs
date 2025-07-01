using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DIYFilipinoDessert.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDessertKitswTotalTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TotalTime",
                table: "DessertKits",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "DessertKits");
        }
    }
}
