using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.EntityFrameworkCore;
using TimeLine.Reports;
using TimeLine.Repository;

namespace TimeLine.EntityFrameworkCore.Repositories
{
    public class TableRepository : TimeLineRepositoryBase<TableData>, ITableRepository
    {
        public TableRepository(IDbContextProvider<TimeLineDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public List<TableData> GetCaptialAndBillTable(string code)
        {
            return GetAll().Where(x => x.Code == code && x.TableType == ReportTableType.ZCFZB).ToList();
        }

        public List<TableData> GetProfitTable(string code)
        {
            return GetAll().Where(x => x.Code == code && x.TableType == ReportTableType.LRB).ToList();
        }

        public List<TableData> GetCash(string code)
        {
            return GetAll().Where(x => x.Code == code && x.TableType == ReportTableType.XJLLB).ToList();
        }

        public void InsertAllCaptialAndBillTable(IEnumerable<TableData> data)
        {
            foreach (var item in data)
            {
                item.TableType = ReportTableType.ZCFZB;
                Insert(item);
            }
        }

        public void InsertAllCash(IEnumerable<TableData> data)
        {
            foreach (var item in data)
            {
                item.TableType = ReportTableType.XJLLB;
                Insert(item);
            }
        }

        public void InsertAllProfit(IEnumerable<TableData> data)
        {
            foreach (var item in data)
            {
                item.TableType = ReportTableType.LRB;
                Insert(item);
            }
        }
    }
}
