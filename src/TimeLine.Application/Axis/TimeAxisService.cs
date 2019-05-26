using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using AutoMapper;
using System.Threading.Tasks;
using TimeLine.Axis.Dto;
using TimeLine.Axis.Lines;
using TimeLine.Service;

namespace TimeLine.Axis
{
    [AbpAuthorize]
    public class TimeAxisService: TimeLineAppServiceBase, ITimeAxisService
    {
        private readonly IAuthorityManager _authorityManager;
        private readonly IRepository<TimeAxis> _axisRepository;

        public TimeAxisService(IAuthorityManager authorityManager,
            IRepository<TimeAxis> axisRepository)
        {
            _authorityManager = authorityManager;
            _axisRepository = axisRepository;
        }

        public void CreateTimeAxis(CreateAxisDto input)
        {
            var entity = Mapper.Map<TimeAxis>(input);

            _axisRepository.Insert(entity);
        }

        public async Task UpdateTimeAxis(AxisDto input)
        {
            var entity = await _axisRepository.GetAsync(input.Id);

            if (_authorityManager.HasAuthority(AbpSession.GetUserId(), entity, AuthorityType.EditItem))
                throw new AbpAuthorizationException();

            Mapper.Map(input, entity);
            _axisRepository.Update(entity);
        }

        public void DeleteTimeAxis(EntityDto<int> input)
        {
            var entity = _axisRepository.Get(input.Id);

            if (_authorityManager.HasAuthority(AbpSession.GetUserId(), entity, AuthorityType.DeleteItem))
                throw new AbpAuthorizationException();

            _axisRepository.Delete(entity);
        }

        public async Task AssignAuthority(AssignAuthDto input)
        {
            var axis = _axisRepository.Get(input.Id);
            var user = await GetCurrentUserAsync();

            if (_authorityManager.IsCreatedUser(user, axis))
                throw new AbpAuthorizationException();

            var auth = Mapper.Map<TimeAxisAuthority>(input);
            _authorityManager.AssignTo(user, axis, auth);
        }
    }
}
