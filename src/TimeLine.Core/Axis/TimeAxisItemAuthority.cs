using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization.Users;

namespace TimeLine.Axis
{
    public class TimeAxisItemAuthority : Entity
    {
        public string AuthorizeType { get; private set; }

        public TimeAxisItem TimeAxisItem { get; private set; }

        public User User { get; private set; }

        public TimeAxisItemAuthority()
        {
        }
    }
}
