using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TimeLine.Configuration;
using Abp.AspNetCore.Configuration;
using TimeLine.Users;

namespace TimeLine.Web.Host.Startup
{
    [DependsOn(
       typeof(TimeLineWebCoreModule))]
    public class TimeLineWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TimeLineWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.IocManager.Resolve<IAbpAspNetCoreConfiguration>().UseMvcDateTimeFormatForAppServices = true;
        }

        public override void Initialize()
        {
            Configuration.Modules.AbpConfiguration.
            IocManager.RegisterAssemblyByConvention(typeof(TimeLineWebHostModule).GetAssembly());
        }
    }
}
