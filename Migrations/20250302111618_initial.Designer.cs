﻿// <auto-generated />
using JobPortalManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobPortal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250302111618_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobPortalManagement.Entities.Applicationn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("jobID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Applications", (string)null);
                });

            modelBuilder.Entity("JobPortalManagement.Entities.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Companys", (string)null);
                });

            modelBuilder.Entity("JobPortalManagement.Entities.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobPortalManagement.Entities.Userr", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Password")
                        .HasColumnType("float");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("JobPortalManagement.Entities.Applicationn", b =>
                {
                    b.HasOne("JobPortalManagement.Entities.Job", "job")
                        .WithMany("Applications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortalManagement.Entities.Userr", "user")
                        .WithMany("Applications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("job");

                    b.Navigation("user");
                });

            modelBuilder.Entity("JobPortalManagement.Entities.Job", b =>
                {
                    b.HasOne("JobPortalManagement.Entities.Company", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("JobPortalManagement.Entities.Company", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobPortalManagement.Entities.Job", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("JobPortalManagement.Entities.Userr", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
