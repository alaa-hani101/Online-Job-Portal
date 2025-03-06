using JobPortalManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JobPortalManagement.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Job> Jobs { set; get; }
        public DbSet<Company> Companys { set; get; }
        public DbSet<Userr> Users { set; get; }
        public DbSet<Applicationn> Apllications { set; get; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var constr = configuration.GetSection("constr").Value;

            options.UseSqlServer(constr);
            //.LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
