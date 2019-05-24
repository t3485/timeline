using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TimeLine.Configuration.Dto;

namespace TimeLine.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TimeLineAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
