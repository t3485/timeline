using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization.Users;

namespace TimeLine.Plans
{
    public class PlanAward : CreationAuditedAggregateRoot
    {
        public virtual User User { get; set; }

        public double AwardsMoney { get; set; }


        public double CompletePlan(PlanComplete plan)
        {
            return AwardsMoney += plan.PlanWeek.Awards;
        }
    }
}
