using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TimeLine.Controllers
{
    public abstract class TimeLineControllerBase: AbpController
    {
        protected TimeLineControllerBase()
        {
            LocalizationSourceName = TimeLineConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
