using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Axis
{
    public class TimeAxis : CreationAuditedAggregateRoot
    {
        #region Fileds
        public string Title { get; private set; }

        public string Describe { get; private set; }
        
        public virtual ICollection<TimeAxisFilter> Filters { get; private set; }

        public virtual ICollection<TimeAxisItem> Items { get; private set; }

        public virtual ICollection<TimeAxisAuthority> TimeAxisAuthority { get; private set; }
        #endregion

        private TimeAxis() { }
        public TimeAxis(string title)
        {
            Title = title;
        }
    }
}
