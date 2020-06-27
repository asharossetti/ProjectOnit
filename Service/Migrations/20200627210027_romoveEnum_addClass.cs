using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class romoveEnum_addClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "StokPosition",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Carts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StokPositionId",
                table: "Carts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StokPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokPositions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_LocationId",
                table: "Carts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_StokPositionId",
                table: "Carts",
                column: "StokPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Locations_LocationId",
                table: "Carts",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_StokPositions_StokPositionId",
                table: "Carts",
                column: "StokPositionId",
                principalTable: "StokPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Locations_LocationId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_StokPositions_StokPositionId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "StokPositions");

            migrationBuilder.DropIndex(
                name: "IX_Carts_LocationId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_StokPositionId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "StokPositionId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StokPosition",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
