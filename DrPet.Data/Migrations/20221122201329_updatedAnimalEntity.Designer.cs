﻿// <auto-generated />
using System;
using DrPet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrPet.Data.Migrations
{
    [DbContext(typeof(DrPetDbContext))]
    [Migration("20221122201329_updatedAnimalEntity")]
    partial class updatedAnimalEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DrPet.Data.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KindId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KindId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Assistant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("Fired")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Assistants");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("Fired")
                        .HasColumnType("bit");

                    b.Property<string>("ImageName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Introduce")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Kind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id", "SpeciesId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Kinds");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("DrPet.Data.Entities.MedicineIntake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("MedicineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("Id", "Frequency");

                    b.ToTable("MedicineIntakes");
                });

            modelBuilder.Entity("DrPet.Data.Entities.MedicineRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MedicineId")
                        .HasColumnType("int");

                    b.Property<int>("MedicineIntakeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicineIntakeId");

                    b.HasIndex("MedicineId", "MedicineIntakeId");

                    b.ToTable("MedicineRecipes");
                });

            modelBuilder.Entity("DrPet.Data.Entities.OrderingHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("End")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("OrderingHours");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("DrPet.Data.Entities.OwnerAnimal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("OwnerId", "AnimalId")
                        .IsUnique();

                    b.ToTable("OwnerAnimals");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Specieses");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Appointment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("DortorId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("DortorId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("DrPet.Data.Entities.TreatmentEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("time");

                    b.Property<int?>("MedicineRecipeId")
                        .HasColumnType("int");

                    b.Property<int?>("PrevTreatmentEntryId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("TreatmentEntryType")
                        .HasColumnType("int");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicineRecipeId");

                    b.HasIndex("PrevTreatmentEntryId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("TreatmentEntries");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Animal", b =>
                {
                    b.HasOne("DrPet.Data.Entities.Kind", "Kind")
                        .WithMany("Animals")
                        .HasForeignKey("KindId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DrPet.Data.Entities.Species", "Species")
                        .WithMany("Animals")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Kind");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Kind", b =>
                {
                    b.HasOne("DrPet.Data.Entities.Species", "Species")
                        .WithMany("Kinds")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Species");
                });

            modelBuilder.Entity("DrPet.Data.Entities.MedicineIntake", b =>
                {
                    b.HasOne("DrPet.Data.Entities.Medicine", null)
                        .WithMany("MedicineIntakes")
                        .HasForeignKey("MedicineId");
                });

            modelBuilder.Entity("DrPet.Data.Entities.MedicineRecipe", b =>
                {
                    b.HasOne("DrPet.Data.Entities.Medicine", "Medicine")
                        .WithMany("MedicineRecipes")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrPet.Data.Entities.MedicineIntake", "MedicineIntake")
                        .WithMany("MedicineRecipes")
                        .HasForeignKey("MedicineIntakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicine");

                    b.Navigation("MedicineIntake");
                });

            modelBuilder.Entity("DrPet.Data.Entities.OrderingHour", b =>
                {
                    b.HasOne("DrPet.Data.Entities.Doctor", "Doctor")
                        .WithMany("OrderingHours")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DrPet.Data.Entities.OwnerAnimal", b =>
                {
                    b.HasOne("DrPet.Data.Entities.Animal", "Animal")
                        .WithMany("OwnerAnimals")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrPet.Data.Entities.Owner", "Owner")
                        .WithMany("OwnerAnimals")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Treatment", b =>
                {
                    b.HasOne("DrPet.Data.Entities.Animal", "Animal")
                        .WithMany("Treatments")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrPet.Data.Entities.Doctor", "Doctor")
                        .WithMany("Treatments")
                        .HasForeignKey("DortorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrPet.Data.Entities.Owner", "Owner")
                        .WithMany("Treatments")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Doctor");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DrPet.Data.Entities.TreatmentEntry", b =>
                {
                    b.HasOne("DrPet.Data.Entities.MedicineRecipe", "MedicineRecipes")
                        .WithMany()
                        .HasForeignKey("MedicineRecipeId");

                    b.HasOne("DrPet.Data.Entities.TreatmentEntry", "PrevTreatmentEntry")
                        .WithMany()
                        .HasForeignKey("PrevTreatmentEntryId");

                    b.HasOne("DrPet.Data.Entities.Treatment", "Treatment")
                        .WithMany("TreatmentEntries")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicineRecipes");

                    b.Navigation("PrevTreatmentEntry");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Animal", b =>
                {
                    b.Navigation("OwnerAnimals");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Doctor", b =>
                {
                    b.Navigation("OrderingHours");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Kind", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Medicine", b =>
                {
                    b.Navigation("MedicineIntakes");

                    b.Navigation("MedicineRecipes");
                });

            modelBuilder.Entity("DrPet.Data.Entities.MedicineIntake", b =>
                {
                    b.Navigation("MedicineRecipes");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Owner", b =>
                {
                    b.Navigation("OwnerAnimals");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Species", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Kinds");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Treatment", b =>
                {
                    b.Navigation("TreatmentEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
