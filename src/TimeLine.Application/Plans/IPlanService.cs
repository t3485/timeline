using Abp.Application.Services;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Plans
{
   public interface IPlanService : IApplicationService, ITransientDependency
    {
    }
}
