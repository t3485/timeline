using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization.Users;
using TimeLine.Plans;

namespace TimeLine.Repository
{
    public interface IPlanRepository : IRepository<PlanAward>
    {
        PlanAward GetByUser(User user);

        PlanAward CompletePlan(PlanComplete plan);
    }
}
