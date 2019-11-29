﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Reports
{
    public class TableData : AggregateRoot<int>
    {
        public DateTime ReportTime { get; private set; }

        public string Code { get; private set; }

        public string Json { get; private set; }

        public int MinPage { get; private set; }

        public string Descript { get; private set; }

        public string Content { get; private set; }

        public string ImgPath { get; private set; }
    }
}