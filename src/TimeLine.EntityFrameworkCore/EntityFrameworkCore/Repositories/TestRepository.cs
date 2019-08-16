using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeLine.Axis.Lines;
using TimeLine.Service;

namespace TimeLine.EntityFrameworkCore.Repositories
{
    public class TestRepository : TimeLineRepositoryBase<TimeAxisAuthority>, ITestRepository
    {
        public TestRepository(IDbContextProvider<TimeLineDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public void Test()
        {
            var data = Context.TimeAxisAuthority.TagWith("------------------")
                .GroupBy(x => new { x.User.Id, x.User.Name })
                .Select(x => new
                {
                    ff = x.Key.Id,
                    name = x.Key.Name
                });
            var b = data.ToList();
        }
    }
}
