using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Reports;

namespace TimeLine.Reports
{
    public interface IRequestsService : ITransientDependency
    {
        Task<List<ZCFZ>> GetCaptialAndBillTable(string code);
    }
}
