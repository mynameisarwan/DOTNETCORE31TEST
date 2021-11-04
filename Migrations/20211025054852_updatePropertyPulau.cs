using Microsoft.EntityFrameworkCore.Migrations;

namespace KlinikAPI.Migrations
{
    public partial class updatePropertyPulau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pulau",
                table: "tProfinsi",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pulau",
                table: "tProfinsi");
        }
    }
}
