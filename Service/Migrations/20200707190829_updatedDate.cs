using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class updatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qantity",
                table: "Rows");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                table: "Rows",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Rows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                table: "Carts",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Rows");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Rows");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "Qantity",
                table: "Rows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
