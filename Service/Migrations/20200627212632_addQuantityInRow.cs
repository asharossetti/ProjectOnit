using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class addQuantityInRow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qantity",
                table: "Rows",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qantity",
                table: "Rows");
        }
    }
}
