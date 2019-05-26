using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization.Users;

namespace TimeLine.Axis.Lines
{
    public class TimeAxisAuthority : Entity
    {
        public TimeAxis TimeAxis { get; private set; }

        public AuthorityType AuthorityType { get; private set; }

        public User User { get; private set; }

        private TimeAxisAuthority() {  }

        public TimeAxisAuthority(AuthorityType type)
        {
            AuthorityType = type;
        }

        public TimeAxisAuthority(User user, AuthorityType type)
        {
            User = user;
            AuthorityType = type;
        }
    }
}
