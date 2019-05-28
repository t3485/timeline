using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using TimeLine.Axis.Lines;

namespace TimeLine.Axis.Lines
{
    public class TimeAxisItem : CreationAuditedEntity
    {
        public DateTime? StartTime { get; private set; }

        public DateTime? EndTime { get; private set; }

        public int MaxPage { get; private set; }

        public int MinPage { get; private set; }

        public string Descript { get; private set; }

        public string Content { get; private set; }

        public string ImgPath { get; private set; }

        public virtual TimeAxis TimeAxis { get; private set; }

        public TimeAxisItem() { }

        public TimeAxisItem(string descript)
        {
            Descript = descript;
        }
    }
}