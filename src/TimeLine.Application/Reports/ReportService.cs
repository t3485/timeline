using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Net;
using TimeLine.Reports.Dto;

namespace TimeLine.Reports
{
    public class ReportService : TimeLineAppServiceBase, IReportService
    {
        private IRequestsService _requestsService;

        public ReportService(IRequestsService requestsService)
        {
            _requestsService = requestsService;
        }

        public async Task GetCaptialAndBill(CaptialSearchDto input)
        {
            var data = await _requestsService.GetCaptialAndBillTable(input.Code);


        }
    }
}
