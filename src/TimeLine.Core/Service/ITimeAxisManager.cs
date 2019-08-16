using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Filters;
using TimeLine.Axis.Lines;

namespace TimeLine.Service
{
    public interface ITimeAxisManager : IDomainService
    {
        TimeAxis CreateTimeAxis(User user, string title);

        IQueryable<TimeAxis> FilterVisibleTimeAxes(IQueryable<TimeAxis> list);

        IEnumerable<TimeAxisItem> FilterTimeAxisItems(TimeAxis line, TimeAxisFilter filter);

        void Test();
    }
}
