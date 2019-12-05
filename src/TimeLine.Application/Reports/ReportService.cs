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
using TimeLine.Reports.Tables;

namespace TimeLine.Reports
{
    public class ReportService : TimeLineAppServiceBase, IReportService
    {
        private IRequestsService _requestsService;
        private ITableRepository _tableRepository;
        private IReportManager _reportManager;
        private ITypeHelper _typeHelper;
        private IStringAnylize _stringAnylize;

        public ReportService(IRequestsService requestsService,
            ITableRepository tableRepository,
            IReportManager reportManager,
            ITypeHelper typeHelper,
            IStringAnylize stringAnylize)
        {
            _requestsService = requestsService;
            _tableRepository = tableRepository;
            _reportManager = reportManager;
            _typeHelper = typeHelper;
            _stringAnylize = stringAnylize;
        }

        public async Task<CartDto> GetCart(CartSearchDto input)
        {
            var result = new CartDto();

            var cash = (await _reportManager.GetXJLLBs(input.Code)).OrderBy(x => x.REPORTDATE);
            var bill = (await _reportManager.GetZCFZs(input.Code)).OrderBy(x => x.REPORTDATE);
            var profit = (await _reportManager.GetLRBs(input.Code)).OrderBy(x => x.REPORTDATE);
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
                                Data = bill.Select(d).Select(x => string.IsNullOrEmpty(x) ? null : (decimal?)Convert.ToDecimal(x)),
                                Name = _typeHelper.GetPropertyDescribe<ZCFZ>(field[1]),
                                FieldName = field[1]
                            });
                            break;
                        case "lr":
                            var lrd = _typeHelper.GetPropertyAccess<LRB, string>(field[1]);
                            list.Add(new CartDetailDto
                            {
                                Data = profit.Select(lrd).Select(x => string.IsNullOrEmpty(x) ? null : (decimal?)Convert.ToDecimal(x)),
                                Name = _typeHelper.GetPropertyDescribe<LRB>(field[1]),
                                FieldName = field[1]
                            });
                            break;
                        case "xjll":
                            var xjlld = _typeHelper.GetPropertyAccess<XJLLB, string>(field[1]);
                            list.Add(new CartDetailDto
                            {
                                Data = cash.Select(xjlld).Select(x => string.IsNullOrEmpty(x) ? null : x == null ? null : (decimal?)Convert.ToDecimal(x)),
                                Name = _typeHelper.GetPropertyDescribe<XJLLB>(field[1]),
                                FieldName = field[1]
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

            return result;
        }
    }
}