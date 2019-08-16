using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Axis.Lines;

namespace TimeLine.Service
{
    public interface ITestRepository: IRepository<TimeAxisAuthority>
    {
        void Test();
    }
}
