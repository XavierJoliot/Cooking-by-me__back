using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingByMe_back.Core.Migrations
{
    public partial class UpdateRecipeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsPublic",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Recipe");
        }
    }
}
