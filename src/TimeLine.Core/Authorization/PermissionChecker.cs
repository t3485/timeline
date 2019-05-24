using Abp.Authorization;
using TimeLine.Authorization.Roles;
using TimeLine.Authorization.Users;

namespace TimeLine.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
