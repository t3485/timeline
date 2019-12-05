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
        private ICustomReportService _customReportService;

        public ReportService(IRequestsService requestsService,
            ITableRepository tableRepository,
            IReportManager reportManager,
            ITypeHelper typeHelper,
            IStringAnylize stringAnylize,
            ICustomReportService customReportService)
        {
            _requestsService = requestsService;
            _tableRepository = tableRepository;
            _reportManager = reportManager;
            _typeHelper = typeHelper;
            _stringAnylize = stringAnylize;
            _customReportService = customReportService;
        }

        public async Task<CartDto> GetCart(CartSearchDto input)
        {
            var result = new CartDto();

            var cash = (await _reportManager.GetXJLLBs(input.Code)).OrderBy(x => x.REPORTDATE);
            var bill = (await _reportManager.GetZCFZs(input.Code)).OrderBy(x => x.REPORTDATE);
            var profit = (await _reportManager.GetLRBs(input.Code)).OrderBy(x => x.REPORTDATE);
            var list = new List<CartDetailDto>();

            _customReportService.SetData(bill);
            _customReportService.SetData(cash);
            _customReportService.SetData(profit);

            foreach (var type in input.Type.Split(','))
            {
                var exp = _stringAnylize.Middle2SuffixExp(type);
                var data = _customReportService.GetCartByExperssion(exp);
                if (string.IsNullOrWhiteSpace(_stringAnylize.Describe))
                    data.Name = _stringAnylize.Describe;
                list.Add(data);
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