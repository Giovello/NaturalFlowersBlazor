using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaturalFlowersBlazor.Data.Migrations
{
    public partial class itemScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "score",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "score",
                table: "Item");
        }
    }
}
