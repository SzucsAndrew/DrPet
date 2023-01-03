using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrPet.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>, IEntityTypeConfiguration<ApplicationUser>
    {
        public string Name { get; set; }

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers");
            builder.Property(a => a.Name).HasMaxLength(100);
        }
    }
}
