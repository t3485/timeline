using Abp.Application.Services;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Reports
{
    public interface IReportService : IApplicationService, ITransientDependency
    {
    }
}
