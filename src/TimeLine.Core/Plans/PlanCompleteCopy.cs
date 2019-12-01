using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Plans
{
    public class PlanCompleteCopy
    {
        public PlanTypes Type { get; set; }

        public int PlanId { get; set; }

        public int Time { get; set; }

        public string Tasks { get; set; }

        public int During { get; set; }
    }
}
