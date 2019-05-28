using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using TimeLine.Axis.Filters;
using TimeLine.Axis.Lines;

namespace TimeLine.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public virtual ICollection<TimeAxisAuthority> TimeAxisAuthorities { get; private set; }

        public virtual ICollection<TimeAxisFilter> TimeAxisFilters { get; private set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>(),
                TimeAxisAuthorities = new List<TimeAxisAuthority>(),
                TimeAxisFilters = new List<TimeAxisFilter>()
            };

            user.SetNormalizedNames();

            return user;
        }

        #region Auth
        public void AddAuth(TimeAxisAuthority e)
        {
            if (TimeAxisAuthorities == null)
                TimeAxisAuthorities = new List<TimeAxisAuthority>();
            TimeAxisAuthorities.Add(e);
        }

        public void RemoveAuth(TimeAxisAuthority e)
        {
            if (TimeAxisAuthorities == null)
                TimeAxisAuthorities = new List<TimeAxisAuthority>();
            TimeAxisAuthorities.Remove(e);
        }
        #endregion
    }
}
