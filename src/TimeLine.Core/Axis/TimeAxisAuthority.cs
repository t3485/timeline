using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization.Users;

namespace TimeLine.Axis
{
    public class TimeAxisAuthority : Entity
    {
        public string AuthorizeType { get; private set; }

        public TimeAxis TimeAxis{ get; private set; }

        public User User { get; private set; }

        public TimeAxisAuthority()
        {

        }
    }
}
