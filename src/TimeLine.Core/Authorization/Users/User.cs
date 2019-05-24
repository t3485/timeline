using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using TimeLine.Axis;

namespace TimeLine.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public virtual ICollection<TimeAxisAuthority> TimeAxisAuthorities { get; private set; }

        public virtual ICollection<TimeAxisItemAuthority> TimeAxisItemAuthorities { get; private set; }

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
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
