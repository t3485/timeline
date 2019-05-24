using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace TimeLine.Localization
{
    public static class TimeLineLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TimeLineConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TimeLineLocalizationConfigurer).GetAssembly(),
                        "TimeLine.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
