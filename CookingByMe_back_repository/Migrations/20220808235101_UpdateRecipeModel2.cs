using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingByMe_back.Core.Migrations
{
    public partial class UpdateRecipeModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPublic",
                table: "Recipe",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsPublic",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
