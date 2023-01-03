using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrPet.Data.Migrations
{
    public partial class updatedAnimalEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Animals");
        }
    }
}
