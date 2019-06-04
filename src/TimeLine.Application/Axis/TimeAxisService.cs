using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Dto;
using TimeLine.Axis.Filters;
using TimeLine.Axis.Lines;
using TimeLine.Service;

namespace TimeLine.Axis
{
    [AbpAuthorize]
    public class TimeAxisService : TimeLineAppServiceBase, ITimeAxisService
    {
        #region Fileds
        private readonly IAuthorityManager _authorityManager;
        private readonly ITimeAxisManager _timeAxisManager;
        private readonly IRepository<TimeAxis> _axisRepository;
        private readonly IRepository<TimeAxisFilter> _filterRepository;
        private readonly UserManager _userManager;
        #endregion

        #region Ctor
        public TimeAxisService(IAuthorityManager authorityManager,
            ITimeAxisManager timeAxisManager,
             UserManager userManager,
            IRepository<TimeAxis> axisRepository,
            IRepository<TimeAxisFilter> filterRepository)
        {
            _authorityManager = authorityManager;
            _timeAxisManager = timeAxisManager;
            _userManager = userManager;
            _axisRepository = axisRepository;
            _filterRepository = filterRepository;
        }
        #endregion

        public AxisDto GetAxis(EntityDto<int> input)
        {
            var entity = _axisRepository.Get(input.Id);

            if (!_authorityManager.HasAuthority(AbpSession.GetUserId(), entity, AuthorityType.View))
                Throw403Error();

            return Mapper.Map<AxisDto>(entity);
        }

        public ListResultDto<AxisDto> GetAxes(PagedResultRequestDto input)
        {
            int take = input.MaxResultCount > 50 || input.MaxResultCount <= 0 ? 10 : input.MaxResultCount,
                skip = input.SkipCount > 0 ? input.SkipCount : 0;
            
            var lines = _timeAxisManager.FilterVisibleTimeAxes(_axisRepository.GetAll())
                                        .OrderByDescending(x => x.CreationTime)
                                        .Skip(skip).Take(take);

            var users = _userManager.Users.Join(lines, x => x.Id, y => y.CreatorUserId,
                (x, y) => new { item = y, x.Name }).ToList();
            var result = users.Select(x =>
            {
                var data = Mapper.Map<AxisDto>(x.item);
                return Mapper.Map(x.Name, data);
            }).ToList();

            return new ListResultDto<AxisDto>(result);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<AxisDto> CreateTimeAxis(CreateAxisDto input)
        {
            var entity = Mapper.Map<TimeAxis>(input);
            var user = await GetCurrentUserAsync();
            _authorityManager.AssignAllTo(user, entity);
            var id = _axisRepository.InsertAndGetId(entity);

            return Mapper.Map<AxisDto>(_axisRepository.Get(id));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateTimeAxis(AxisDto input)
        {
            var entity = await _axisRepository.GetAsync(input.Id);

            if (!_authorityManager.HasAuthority(AbpSession.GetUserId(), entity, AuthorityType.EditItem))
                Throw403Error();

            Mapper.Map(input, entity);
            _axisRepository.Update(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        public void DeleteTimeAxis(EntityDto<int> input)
        {
            var entity = _axisRepository.Get(input.Id);

            if (!_authorityManager.HasAuthority(AbpSession.GetUserId(), entity, AuthorityType.DeleteItem))
                Throw403Error();

            _axisRepository.Delete(entity);
        }

        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task AssignAuthority(AssignAuthDto input)
        {
            var axis = _axisRepository.Get(input.Id);
            var user = await GetCurrentUserAsync();

            if (!_authorityManager.IsCreatedUser(user, axis))
                Throw403Error();

            var auth = Mapper.Map<TimeAxisAuthority>(input);
            _authorityManager.AssignTo(user, axis, auth);
        }

        /// <summary>
        /// 得到用户的权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ListResultDto<string> GetAssignAuthority(EntityDto<int> input)
        {
            var axis = _axisRepository.Get(input.Id);
            var auth = axis.GetAuthorities(AbpSession.GetUserId());
            return new ListResultDto<string>(Mapper.Map<List<string>>(auth));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AxisItemDto>> GetItems(AxisItemSearchDto input)
        {
            var filter = Mapper.Map<TimeAxisFilter>(input);
            var user = await GetCurrentUserAsync();
            var line = _axisRepository.Get(input.AxisId);

            var entity = _filterRepository.GetAll()
                        .Where(x => x.User.Id == user.Id && x.TimeAxis.Id == input.AxisId)
                        .FirstOrDefault();

            if (filter.HasAnyFilters())
            {
                Mapper.Map(filter, entity);
                _filterRepository.InsertOrUpdate(entity);
            }

            var data = _timeAxisManager.FilterTimeAxisItems(line, entity);
            data = line.Order(data);
            var result = Mapper.Map<IEnumerable<AxisItemDto>>(data);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public AxisItemDto CreateItem(CreateItemDto input)
        {
            var entity = Mapper.Map<TimeAxisItem>(input);
            var line = _axisRepository.Get(input.AxisId);

            if (!_authorityManager.HasAuthority(AbpSession.GetUserId(), line, AuthorityType.AddItem))
                Throw403Error();

            line.AddItem(entity);
            UnitOfWorkManager.Current.SaveChanges();

            return Mapper.Map<AxisItemDto>(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public void UpdateItem(UpdateAxisItemDto input)
        {
            var line = _axisRepository.Get(input.AxisId);

            if (!_authorityManager.HasAuthority(AbpSession.GetUserId(), line, AuthorityType.EditItem))
                Throw403Error();

            var item = line.GetItemById(input.Id);
            Mapper.Map(input, item);
        }
    }
}
