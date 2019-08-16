using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Filters;
using TimeLine.Axis.Lines;

namespace TimeLine.Service
{
    public static class TimeAxisManagerExtensions
    {
        public static IQueryable<TimeAxis> FilterTimeAxisItems(this IQueryable<TimeAxis> list, User user)
        {
            return list.Where(x => x.TimeAxisAuthority.Any(y => y.AuthorityType == AuthorityType.View && y.User.Id == user.Id));
        }
    }
}
