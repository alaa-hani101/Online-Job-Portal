using JobPortalManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalManagement.Data.Configuration
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Applicationn>
    {
        public void Configure(EntityTypeBuilder<Applicationn> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.Status)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(a => a.user)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.job)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Cascade);


            builder.ToTable("Applications");
        }
    }
}
