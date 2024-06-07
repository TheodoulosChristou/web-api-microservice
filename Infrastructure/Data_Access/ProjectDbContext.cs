using Microsoft.EntityFrameworkCore;
using Domain.Common;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Infrastructure.Data_Access.Configurations;

namespace Infrastructure.Data_Access
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

        //Table Country
        
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add entity Configuration
            modelBuilder.ApplyConfiguration(new UserConfiguration());
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
