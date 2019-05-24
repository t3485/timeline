using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Axis.Dto;

namespace TimeLine.Axis
{
    public interface ITimeAxisService : IApplicationService
    {
        void CreateTimeAxis(CreateAxisDto input);
    }
}
