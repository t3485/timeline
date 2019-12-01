using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Net;
using TimeLine.Reports.Dto;
using System.Linq;
using TimeLine.Service;
using AutoMapper;
using TimeLine.Repository;

namespace TimeLine.Reports
{
    public class ReportService : TimeLineAppServiceBase, IReportService
    {
        private IRequestsService _requestsService;
        private ITableRepository _tableRepository;
        private IReportManager _reportManager;

        public ReportService(IRequestsService requestsService,
            ITableRepository tableRepository,
            IReportManager reportManager)
        {
            _requestsService = requestsService;
            _tableRepository = tableRepository;
            _reportManager = reportManager;
        }

        public async Task<CartDto> GetCart(CartSearchDto input)
        {
            var result = new CartDto();

            if (input.Type == "1")
            {
                var cash = (await _reportManager.GetXJLLBs(input.Code)).OrderBy(x => x.REPORTDATE);
                var profit = (await _reportManager.GetLRBs(input.Code)).OrderBy(x => x.REPORTDATE);

                result.Date = cash.Select(x => x.REPORTDATE);
                result.A = cash.Select(x => Convert.ToDecimal(x.NETOPERATECASHFLOW));
                result.B = profit.Select(x => Convert.ToDecimal(x.NETPROFIT));
                result.AName = "经营现金流净额";
                result.BName = "净利润";
            }

            return result;
        }
    }
}
