using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaturalFlowersBlazor.Data.Migrations
{
    public partial class StripeIdOnItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StripeId",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StripeId",
                table: "Item");
        }
    }
}
