using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class Medicine : IEntityTypeConfiguration<Medicine>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ICollection<MedicineIntake> MedicineIntakes { get; set; }
        public ICollection<MedicineRecipe> MedicineRecipes { get; set; }

        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
        }
    }
}
