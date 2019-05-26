using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Axis.Items;

namespace TimeLine.Axis.Dto
{
    [AutoMapTo(typeof(TimeAxisItemAuthority))]
    public class AssignAuthDto : EntityDto<int>
    {
        public string AuthorizeType { get; set; }
    }
}
