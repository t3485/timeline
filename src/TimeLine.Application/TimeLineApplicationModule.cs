using Abp.AutoMapper;
using Abp.FluentValidation;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Json;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using TimeLine.Authorization;

namespace TimeLine
{
    [DependsOn(
        typeof(TimeLineCoreModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpFluentValidationModule))]
    public class TimeLineApplicationModule : AbpModule
    {
        private IHostingEnvironment _hostingEnvironment;

        public TimeLineApplicationModule(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TimeLineAuthorizationProvider>();

            Configuration.Caching.Configure("PermanentCache", cache =>
            {
                cache.DefaultSlidingExpireTime = System.TimeSpan.MaxValue;
            });

            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    "local",
                    new JsonFileLocalizationDictionaryProvider(
                        Path.Combine(_hostingEnvironment.ContentRootPath, "Localization")
                        )
                    )
                );
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
