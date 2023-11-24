using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaturalFlowersBlazor.Data.Migrations
{
    public partial class InProgressBoolForOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInProgress",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInProgress",
                table: "Order");
        }
    }
}
