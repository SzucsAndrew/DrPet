using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrPet.Data.Migrations
{
    public partial class updatedDoctorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Doctors",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduce",
                table: "Doctors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Introduce",
                table: "Doctors");
        }
    }
}
