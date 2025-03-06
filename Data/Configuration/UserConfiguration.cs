using JobPortalManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortalManagement.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Userr>
    {
        public void Configure(EntityTypeBuilder<Userr> builder)
        {
            builder.HasKey(u => u.ID);

            builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.Role)
                .IsRequired();

            builder.HasMany(u => u.Applications)
                .WithOne(a => a.user)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Cascade);


            builder.ToTable("Users");

        }

    }
}
