using DrPet.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class TreatmentEntry : IEntityTypeConfiguration<TreatmentEntry>
    {
        public int Id { get; set; }
        public TreatmentEntryType TreatmentEntryType { get; set; }

        public int? MedicineRecipeId { get; set; }
        public MedicineRecipe? MedicineRecipes { get; set; }
        public TimeSpan? Duration { get; set; }
        public string? Comment { get; set; }
        public byte[] RowVersion { get; set; }

        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }

        public int? PrevTreatmentEntryId { get; set; }
        public TreatmentEntry? PrevTreatmentEntry { get; set; }

        public void Configure(EntityTypeBuilder<TreatmentEntry> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseIdentityColumn();

            builder.Property(t => t.Comment).HasMaxLength(300);

            builder.Property(t => t.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(te => te.Treatment)
                .WithMany(t => t.TreatmentEntries)
                .HasForeignKey(te => te.TreatmentId)
                .HasPrincipalKey(t => t.Id);
        }
    }
}