using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KlinikAPI.Migrations
{
    public partial class updatePropertyUpdateDateAndBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "updated_by",
                table: "tProfinsi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_date",
                table: "tProfinsi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "tProfinsi");

            migrationBuilder.DropColumn(
                name: "updated_date",
                table: "tProfinsi");
        }
    }
}
