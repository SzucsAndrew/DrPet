using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class OwnerAnimal : IEntityTypeConfiguration<OwnerAnimal>
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public void Configure(EntityTypeBuilder<OwnerAnimal> builder)
        {
            builder.Property(oa => oa.Id)
                   .UseIdentityColumn();

            builder.HasOne(oa => oa.Owner).WithMany(o => o.OwnerAnimals)
                   .HasForeignKey(oa => oa.OwnerId)
                   .HasPrincipalKey(o => o.Id);

            builder.HasOne(oa => oa.Animal).WithMany(a => a.OwnerAnimals)
                   .HasForeignKey(oa => oa.AnimalId)
                   .HasPrincipalKey(a => a.Id);

            builder.HasIndex(oa => new { oa.OwnerId, oa.AnimalId })
                   .IsUnique();
        }
    }
}
