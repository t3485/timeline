using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Reports;
using TimeLine.Reports.Tables;

namespace TimeLine.Service
{
    public interface IReportManager : IDomainService
    {
        List<int> GetLostYear(IEnumerable<DateTime> times, DateTime start);

        Task<List<ZCFZ>> GetZCFZs(string code);

        Task<List<LRB>> GetLRBs(string code);

        Task<List<XJLLB>> GetXJLLBs(string code);
    }
}
