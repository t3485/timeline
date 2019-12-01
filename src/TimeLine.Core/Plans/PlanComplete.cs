using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization.Users;

namespace TimeLine.Plans
{
    public class PlanComplete : CreationAuditedAggregateRoot
    {
        public virtual PlanCompleteCopy PlanCompleteCopy { get; set; }

        public virtual PlanWeek PlanWeek { get; set; }

        public PlanCompleteStatus Status { get; set; }

        public DateTimeOffset Time { get; set; }

        public DateTimeOffset? CompleteTime { get; set; }

        public virtual User User { get; set; }
    }
}
