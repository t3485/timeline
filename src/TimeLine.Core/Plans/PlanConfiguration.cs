using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Core;

namespace TimeLine.Plans
{
    public class PlanConfiguration : IContextConfiguration
    {
        public void Config(ModelBuilder builder)
        {
            var pwBuilder = builder.Entity<PlanWeek>()
                .ToTable(nameof(PlanWeek));
            pwBuilder.HasKey(x => x.Id);
            pwBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            pwBuilder.Property(x => x.Tasks)
                .HasMaxLength(128).IsRequired();
            pwBuilder.Property(x => x.During).IsRequired();
            pwBuilder.Property(x => x.Day).IsRequired();


            var pcBuilder = builder.Entity<PlanComplete>()
                .ToTable(nameof(PlanComplete));
            pcBuilder.HasKey(x => x.Id);
            pcBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            pcBuilder.HasOne(x => x.PlanWeek);
            pcBuilder.HasOne(x => x.User);
            pcBuilder.OwnsOne(x => x.PlanCompleteCopy);
            pcBuilder.Property(x => x.Status).IsRequired();

            var pw = builder.Entity<PlanAward>()
                .ToTable(nameof(PlanAward));
            pw.HasKey(x => x.Id);
            pw.Property(x => x.Id).ValueGeneratedOnAdd();
            pw.HasOne(x => x.User);
        }
    }
}
