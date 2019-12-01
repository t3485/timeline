using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Plans
{
    public class PlanWeek : CreationAuditedAggregateRoot
    {
        public int Day { get; set; }

        public string Tasks { get; set; }

        public int During { get; set; }

        public double Awards { get; set; }
    }
}
