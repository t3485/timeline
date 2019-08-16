using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Axis.Lines
{
    public class LimitedAttribute : Attribute
    {
        public bool Exclusive { get; set; }

        public bool BasicNeed { get; set; }

        public string Name { get; set; }
    }
}
