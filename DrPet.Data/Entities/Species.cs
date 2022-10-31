using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class Species : IEntityTypeConfiguration<Species>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Kind> Kinds { get; set; }
        public ICollection<Animal> Animals { get; set; }

        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();

            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(120);
        }
    }
}
