using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeLine.Infrustruct;
using TimeLine.Reports.Dto;
using TimeLine.Reports.Tables;

namespace TimeLine.Reports
{
    public class CustomReportService : ICustomReportService
    {
        private IStringAnylize _stringAnylize;
        private ITypeHelper _typeHelper;
        private IEnumerable<ZCFZ> _bill;
        private IEnumerable<LRB> _profit;
        private IEnumerable<XJLLB> _cash;

        private const string DefaultTable = "xjll";

        public CustomReportService(IStringAnylize stringAnylize,
            ITypeHelper typeHelper)
        {
            _stringAnylize = stringAnylize;
            _typeHelper = typeHelper;
        }

        public void SetZcfzData(IEnumerable<ZCFZ> data)
        {
            _bill = data;
        }

        public void SetZcfzData(IEnumerable<LRB> data)
        {
            _profit = data;
        }

        public void SetZcfzData(IEnumerable<XJLLB> data)
        {
            _cash = data;
        }

        private CartDetailDto GetCartByExperssion(Queue<string> queue)
        {
            Stack<string> variable = new Stack<string>();
            IEnumerable<float?> computedVar = null;
            string s;

            while (queue.Count > 0)
            {
                s = queue.Dequeue();
                if (_stringAnylize.IsOperation(s))
                {
                    if (computedVar == null)
                    {
                        var v2 = GetCartData();
                    }
                }
                else
                {
                    variable.Push(s);
                }
            }
        }

        private IEnumerable<decimal?> GetCartData(string e)
        {
            IEnumerable<decimal?> result = null;
            if (e.Contains('.'))
            {
                var field = GetCartName(e);

                switch (field.Item1.ToLower())
                {
                    case "zcfz":
                        var d = _typeHelper.GetPropertyAccess<ZCFZ, string>(field.Item2);
                        result = _bill.Select(d).Select(x => string.IsNullOrEmpty(x) ? null : (decimal?)Convert.ToDecimal(x));
                        break;
                    case "lr":
                        var lrd = _typeHelper.GetPropertyAccess<LRB, string>(field.Item2);
                        result = _profit.Select(lrd).Select(x => string.IsNullOrEmpty(x) ? null : (decimal?)Convert.ToDecimal(x));
                        break;
                    case "xjll":
                        var xjlld = _typeHelper.GetPropertyAccess<XJLLB, string>(field.Item2);
                        result = _cash.Select(xjlld).Select(x => string.IsNullOrEmpty(x) ? null : x == null ? null : (decimal?)Convert.ToDecimal(x));
                        break;
                }
            }

            return result ?? new List<decimal?>();
        }

        private Tuple<string, string> GetCartName(string e)
        {
            if (e != null && e.Contains('.'))
            {
                var f = e.Split('.');

                return new Tuple<string, string>(f[0], f[1]);
            }
            return new Tuple<string, string>(DefaultTable, e);
        }
    }
}
