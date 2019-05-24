using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TimeLine.Authorization.Roles;
using TimeLine.Authorization.Users;
using TimeLine.MultiTenancy;
using TimeLine.Axis;

namespace TimeLine.EntityFrameworkCore
{
    public class TimeLineDbContext : AbpZeroDbContext<Tenant, Role, User, TimeLineDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public TimeLineDbContext(DbContextOptions<TimeLineDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TimeAxis>().ToTable(nameof(TimeAxis));

            modelBuilder.Entity<TimeAxisAuthority>().ToTable(nameof(TimeAxisAuthority));
            modelBuilder.Entity<TimeAxisItemAuthority>().ToTable(nameof(TimeAxisItemAuthority));
            modelBuilder.Entity<TimeAxisFilter>().ToTable(nameof(TimeAxisFilter));
            modelBuilder.Entity<TimeAxisItem>().ToTable(nameof(TimeAxisItem));
        }
    }
}
