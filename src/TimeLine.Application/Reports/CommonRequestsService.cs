using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Reports;
using Newtonsoft.Json;
using Abp.Domain.Repositories;
using System.Linq;
using TimeLine.Service;

namespace TimeLine.Reports
{
    public class CommonRequestsService : IRequestsService
    {
        private IHttpClientFactory _factory;
        private IRepository<TableData> _tableRepository;
        private HttpClient _client;

        private string reportDataType;
        private string reportType;

        private const string zcfzb_url = "NewFinanceAnalysis/zcfzbAjax";
        private const string lrb_url = "NewFinanceAnalysis/lrbAjax";
        private const string xjllb_url = "NewFinanceAnalysis/xjllbAjax";



        public bool IsYear
        {
            get
            {
                return reportDataType == "1" && reportType == "1";
            }
        }

        public CommonRequestsService(IHttpClientFactory factory,
            IRepository<TableData> tableRepository)
        {
            _factory = factory;
            _tableRepository = tableRepository;

            reportDataType = reportType = "1";
        }

        public async Task<List<ZCFZ>> GetCaptialAndBillTable(string code, DateTime endTime)
        {
            var client = GetClient();
            var time = GetTimeString(endTime);

            var response = await client.GetAsync($"{zcfzb_url}?companyType=4&reportDateType={reportDataType}&reportType={reportType}&endDate={time}&code={code}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var data = DeserialzeList<ZCFZ>(result);

                foreach (var item in data)
                {
                    item.SECURITYCODE = code;
                }
                return data;
            }

            throw new Exception("请求错误");
        }

        public Task<List<ZCFZ>> GetCaptialAndBillTable(string code)
        {
            return GetCaptialAndBillTable(code, DateTime.Now);
        }


        public Task<List<ZCFZ>> GetCaptialAndBillTable(string code, int year)
        {
            return GetCaptialAndBillTable(code, new DateTime(year, 12, 31));
        }

        public async Task<List<LRB>> GetProfit(string code, DateTime endTime)
        {
            var client = GetClient();
            var time = GetTimeString(endTime);

            var response = await client.GetAsync($"{lrb_url}?companyType=4&reportDateType={reportDataType}&reportType={reportType}&endDate={time}&code={code}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return DeserialzeList<LRB>(result);
            }

            throw new Exception("请求错误");
        }

        public Task<List<LRB>> GetProfit(string code)
        {
            return GetProfit(code, DateTime.Now);
        }

        public Task<List<LRB>> GetProfit(string code, int year)
        {
            return GetProfit(code, new DateTime(year, 12, 31));
        }

        public async Task<List<XJLLB>> GetCash(string code, DateTime endTime)
        {
            var client = GetClient();
            var time = GetTimeString(endTime);

            var response = await client.GetAsync($"{xjllb_url}?companyType=4&reportDateType={reportDataType}&reportType={reportType}&endDate={time}&code={code}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return DeserialzeList<XJLLB>(result);
            }

            throw new Exception("请求错误");
        }

        public Task<List<XJLLB>> GetCash(string code)
        {
            return GetCash(code, DateTime.Now);
        }

        public Task<List<XJLLB>> GetCash(string code, int year)
        {
            return GetCash(code, new DateTime(year, 12, 31));
        }

        public void SetYear()
        {
            reportDataType = reportType = "1";
        }

        public void SetReport()
        {
            reportDataType = "0";
            reportType = "1";
        }

        private List<T> DeserialzeList<T>(string s)
        {
            if (s.Length >= 2 &&s[0] == '\"' && s[1] == '[')
            {
                var r1 = JsonConvert.DeserializeObject<TmpData>("{\"data\":" + s + "}");
                return JsonConvert.DeserializeObject<T[]>(r1.Data).ToList();
            }
            return new List<T>();
        }

        private HttpClient GetClient()
        {
            if (_client == null)
            {
                _client = _factory.CreateClient();
                _client.BaseAddress = new Uri("http://f10.eastmoney.com/");
                return _client;
            }

            return _client;
        }

        private string GetTimeString(DateTime time)
        {
            int year, month, day;
            int[] allMonth = { 3, 6, 9, 12, 12 },
                allDay = { 31, 30, 30, 31, 31 };

            year = time.Year;

            if (IsYear)
            {
                month = allMonth[3];
                day = allDay[3];
            }
            else
            {
                int index = time.Month / 3;
                month = allMonth[index];
                day = allDay[index];
            }

            return $"{year}/{month}/{day}";
        }

        internal class TmpData
        {
            public string Data { get; set; }
        }
    }
}
