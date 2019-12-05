using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TimeLine.Authorization.Roles;
using TimeLine.Authorization.Users;
using TimeLine.MultiTenancy;
using TimeLine.Axis.Lines;
using TimeLine.Axis.Filters;
using TimeLine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeLine.Reports;
using TimeLine.Plans;
using TimeLine.Reports.Tables;

namespace TimeLine.EntityFrameworkCore
{
    public class TimeLineDbContext : AbpZeroDbContext<Tenant, Role, User, TimeLineDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public virtual DbSet<TimeAxis> TimeAxes { get; set; }
        public virtual DbSet<TimeAxisAuthority> TimeAxisAuthority { get; set; }
        public virtual DbSet<TimeAxisFilter> TimeAxisFilter { get; set; }
        public virtual DbSet<TimeAxisItem> TimeAxisItem { get; set; }
        public virtual DbSet<PlanWeek> PlanWeek { get; set; }
        public virtual DbSet<PlanComplete> PlanComplete { get; set; }
        public virtual DbSet<TableData> TableDatas { get; set; }

        public TimeLineDbContext(DbContextOptions<TimeLineDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TimeAxisCreating(modelBuilder);
            TimeAxisAuthorityCreating(modelBuilder);

            modelBuilder.Entity<TimeAxisFilter>().ToTable(nameof(TimeAxisFilter));
            modelBuilder.Entity<TimeAxisItem>().ToTable(nameof(TimeAxisItem));


            foreach (var config in GetConfiguration())
            {
                var instance = (IContextConfiguration)Activator.CreateInstance(config);
                instance.Config(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

        private void TimeAxisCreating(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<TimeAxis>().ToTable(nameof(TimeAxis));

            builder.HasOne(x => x.User).WithMany(x => x.TimeAxis);
            builder.HasMany(x => x.TimeAxisAuthority).WithOne(x => x.TimeAxis).OnDelete(DeleteBehavior.Cascade);
        }

        private void TimeAxisAuthorityCreating(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<TimeAxisAuthority>().ToTable(nameof(TimeAxisAuthority));

            builder.HasOne(x => x.User).WithMany(x => x.TimeAxisAuthorities);
        }

        private IEnumerable<Type> GetConfiguration()
        {
            var baseType = typeof(IContextConfiguration);

            return AppDomain.CurrentDomain.GetAssemblies()
                 .FirstOrDefault(x => x.FullName.StartsWith("TimeLine.Core"))
                 .GetTypes()
                 .Where(x => x.IsClass && baseType.IsAssignableFrom(x));
        }
    }
}
