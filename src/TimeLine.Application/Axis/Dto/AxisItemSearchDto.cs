using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Axis.Dto
{
    public class AxisItemSearchDto : PagedResultRequestDto
    {
        public int AxisId { get; private set; }

        public DateTime? StartTime { get; private set; }

        public DateTime? EndTime { get; private set; }

        public int? MaxPage { get; private set; }

        public int? MinPage { get; private set; }
    }
}
