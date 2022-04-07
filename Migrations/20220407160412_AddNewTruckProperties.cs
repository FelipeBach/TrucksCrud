using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckCrud.Migrations
{
    public partial class AddNewTruckProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plate",
                table: "Trucks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RegisterNumber",
                table: "Trucks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plate",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "RegisterNumber",
                table: "Trucks");
        }
    }
}
