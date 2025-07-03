using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DIYFilipinoDessert.Migrations
{
    /// <inheritdoc />
    public partial class DropRecipeStepsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_DessertKits_DessertKitId",
                table: "RecipeSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeSteps",
                table: "RecipeSteps");

            migrationBuilder.RenameTable(
                name: "RecipeSteps",
                newName: "Recipe");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeSteps_DessertKitId",
                table: "Recipe",
                newName: "IX_Recipe_DessertKitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_DessertKits_DessertKitId",
                table: "Recipe",
                column: "DessertKitId",
                principalTable: "DessertKits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_DessertKits_DessertKitId",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "RecipeSteps");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_DessertKitId",
                table: "RecipeSteps",
                newName: "IX_RecipeSteps_DessertKitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeSteps",
                table: "RecipeSteps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_DessertKits_DessertKitId",
                table: "RecipeSteps",
                column: "DessertKitId",
                principalTable: "DessertKits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
