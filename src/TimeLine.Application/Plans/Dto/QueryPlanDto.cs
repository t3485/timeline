using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Plans.Dto
{
    public class QueryPlanDto : PagedResultRequestDto
    {
        public DateTimeOffset Time { get; set; }
    }
}
