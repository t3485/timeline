using Abp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization.Users;
using TimeLine.Plans;
using TimeLine.Repository;

namespace TimeLine.EntityFrameworkCore.Repositories
{
    public class PlanRepository : TimeLineRepositoryBase<PlanAward>, IPlanRepository
    {


        public PlanRepository(IDbContextProvider<TimeLineDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public PlanAward GetByUser(User user)
        {
            var entity = Single(x => x.User.Id == user.Id);

            if (entity == null)
            {
                entity = new PlanAward()
                {
                    User = user,
                    AwardsMoney = 0
                };
            }
            return entity;
        }

        public PlanAward CompletePlan(PlanComplete plan)
        {
            var award = GetByUser(plan.User);

            award.CompletePlan(plan);

            return InsertOrUpdate(award);
        }
    }
}
