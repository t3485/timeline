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
    public class TimeAxisManager : DomainService, ITimeAxisManager
    {
        private readonly IAuthorityManager _authorityManager;
        private readonly ITestRepository _testRepository;

        public TimeAxisManager(IAuthorityManager authorityManager, ITestRepository testRepository)
        {
            _authorityManager = authorityManager;
            _testRepository = testRepository;
        }

        public void Test()
        {
            _testRepository.Test();
        }

        public TimeAxis CreateTimeAxis(User user, string title)
        {
            var entity = new TimeAxis(title);
            _authorityManager.AssignAllTo(user, entity);

            return entity;
        }

        public IQueryable<TimeAxis> FilterVisibleTimeAxes(IQueryable<TimeAxis> list)
        {
            return list.Where(x => x.TimeAxisAuthority.Any(y => y.AuthorityType == AuthorityType.View));
        }

        public IEnumerable<TimeAxisItem> FilterTimeAxisItems(TimeAxis line, TimeAxisFilter filter)
        {
            if (filter == null || !filter.HasAnyFilters())
                return new List<TimeAxisItem>();

            var items = line.GetItems();
            if (filter.MaxDate != null)
                items = items.Where(x => x.EndTime <= filter.MaxDate);
            if (filter.MinDate != null)
                items = items.Where(x => x.StartTime >= filter.MinDate);
            if (filter.MaxPage != null)
                items = items.Where(x => x.MaxPage <= filter.MaxPage);
            if (filter.MinPage != null)
                items = items.Where(x => x.MinPage >= filter.MinPage);

            return items;
        }
    }
}
