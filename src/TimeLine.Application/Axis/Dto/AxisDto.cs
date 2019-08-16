using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Axis.Lines;

namespace TimeLine.Axis.Dto
{
    public class AxisDto : EntityDto<int>
    {
        public string Title { get; set; }

        public string Describe { get; set; }

        public string Creator { get; set; }

        public DateTime CreationTime { get; set; }

        public string Authorities { get; set; }

        public List<string> AuthorityList { get; set; }
    }
}
