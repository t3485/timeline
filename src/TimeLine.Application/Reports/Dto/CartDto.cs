using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Reports.Dto
{
    public class CartDto
    {
        public IEnumerable<DateTime> Date { get; set; }

        public IEnumerable<decimal> A { get; set; }

        public IEnumerable<decimal> B { get; set; }

        public string AName { get; set; }

        public string BName { get; set; }
    }
}
