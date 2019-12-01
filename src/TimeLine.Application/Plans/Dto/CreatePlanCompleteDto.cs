using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Plans.Dto
{
    public class CreatePlanCompleteDto
    {
        public int PlanId { get; set; }

        public PlanTypes Type { get; set; }
    }
}
