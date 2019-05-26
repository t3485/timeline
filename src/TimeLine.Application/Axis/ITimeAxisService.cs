using Abp.Application.Services;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Axis.Dto;

namespace TimeLine.Axis
{
    public interface ITimeAxisService : IApplicationService, ITransientDependency
    {
        void CreateTimeAxis(CreateAxisDto input);
    }
}
