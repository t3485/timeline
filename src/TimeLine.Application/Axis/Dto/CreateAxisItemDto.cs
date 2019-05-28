using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Axis.Dto
{
    public class CreateItemDto
    {
        public int AxisId { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int MaxPage { get; set; }

        public int MinPage { get; set; }

        public string Descript { get; set; }

        public string Content { get; set; }

        public string ImgPath { get; set; }
    }
}
