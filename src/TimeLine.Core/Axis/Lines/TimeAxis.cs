using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using TimeLine.Axis.Filters;
using TimeLine.Axis.Items;

namespace TimeLine.Axis.Lines
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

        #region Ctor
        private TimeAxis() { }
        public TimeAxis(string title)
        {
            Title = title;
            Filters = new List<TimeAxisFilter>();
            Items = new List<TimeAxisItem>();
            TimeAxisAuthority = new List<TimeAxisAuthority>();
        }
        #endregion

        #region Auth
        public void AddAuth(TimeAxisAuthority e)
        {
            TimeAxisAuthority.Add(e);
        }

        public void RemoveAuth(TimeAxisAuthority e)
        {
            TimeAxisAuthority.Remove(e);
        }
        #endregion

        #region Item
        public void AddItem(TimeAxisItem e)
        {
            Items.Add(e);
        }

        public void RemoveItem(TimeAxisItem e)
        {
            Items.Remove(e);
        }
        #endregion

        #region Filter
        public void AddFilter(TimeAxisFilter e)
        {
            Filters.Add(e);
        }

        public void RemoveFilter(TimeAxisFilter e)
        {
            Filters.Remove(e);
        }
        #endregion
    }
}
