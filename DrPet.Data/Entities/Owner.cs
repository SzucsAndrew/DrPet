using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class Owner : IEntityTypeConfiguration<Owner>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Place { get; set; }
        public string? Comment { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<OwnerAnimal> OwnerAnimals { get; set; }
        public ICollection<Treatment> Treatments { get; set; }

        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();

            builder.Property(o => o.Name).IsRequired();
            builder.Property(o => o.Name).HasMaxLength(100);

            builder.Property(o => o.Comment).HasMaxLength(300);

            builder.Property(o => o.Place).HasMaxLength(150);

            builder.Property(o => o.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        }
    }
}
