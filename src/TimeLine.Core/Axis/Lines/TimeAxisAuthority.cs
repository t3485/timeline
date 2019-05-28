using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization.Users;

namespace TimeLine.Axis.Lines
{
    public class TimeAxisAuthority : Entity
    {
        public virtual TimeAxis TimeAxis { get; private set; }

        public virtual AuthorityType AuthorityType { get; private set; }

        public virtual User User { get; private set; }

        public TimeAxisAuthority() {  }

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
