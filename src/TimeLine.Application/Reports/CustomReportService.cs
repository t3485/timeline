﻿using System;
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

        public void SetData(IEnumerable<ZCFZ> data)
        {
            _bill = data;
        }

        public void SetData(IEnumerable<LRB> data)
        {
            _profit = data;
        }

        public void SetData(IEnumerable<XJLLB> data)
        {
            _cash = data;
        }

        public CartDetailDto GetCartByExperssion(Queue<string> queue)
        {
            Stack<string> variable = new Stack<string>();
            CartDetailDto computedVar = null;
            string s, name = string.Empty;

            while (queue.Count > 0)
            {
                s = queue.Dequeue();
                if (_stringAnylize.IsOperation(s))
                {
                    if (computedVar == null)
                        computedVar = GetCartData(variable.Pop());

                    var v1 = GetCartData(variable.Pop());
                    computedVar.Data = Add(computedVar.Data, v1.Data);
                }
                else if (queue.Count == 0)
                {
                    computedVar = GetCartData(s);
                }
                else
                {
                    variable.Push(s);
                }
            }
            return computedVar;
        }

        private CartDetailDto GetCartData(string e)
        {
            CartDetailDto result = new CartDetailDto();
            if (e.Contains('.'))
            {
                var field = GetCartName(e);

                switch (field.Item1.ToLower())
                {
                    case "zcfz":
                        var d = _typeHelper.GetPropertyAccess<ZCFZ, string>(field.Item2);
                        result.Data = _bill.Select(d).Select(x => string.IsNullOrEmpty(x) ? 0 : Convert.ToDecimal(x));
                        result.Name = _typeHelper.GetPropertyDescribe<ZCFZ>(field.Item2);
                        break;
                    case "lr":
                        var lrd = _typeHelper.GetPropertyAccess<LRB, string>(field.Item2);
                        result.Data = _profit.Select(lrd).Select(x => string.IsNullOrEmpty(x) ? 0 : Convert.ToDecimal(x));
                        result.Name = _typeHelper.GetPropertyDescribe<LRB>(field.Item2);
                        break;
                    case "xjll":
                        var xjlld = _typeHelper.GetPropertyAccess<XJLLB, string>(field.Item2);
                        result.Data = _cash.Select(xjlld).Select(x => string.IsNullOrEmpty(x) ? 0 : Convert.ToDecimal(x));
                        result.Name = _typeHelper.GetPropertyDescribe<XJLLB>(field.Item2);
                        break;
                }
                result.FieldName = field.Item2;
            }

            return result;
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

        private IEnumerable<decimal> Add(IEnumerable<decimal> a, IEnumerable<decimal> b)
        {
            var v1 = (a.Count() > b.Count() ? a : b).ToList();
            var v2 = a.Count() > b.Count() ? b : a;


            for (int i = 0; i < v2.Count(); i++)
            {
                v1[i] += v2.ElementAt(i);
            }

            return v1;
        }
    }
}
