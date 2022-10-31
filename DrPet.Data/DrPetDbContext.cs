using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DrPet.Data
{
    public class DrPetDbContext : DbContext
    {
        public DrPetDbContext(DbContextOptions<DrPetDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<OwnerAnimal> OwnerAnimals { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Species> Specieses { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<TreatmentEntry> TreatmentEntries { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineIntake> MedicineIntakes { get; set; }
        public DbSet<MedicineRecipe> MedicineRecipes { get; set; }
        public DbSet<OrderingHour> OrderingHours { get; set; }
    }
}
