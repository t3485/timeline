using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeLine.Axis.Dto
{
    [AutoMapFrom(typeof(TimeAxis))]
    public class CreateAxisDto
    {
        public string title { get; set; }
    }
}
