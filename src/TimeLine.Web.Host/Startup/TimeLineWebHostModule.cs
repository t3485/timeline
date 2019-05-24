using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TimeLine.Configuration;

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

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TimeLineWebHostModule).GetAssembly());
        }
    }
}
