using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrPet.Data.Migrations
{
    public partial class InitialDrPetSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assistants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fired = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fired = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specieses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specieses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderingHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Start = table.Column<TimeSpan>(type: "time", nullable: false),
                    End = table.Column<TimeSpan>(type: "time", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderingHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderingHours_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineIntakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frequency = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineIntakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineIntakes_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kinds", x => new { x.Id, x.SpeciesId });
                    table.UniqueConstraint("AK_Kinds_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kinds_Specieses_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Specieses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineIntakeId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineRecipes_MedicineIntakes_MedicineIntakeId",
                        column: x => x.MedicineIntakeId,
                        principalTable: "MedicineIntakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineRecipes_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    KindId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Kinds_KindId",
                        column: x => x.KindId,
                        principalTable: "Kinds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Animals_Specieses_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Specieses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OwnerAnimals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerAnimals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerAnimals_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerAnimals_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Appointment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    DortorId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_Doctors_DortorId",
                        column: x => x.DortorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentEntryType = table.Column<int>(type: "int", nullable: false),
                    MedicineRecipeId = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    TreatmentId = table.Column<int>(type: "int", nullable: false),
                    PrevTreatmentEntryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentEntries_MedicineRecipes_MedicineRecipeId",
                        column: x => x.MedicineRecipeId,
                        principalTable: "MedicineRecipes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TreatmentEntries_TreatmentEntries_PrevTreatmentEntryId",
                        column: x => x.PrevTreatmentEntryId,
                        principalTable: "TreatmentEntries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TreatmentEntries_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_KindId",
                table: "Animals",
                column: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpeciesId",
                table: "Animals",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Kinds_SpeciesId",
                table: "Kinds",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineIntakes_Id_Frequency",
                table: "MedicineIntakes",
                columns: new[] { "Id", "Frequency" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineIntakes_MedicineId",
                table: "MedicineIntakes",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineRecipes_MedicineId_MedicineIntakeId",
                table: "MedicineRecipes",
                columns: new[] { "MedicineId", "MedicineIntakeId" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineRecipes_MedicineIntakeId",
                table: "MedicineRecipes",
                column: "MedicineIntakeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderingHours_DoctorId",
                table: "OrderingHours",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerAnimals_AnimalId",
                table: "OwnerAnimals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerAnimals_OwnerId_AnimalId",
                table: "OwnerAnimals",
                columns: new[] { "OwnerId", "AnimalId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentEntries_MedicineRecipeId",
                table: "TreatmentEntries",
                column: "MedicineRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentEntries_PrevTreatmentEntryId",
                table: "TreatmentEntries",
                column: "PrevTreatmentEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentEntries_TreatmentId",
                table: "TreatmentEntries",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_AnimalId",
                table: "Treatments",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_DortorId",
                table: "Treatments",
                column: "DortorId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_OwnerId",
                table: "Treatments",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assistants");

            migrationBuilder.DropTable(
                name: "OrderingHours");

            migrationBuilder.DropTable(
                name: "OwnerAnimals");

            migrationBuilder.DropTable(
                name: "TreatmentEntries");

            migrationBuilder.DropTable(
                name: "MedicineRecipes");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "MedicineIntakes");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Kinds");

            migrationBuilder.DropTable(
                name: "Specieses");
        }
    }
}
