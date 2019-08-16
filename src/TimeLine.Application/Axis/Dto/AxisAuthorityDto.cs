using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Axis.Dto
{
    public class AxisAuthorityDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool Exclusive { get; set; }

        public bool BasicNeed { get; set; }

        public int Order { get; set; }

        public AxisAuthorityDto(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public AxisAuthorityDto(string name, string type, bool exclusive, bool basicNeed)
        {
            Name = name;
            Type = type;
            Exclusive = exclusive;
            BasicNeed = basicNeed;
        }

        public AxisAuthorityDto(string name, string type, bool exclusive, bool basicNeed, int order)
        {
            Name = name;
            Type = type;
            Exclusive = exclusive;
            BasicNeed = basicNeed;
            Order = order;
        }
    }
}
