using DrPet.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class Animal : IEntityTypeConfiguration<Animal>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Status Status { get; set; }
        public string? Comment { get; set; }
        public byte[] RowVersion { get; set; }

        public int SpeciesId { get; set; }
        public Species Species { get; set; }

        public int KindId { get; set; }
        public Kind Kind { get; set; }

        public ICollection<OwnerAnimal> OwnerAnimals { get; set; }
        public ICollection<Treatment> Treatments { get; set; }

        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(a => a.Id).UseIdentityColumn();

            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(100);

            builder.Property(a => a.Comment).HasMaxLength(300);

            builder.Property(a => a.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(a => a.Species)
                .WithMany(s => s.Animals)
                .HasForeignKey(a => a.SpeciesId)
                .HasPrincipalKey(s => s.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Kind)
                .WithMany(k => k.Animals)
                .HasForeignKey(a => a.KindId)
                .HasPrincipalKey(k => k.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
