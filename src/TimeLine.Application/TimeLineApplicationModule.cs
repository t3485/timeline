using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TimeLine.Authorization;

namespace TimeLine
{
    [DependsOn(
        typeof(TimeLineCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TimeLineApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TimeLineAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TimeLineApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
