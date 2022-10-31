using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class Assistant : IEntityTypeConfiguration<Assistant>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Fired { get; set; }
        public string? Comment { get; set; }
        public byte[] RowVersion { get; set; }

        public void Configure(EntityTypeBuilder<Assistant> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();

            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(100);

            builder.Property(a => a.Comment).HasMaxLength(300);

            builder.Property(a => a.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
