using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Reports.Dto;
using TimeLine.Reports.Tables;

namespace TimeLine.Reports
{
    public interface ICustomReportService : ITransientDependency
    {
        CartDetailDto GetCartByExperssion(Queue<string> queue);

        void SetData(IEnumerable<ZCFZ> data);

        void SetData(IEnumerable<LRB> data);

        void SetData(IEnumerable<XJLLB> data);
    }
}
