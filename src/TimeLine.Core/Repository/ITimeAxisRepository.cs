using Abp.Domain.Repositories;
using System.Collections.Generic;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Lines;

namespace TimeLine.Repository
{
    public interface ITimeAxisRepository : IRepository<TimeAxis>
    {
        IEnumerable<User> GetAssignAuthorityOfUser(TimeAxis axis);

        IEnumerable<TimeAxis> GetAll(User user, int skip, int take);
    }
}
