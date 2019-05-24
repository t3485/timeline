using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TimeLine.Roles.Dto;
using TimeLine.Users.Dto;

namespace TimeLine.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
