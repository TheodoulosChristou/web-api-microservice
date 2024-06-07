using Microsoft.EntityFrameworkCore;
using Infrastructure.DataAccess.Configurations;
using Domain.Entities;
using Domain.Common;

namespace Infrastructure.Data_Access
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

        //Table Country
        
        public DbSet<Template> Template { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("MEDNEXT");

            //Add entity Configuration
            
            modelBuilder.ApplyConfiguration(new TemplateConfiguration());

            ////KEYS

            ////Country Keys
            //modelBuilder.Entity<Country>().HasKey(k => k.countryId);

            //modelBuilder.Entity<Country>().Property(k => k.countryId).ValueGeneratedOnAdd();

            ////Region Keys
            //modelBuilder.Entity<Region>().HasKey(k => k.REGION_ID);

            //modelBuilder.Entity<Region>().Property(k => k.REGION_ID).ValueGeneratedOnAdd();


            //modelBuilder.Entity<Region>().HasKey(k => k.COUNTRY_ID);
            //modelBuilder.Entity<Region>().HasAlternateKey(k => k.COUNTRY_ID);

            ////Data


        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LASTMODIFIEDDTTM = DateTime.Now;
                    entry.Entity.LASTMODIFIEDBY = "Admin";
                }
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CREATIONDTTM = DateTime.Now;
                    entry.Entity.LASTMODIFIEDDTTM = DateTime.Now;
                    entry.Entity.CREATEDBY = "Admin";
                }
            }



            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
