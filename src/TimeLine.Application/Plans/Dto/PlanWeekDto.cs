using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Plans.Dto
{
    public class PlanWeekDto
    {
        public int Id { get; set; }

        public int Day { get; set; }

        public string Tasks { get; set; }

        public int During { get; set; }

        public double Awards { get; set; }

        public PlanCompleteStatus Status { get; set; }
    }
}
