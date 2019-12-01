using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Reports;

namespace TimeLine.Repository
{
    public interface ITableRepository : IRepository<TableData>
    {
        List<TableData> GetCaptialAndBillTable(string code);

        void InsertAllCaptialAndBillTable(IEnumerable<TableData> data);

        void InsertAllProfit(IEnumerable<TableData> data);

        void InsertAllCash(IEnumerable<TableData> data);

        List<TableData> GetProfitTable(string code);

        List<TableData> GetCash(string code);
    }
}
