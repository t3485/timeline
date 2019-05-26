using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Axis.Dto
{
    public class AxisDto : EntityDto<int>
    {
        public string title { get; set; }

        public string describe { get; set; }
    }
}
