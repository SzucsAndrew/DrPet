using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class MedicineRecipe : IEntityTypeConfiguration<MedicineRecipe>
    {
        public int Id { get; set; }

        public int MedicineIntakeId { get; set; }
        public MedicineIntake MedicineIntake { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public void Configure(EntityTypeBuilder<MedicineRecipe> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();

            builder.HasIndex(m => new { m.MedicineId , m.MedicineIntakeId });

            builder.HasOne(m => m.Medicine).WithMany(m => m.MedicineRecipes)
                .HasForeignKey(m => m.MedicineId).HasPrincipalKey(m => m.Id);
        }
    }
}
