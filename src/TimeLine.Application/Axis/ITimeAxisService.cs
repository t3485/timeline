using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Axis.Dto;

namespace TimeLine.Axis
{
    public interface ITimeAxisService : IApplicationService, ITransientDependency
    {
        AxisDto GetAxis(EntityDto<int> input);

        Task<AxisDto> CreateTimeAxis(CreateAxisDto input);

        Task UpdateTimeAxis(AxisDto input);

        void DeleteTimeAxis(EntityDto<int> input);

        Task AssignAuthority(AssignAuthDto input);

        ListResultDto<string> GetAssignAuthority(EntityDto<int> input);

        Task<IEnumerable<AxisItemDto>> GetItems(AxisItemSearchDto input);
    }
}
