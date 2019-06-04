using Abp.FluentValidation;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine
{
    [DependsOn(typeof(AbpFluentValidationModule))]
    public class ValidationModule: AbpModule
    {
        public override void PreInitialize()
        {
        }
    }
}
