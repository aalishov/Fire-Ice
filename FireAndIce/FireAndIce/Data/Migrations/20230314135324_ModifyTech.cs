using Microsoft.EntityFrameworkCore.Migrations;

namespace FireAndIce.Data.Migrations
{
    public partial class ModifyTech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Tech",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Tech");
        }
    }
}
