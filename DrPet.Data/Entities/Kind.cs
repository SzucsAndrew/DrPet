using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class Kind : IEntityTypeConfiguration<Kind>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SpeciesId { get; set; }
        public Species Species { get; set; }

        public ICollection<Animal> Animals { get; set; }//----

        public void Configure(EntityTypeBuilder<Kind> builder)
        {
            builder.HasKey(k => new { k.Id, k.SpeciesId });
            builder.Property(k => k.Id)
                .UseIdentityColumn();

            builder.Property(k => k.Name)
                .IsRequired();
            builder.Property(k => k.Name)
                .HasMaxLength(120);

            builder.HasOne(k => k.Species)
                .WithMany(s => s.Kinds)
                .HasForeignKey(k => k.SpeciesId)
                .HasPrincipalKey(s => s.Id);
        }
    }
}
