using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Reports;
using TimeLine.Reports.Tables;

namespace TimeLine.Service
{
    public interface IRequestsService : ITransientDependency
    {
        Task<List<ZCFZ>> GetCaptialAndBillTable(string code);

        Task<List<ZCFZ>> GetCaptialAndBillTable(string code, DateTime endTime);

        Task<List<ZCFZ>> GetCaptialAndBillTable(string code, int year);


        Task<List<LRB>> GetProfit(string code);

        Task<List<LRB>> GetProfit(string code, DateTime endTime);

        Task<List<LRB>> GetProfit(string code, int year);


        Task<List<XJLLB>> GetCash(string code);

        Task<List<XJLLB>> GetCash(string code, DateTime endTime);

        Task<List<XJLLB>> GetCash(string code, int year);
    }
}
