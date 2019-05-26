using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TimeLine.Authorization.Roles;
using TimeLine.Authorization.Users;
using TimeLine.MultiTenancy;
using TimeLine.Axis.Items;
using TimeLine.Axis.Lines;
using TimeLine.Axis.Filters;

namespace TimeLine.EntityFrameworkCore
{
    public class TimeLineDbContext : AbpZeroDbContext<Tenant, Role, User, TimeLineDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public virtual DbSet<TimeAxis> TimeAxes { get; set; }
        public virtual DbSet<TimeAxis> TimeAxisAuthority { get; set; }
        public virtual DbSet<TimeAxis> TimeAxisItemAuthority { get; set; }
        public virtual DbSet<TimeAxis> TimeAxisFilter { get; set; }
        public virtual DbSet<TimeAxis> TimeAxisItem { get; set; }

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
