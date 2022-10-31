using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class OrderingHour : IEntityTypeConfiguration<OrderingHour>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan? End { get; set; }
        public string? Comment { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public void Configure(EntityTypeBuilder<OrderingHour> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .UseIdentityColumn();

            builder.Property(t => t.Comment).HasMaxLength(300);

            builder.Property(t => t.Date)
            .HasColumnType("date");

            builder.HasOne(t => t.Doctor).WithMany(d => d.OrderingHours)
                .HasForeignKey(t => t.DoctorId).HasPrincipalKey(d => d.Id);
         }
    }
}
