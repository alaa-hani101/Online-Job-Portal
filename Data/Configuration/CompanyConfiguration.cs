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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name)
           .IsRequired()
           .HasMaxLength(100);

            builder.Property(c => c.Industry)
                .HasMaxLength(50);

            builder.Property(c => c.Location)
                .HasMaxLength(150);

            builder.HasMany(c => c.Jobs)
            .WithOne(j => j.Company)
            .HasForeignKey(j => j.CompanyID)
            .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Companys");

        }
    }
}
