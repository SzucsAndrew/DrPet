using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class Treatment : IEntityTypeConfiguration<Treatment>
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime Appointment { get; set; }
        public string? Comment { get; set; }
        public byte[] RowVersion { get; set; }

        public int DortorId { get; set; }
        public Doctor Doctor { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        public ICollection<TreatmentEntry> TreatmentEntries { get; set; }

        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .UseIdentityColumn();

            builder.Property(t => t.Price)
            .HasColumnType("decimal(8,2)");

            builder.Property(t => t.Comment).HasMaxLength(300);

            builder.Property(t => t.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.HasOne(t => t.Doctor)
                .WithMany(d => d.Treatments)
                .HasForeignKey(t => t.DortorId)
                .HasPrincipalKey(d => d.Id);

            builder.HasOne(t => t.Animal)
                .WithMany(a => a.Treatments)
                .HasForeignKey(t => t.AnimalId)
                .HasPrincipalKey(a => a.Id);

            builder.HasOne(t => t.Owner)
                .WithMany(o => o.Treatments)
                .HasForeignKey(t => t.OwnerId)
                .HasPrincipalKey(o => o.Id);
        }
    }
}
