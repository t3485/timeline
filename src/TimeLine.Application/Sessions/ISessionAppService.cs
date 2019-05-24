using System.Threading.Tasks;
using Abp.Application.Services;
using TimeLine.Sessions.Dto;

namespace TimeLine.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
