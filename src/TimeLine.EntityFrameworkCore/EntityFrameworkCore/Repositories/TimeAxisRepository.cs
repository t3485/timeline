using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Lines;
using TimeLine.Repository;
using TimeLine.Service;

namespace TimeLine.EntityFrameworkCore.Repositories
{
    public class TimeAxisRepository : TimeLineRepositoryBase<TimeAxis>, ITimeAxisRepository
    {
        public TimeAxisRepository(IDbContextProvider<TimeLineDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IEnumerable<User> GetAssignAuthorityOfUser(TimeAxis axis)
        {
            var data = Context.TimeAxisAuthority.AsNoTracking()
                .TagWith("GetAssignAuthorityOfUser")
                .Where(x => x.TimeAxis.Id == axis.Id)
                .GroupBy(x => new { x.User.Id, x.User.Name })
                .Select(x => new
                {
                    x.Key.Id,
                    x.Key.Name,
                    TimeAxisAuthorities = x.Select(y => y.AuthorityType)
                }).ToList();
            var result = new List<User>();
            foreach (var item in data)
            {
                var user = new User
                {
                    Name = item.Name,
                    Id = item.Id
                };

                foreach (var auth in item.TimeAxisAuthorities)
                    user.AddAuth(new TimeAxisAuthority(auth));
                result.Add(user);
            }
            return result;
        }

        public IEnumerable<TimeAxis> GetAll(User user, int skip, int take)
        {
            var lines = Context.TimeAxes.AsNoTracking()
                            .Include(x => x.User)
                            .ThenInclude(x => x.TimeAxisAuthorities)
                            .FilterTimeAxisItems(user)
                            .Select(x => new { item = x, auth = x.TimeAxisAuthority.Where(y => y.User.Id == user.Id).ToList() })
                            .OrderByDescending(x => x.item.CreationTime)
                            .Skip(skip).Take(take).ToList();
            lines.ForEach(x => x.item.SetAuth(x.auth));

            return lines.Select(x => x.item);
        }
    }
}
