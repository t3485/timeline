using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization.Users;

namespace TimeLine.Axis
{
    public class TimeAxisFilter : AggregateRoot
    {
        public int? MaxPage { get; private set; }

        public int? MinPage { get; private set; }

        public DateTime? MaxDate { get; private set; }

        public DateTime? MinDate { get; private set; }

        public TimeAxis TimeAxis { get; private set; }

        public User User { get; private set; }
    }
}
