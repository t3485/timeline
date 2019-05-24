using System.Threading.Tasks;
using TimeLine.Configuration.Dto;

namespace TimeLine.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
