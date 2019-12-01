using Abp.Domain.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Reports;
using TimeLine.Repository;

namespace TimeLine.Service
{
    public class ReportManager : DomainService, IReportManager
    {
        private IRequestsService _requestsService;
        private ITableRepository _tableRepository;

        public ReportManager(IRequestsService requestsService,
            ITableRepository tableRepository)
        {
            _requestsService = requestsService;
            _tableRepository = tableRepository;
        }


        public List<int> GetLostYear(IEnumerable<DateTime> times, DateTime start)
        {
            List<int> lostDates = new List<int>();
            int year = start.Year, lastYear = int.MaxValue;

            if (year == DateTime.Now.Year)
                year -= 1;

            int batchNum = 6, startYear = 2004;

            foreach (var time in times.OrderByDescending(x => x))
            {
                if (time.Year < year && lastYear - batchNum > year)
                {
                    lostDates.Add(year + 1);
                    lastYear = year;
                    year -= batchNum;
                }
                else
                {
                    year = time.Year - 1;
                }
            }

            if (year >= startYear && lastYear - batchNum >= startYear)
            {
                if (lastYear != int.MaxValue)
                    year = lastYear - batchNum;

                for (; year >= startYear; year -= batchNum)
                {
                    lostDates.Add(year + 1);
                }
            }
            return lostDates;
        }

        public async Task<List<ZCFZ>> GetZCFZs(string code)
        {
            code = code.ToUpper();
            var table = _tableRepository.GetCaptialAndBillTable(code);

            var lost = GetLostYear(table.Select(x => x.ReportTime), DateTime.Now);
            var lostData = new List<ZCFZ>();

            foreach (var item in lost)
            {
                var data = await _requestsService.GetCaptialAndBillTable(code, item);
                lostData = lostData.Union(data, ZCFZComparer.Get()).ToList();
            }

            foreach (var item in lostData)
            {
                item.SECURITYCODE = code;
            }

            var _database = Mapper.Map<List<ZCFZ>>(table);

            lostData = lostData.Except(_database, ZCFZComparer.Get()).ToList();
            _tableRepository.InsertAllCaptialAndBillTable(Mapper.Map<List<TableData>>(lostData));

            return _database.Union(lostData).ToList();
        }

        public async Task<List<LRB>> GetLRBs(string code)
        {
            code = code.ToUpper();
            var table = _tableRepository.GetProfitTable(code);

            var lost = GetLostYear(table.Select(x => x.ReportTime), DateTime.Now);
            var lostData = new List<LRB>();

            foreach (var item in lost)
            {
                var data = await _requestsService.GetProfit(code, item);
                lostData = lostData.Union(data, LRBComparer.Get()).ToList();
            }

            foreach (var item in lostData)
            {
                item.SECURITYCODE = code;
            }

            var _database = Mapper.Map<List<LRB>>(table);

            lostData = lostData.Except(_database, LRBComparer.Get()).ToList();
            _tableRepository.InsertAllProfit(Mapper.Map<List<TableData>>(lostData));

            return _database.Union(lostData).ToList();
        }

        public async Task<List<XJLLB>> GetXJLLBs(string code)
        {
            code = code.ToUpper();
            var table = _tableRepository.GetCash(code);

            var lost = GetLostYear(table.Select(x => x.ReportTime), DateTime.Now);
            var lostData = new List<XJLLB>();

            foreach (var item in lost)
            {
                var data = await _requestsService.GetCash(code, item);
                lostData = lostData.Union(data, XJLLBComparer.Get()).ToList();
            }

            foreach (var item in lostData)
            {
                item.SECURITYCODE = code;
            }

            var _database = Mapper.Map<List<XJLLB>>(table);

            lostData = lostData.Except(_database, XJLLBComparer.Get()).ToList();
            _tableRepository.InsertAllCash(Mapper.Map<List<TableData>>(lostData));

            return _database.Union(lostData).ToList();
        }
    }
}
