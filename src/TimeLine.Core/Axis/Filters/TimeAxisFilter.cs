using Abp.Domain.Entities;
using System;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Lines;

namespace TimeLine.Axis.Filters
{
    public class TimeAxisFilter : AggregateRoot
    {
        public int? MaxPage { get; private set; }

        public int? MinPage { get; private set; }

        public DateTime? MaxDate { get; private set; }

        public DateTime? MinDate { get; private set; }

        public virtual TimeAxis TimeAxis { get; private set; }

        public virtual User User { get; private set; }

        #region Methods
        public bool HasAnyFilters()
        {
            return !(MaxPage == null && MinPage == null && MaxDate == null && MinDate == null);
        }
        #endregion
    }
}
