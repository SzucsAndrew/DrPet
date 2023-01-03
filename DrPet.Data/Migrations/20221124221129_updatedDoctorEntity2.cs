using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrPet.Data.Migrations
{
    public partial class updatedDoctorEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Doctors_DortorId",
                table: "Treatments");

            migrationBuilder.RenameColumn(
                name: "DortorId",
                table: "Treatments",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Treatments_DortorId",
                table: "Treatments",
                newName: "IX_Treatments_DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Doctors_DoctorId",
                table: "Treatments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Doctors_DoctorId",
                table: "Treatments");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Treatments",
                newName: "DortorId");

            migrationBuilder.RenameIndex(
                name: "IX_Treatments_DoctorId",
                table: "Treatments",
                newName: "IX_Treatments_DortorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Doctors_DortorId",
                table: "Treatments",
                column: "DortorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
