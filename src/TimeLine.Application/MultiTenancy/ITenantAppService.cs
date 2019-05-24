using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TimeLine.MultiTenancy.Dto;

namespace TimeLine.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

