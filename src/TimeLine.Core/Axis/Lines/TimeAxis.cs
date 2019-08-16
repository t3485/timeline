using Abp;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Filters;

namespace TimeLine.Axis.Lines
{
    public class TimeAxis : CreationAuditedAggregateRoot
    {
        #region Fileds
        public string Title { get; private set; }

        public string Describe { get; private set; }
        /// <summary>
        /// 是否为开放状态
        /// </summary>
        public bool IsPublic { get; private set; }
        /// <summary>
        /// 排序类型
        /// </summary>
        public ItmesOrderType OrderType { get; set; }

        public virtual ICollection<TimeAxisFilter> Filters { get; private set; }

        public virtual ICollection<TimeAxisItem> Items { get; private set; }

        public virtual ICollection<TimeAxisAuthority> TimeAxisAuthority { get; private set; }

        public virtual User User { get; set; }
        #endregion

        #region Ctor
        public TimeAxis() { }
        public TimeAxis(string title)
        {
            Title = title;
            Filters = new List<TimeAxisFilter>();
            Items = new List<TimeAxisItem>();
            TimeAxisAuthority = new List<TimeAxisAuthority>();
            User = new User();
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

        public void RemoveAuth(AuthorityType e, User user)
        {
            var ele = TimeAxisAuthority.FirstOrDefault(x => x.AuthorityType == e && x.User.Id == user.Id);
            if (ele != null)
                TimeAxisAuthority.Remove(ele);
        }

        public void SetAuth(ICollection<TimeAxisAuthority> e)
        {
            TimeAxisAuthority = e;
        }

        public IEnumerable<AuthorityType> GetAuthorities(long userid)
        {
            if (TimeAxisAuthority != null)
                return TimeAxisAuthority.Where(x => x.User.Id == userid).Select(x => x.AuthorityType);
            return new List<AuthorityType>();
        }
        #endregion

        #region Item
        public void AddItem(TimeAxisItem e)
        {
            if (Items.Any(x => x.Descript == e.Descript))
                throw new AbpException("Descript could not be same");
            Items.Add(e);
        }

        public void RemoveItem(TimeAxisItem e)
        {
            Items.Remove(e);
        }

        public IEnumerable<TimeAxisItem> GetItems()
        {
            return Items;
        }

        public TimeAxisItem GetItemById(int id)
        {
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
                throw new EntityNotFoundException(typeof(TimeAxisItem), id);
            return item;
        }

        public IEnumerable<TimeAxisItem> Order(IEnumerable<TimeAxisItem> itmes)
        {
            if (OrderType == ItmesOrderType.Date)
                return Items.OrderBy(x => x.StartTime);
            if (OrderType == ItmesOrderType.EndDate)
                return Items.OrderBy(x => x.EndTime);

            return Items;
        }
        #endregion        
    }
}
