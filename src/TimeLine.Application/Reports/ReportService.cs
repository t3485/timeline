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
using TimeLine.Infrustruct;

namespace TimeLine.Reports
{
    public class ReportService : TimeLineAppServiceBase, IReportService
    {
        private IRequestsService _requestsService;
        private ITableRepository _tableRepository;
        private IReportManager _reportManager;
        private ITypeHelper _typeHelper;

        public ReportService(IRequestsService requestsService,
            ITableRepository tableRepository,
            IReportManager reportManager,
            ITypeHelper typeHelper)
        {
            _requestsService = requestsService;
            _tableRepository = tableRepository;
            _reportManager = reportManager;
            _typeHelper = typeHelper;
        }

        public async Task<CartDto> GetCart(CartSearchDto input)
        {
            var result = new CartDto();

            switch (input.Type)
            {
                case "1":
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
                    break;
                case "2":
                    cash = (await _reportManager.GetXJLLBs(input.Code)).OrderBy(x => x.REPORTDATE);
                    profit = (await _reportManager.GetLRBs(input.Code)).OrderBy(x => x.REPORTDATE);

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
                    break;
                case "3":
                    cash = (await _reportManager.GetXJLLBs(input.Code)).OrderBy(x => x.REPORTDATE);
                    var bill = (await _reportManager.GetZCFZs(input.Code)).OrderBy(x => x.REPORTDATE);
                    profit = (await _reportManager.GetLRBs(input.Code)).OrderBy(x => x.REPORTDATE);

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
                    break;
                default:
                    cash = (await _reportManager.GetXJLLBs(input.Code)).OrderBy(x => x.REPORTDATE);
                    bill = (await _reportManager.GetZCFZs(input.Code)).OrderBy(x => x.REPORTDATE);
                    profit = (await _reportManager.GetLRBs(input.Code)).OrderBy(x => x.REPORTDATE);
                    var list = new List<CartDetailDto>();

                    foreach (var type in input.Type.Split(','))
                    {
                        if (type.Contains('.'))
                        {
                            var field = type.Split('.');

                            switch (field[0].ToLower())
                            {
                                case "zcfz":
                                    var d = _typeHelper.GetPropertyAccess<ZCFZ, string>(field[1]);
                                    list.Add(new CartDetailDto
                                    {
                                        Data = bill.Select(d).Select(x => Convert.ToDecimal(x)),
                                        Name = _typeHelper.GetPropertyDescribe<ZCFZ>(field[1])
                                    });
                                    break;
                                case "lr":
                                    var lrd = _typeHelper.GetPropertyAccess<LRB, string>(field[1]);
                                    list.Add(new CartDetailDto
                                    {
                                        Data = profit.Select(lrd).Select(x => Convert.ToDecimal(x)),
                                        Name = _typeHelper.GetPropertyDescribe<LRB>(field[1])
                                    });
                                    break;
                                case "xjll":
                                    var xjlld = _typeHelper.GetPropertyAccess<XJLLB, string>(field[1]);
                                    list.Add(new CartDetailDto
                                    {
                                        Data = cash.Select(xjlld).Select(x => Convert.ToDecimal(x)),
                                        Name = _typeHelper.GetPropertyDescribe<XJLLB>(field[1])
                                    });
                                    break;
                            }
                        }
                    }
                    result.Cart = list;
                    if (result.Cart.Count() > 0)
                    {
                        result.Date = cash.Select(x => x.REPORTDATE);
                    }
                    break;
            }

            return result;
        }
    }
}