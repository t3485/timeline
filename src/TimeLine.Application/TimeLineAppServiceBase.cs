﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using TimeLine.Authorization.Users;
using TimeLine.MultiTenancy;
using Abp.UI;

namespace TimeLine
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class TimeLineAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected TimeLineAppServiceBase()
        {
            LocalizationSourceName = TimeLineConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected virtual void Throw403Error()
        {            
            throw new UserFriendlyException("Forbidden");
        }

        protected virtual void ThrowNoDataError()
        {
            throw new UserFriendlyException("No Data");
        }
    }
}
