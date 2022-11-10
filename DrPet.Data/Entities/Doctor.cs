using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class Doctor : IEntityTypeConfiguration<Doctor>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Fired { get; set; }
        public string? Comment { get; set; }
        public string? ImageName { get; set; }
        public string? Introduce { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<Treatment> Treatments { get; set; }
        public ICollection<OrderingHour> OrderingHours { get; set; }

        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).UseIdentityColumn();

            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Name).HasMaxLength(100);

            builder.Property(d => d.ImageName).HasMaxLength(250);

            builder.Property(d => d.Introduce).HasMaxLength(100);

            builder.Property(d => d.Comment).HasMaxLength(300);

            builder.Property(d => d.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}