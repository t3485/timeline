using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Reports;
using Newtonsoft.Json;
using Abp.Domain.Repositories;

namespace TimeLine.Reports
{
    public class CommonRequestsService : IRequestsService
    {
        private IHttpClientFactory _factory;
        private IRepository<TableData> _tableRepository;

        public CommonRequestsService(IHttpClientFactory factory,
            IRepository<TableData> tableRepository)
        {
            _factory = factory;
            _tableRepository = tableRepository;
        }

        public async Task<List<ZCFZ>> GetCaptialAndBillTable(string code)
        {
            var client = _factory.CreateClient();

            client.BaseAddress = new Uri("http://f10.eastmoney.com/");

            var response = await client.GetAsync($"NewFinanceAnalysis/zcfzbAjax?companyType=4&reportDateType=0&reportType=1&endDate=&code={code}");
            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var r1 = JsonConvert.DeserializeObject("{" + result + "}");

                return JsonConvert.DeserializeObject<List<ZCFZ>>(r1.ToString());
            }

            throw new Exception("请求错误");
        }

        public async Task 
    }
}
