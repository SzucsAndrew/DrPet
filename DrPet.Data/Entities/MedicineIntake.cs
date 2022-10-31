using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class MedicineIntake : IEntityTypeConfiguration<MedicineIntake>
    {
        public int Id { get; set; }
        public string Frequency { get; set; }

        public ICollection<MedicineRecipe> MedicineRecipes { get; set; }

        public void Configure(EntityTypeBuilder<MedicineIntake> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();

            builder.HasIndex(m => new { m.Id, m.Frequency });

            builder.HasMany(m => m.MedicineRecipes).WithOne(mr => mr.MedicineIntake)
                .HasForeignKey(mr => mr.MedicineIntakeId).HasPrincipalKey(m => m.Id);
        }
    }
}
