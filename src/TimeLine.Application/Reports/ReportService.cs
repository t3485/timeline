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
                result.Cart = new List<CartDetailDto>
                {
                    new CartDetailDto
                    {
                         Data = cash.Select(x => Convert.ToDecimal(x.NETOPERATECASHFLOW)),
                         Name = "经营现金流净额"
                    },
                    new CartDetailDto
                    {
                         Data = profit.Select(x => Convert.ToDecimal(x.NETPROFIT)),
                         Name = "净利润"
                    }
                };
            }
            else if (input.Type == "2")
            {
                var cash = (await _reportManager.GetXJLLBs(input.Code)).OrderBy(x => x.REPORTDATE);
                var profit = (await _reportManager.GetLRBs(input.Code)).OrderBy(x => x.REPORTDATE);

                result.Date = cash.Select(x => x.REPORTDATE);
                result.Cart = new List<CartDetailDto>
                {
                    new CartDetailDto
                    {
                         Data = cash.Select(x => Convert.ToDecimal(x.SALEGOODSSERVICEREC)),
                         Name = "销售商品、提供劳务收到的现金"
                    },
                    new CartDetailDto
                    {
                         Data = profit.Select(x => Convert.ToDecimal(x.OPERATEREVE)),
                         Name = "营业收入"
                    }
                };
            }
            else if (input.Type == "3")
            {
                var cash = (await _reportManager.GetXJLLBs(input.Code)).OrderBy(x => x.REPORTDATE);
                var bill = (await _reportManager.GetZCFZs(input.Code)).OrderBy(x => x.REPORTDATE);
                var profit = (await _reportManager.GetLRBs(input.Code)).OrderBy(x => x.REPORTDATE);

                result.Date = cash.Select(x => x.REPORTDATE);
                result.Cart = new List<CartDetailDto>
                {
                    new CartDetailDto
                    {
                         Data = bill.Select(x => Convert.ToDecimal(x.MONETARYFUND)),
                         Name = "现金余额"
                    },
                    new CartDetailDto
                    {
                         Data = cash.Select(x => Convert.ToDecimal(x.SUMINVFLOWOUT)),
                         Name = "投资支出"
                    },
                    new CartDetailDto
                    {
                         Data = cash.Select(x => Convert.ToDecimal(x.SUMINVFLOWOUT)),
                         Name = "有息负债"
                    }
                };
            }

            return result;
        }
    }
}