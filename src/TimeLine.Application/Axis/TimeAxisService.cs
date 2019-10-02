using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Dto;
using TimeLine.Axis.Filters;
using TimeLine.Axis.Lines;
using TimeLine.Service;
using TimeLine.Extensions;
using Abp.Runtime.Caching;
using TimeLine.Repository;
using Abp.UI;

namespace TimeLine.Axis
{
    [AbpAuthorize]
    public class TimeAxisService : TimeLineAppServiceBase, ITimeAxisService
    {
        #region Fileds
        private readonly IAuthorityManager _authorityManager;
        private readonly ITimeAxisManager _timeAxisManager;
        private readonly ITimeAxisRepository _axisRepository;
        private readonly IRepository<TimeAxisFilter> _filterRepository;
        private readonly UserManager _userManager;
        private readonly ICacheManager _cacheManager;
        #endregion

        #region Ctor
        public TimeAxisService(IAuthorityManager authorityManager,
            ITimeAxisManager timeAxisManager,
             UserManager userManager,
            ITimeAxisRepository axisRepository,
            IRepository<TimeAxisFilter> filterRepository,
            ICacheManager cacheManager)
        {
            _authorityManager = authorityManager;
            _timeAxisManager = timeAxisManager;
            _userManager = userManager;
            _axisRepository = axisRepository;
            _filterRepository = filterRepository;
            _cacheManager = cacheManager;
        }
        #endregion
        
        #region TimeAxis

        public AxisDto GetAxis(EntityDto<int> input)
        {
            var entity = _axisRepository.Get(input.Id);

            if (!_authorityManager.HasAuthority(AbpSession.GetUserId(), entity, AuthorityType.View))
                Throw403Error();

            return Mapper.Map<AxisDto>(entity);
        }

        public async Task<ListResultDto<AxisDto>> GetAxes(PagedResultRequestDto input)
        {
            var user = await GetCurrentUserAsync();
            int take = input.MaxResultCount > 50 || input.MaxResultCount <= 0 ? 10 : input.MaxResultCount,
                skip = input.SkipCount > 0 ? input.SkipCount : 0;

            var lines = _axisRepository.GetAll(user, skip, take);

            var result = lines.Select(x => Mapper.Map<AxisDto>(x)).ToList();

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
            entity.SetCreatorUser(user);
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

        #endregion

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

            var targetUser = await _userManager.GetUserByIdAsync(input.UID);

            var auth = Mapper.Map<AuthorityType[]>(input.AuthorizeType);

            if (auth.Length == 0)
                ThrowNoDataError();

            foreach (var type in auth)
                _authorityManager.AssignTo(targetUser, axis, type);
        }

        public async Task RemoveAuthority(RemoveAuthorityDto input)
        {
            var auth = Mapper.Map<AuthorityType[]>(input.AuthorizeType.Split(','));
            if (auth.Length == 0)
                ThrowNoDataError();

            var axis = _axisRepository.Get(input.Id);
            var user = await GetCurrentUserAsync();

            if (!_authorityManager.IsCreatedUser(user, axis))
                Throw403Error();

            var targetUser = await _userManager.GetUserByIdAsync(input.UID);

            foreach (var type in auth)
                _authorityManager.AssignNo(targetUser, axis, type);
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
        /// 得到用户的权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ListResultDto<UserAuthDto>> GetAssignAuthorityOfUser(EntityDto<int> input)
        {
            var axis = _axisRepository.Get(input.Id);
            var user = await GetCurrentUserAsync();

            if (!_authorityManager.IsCreatedUser(user, axis))
                Throw403Error();

            var result = _axisRepository.GetAssignAuthorityOfUser(axis);

            return new ListResultDto<UserAuthDto>(Mapper.Map<List<UserAuthDto>>(result.ToList()));
        }

        public void Test()
        {
            _timeAxisManager.Test();
        }

        public ListResultDto<AxisAuthorityDto> GetAuthorityTypes()
        {
            return _cacheManager.GetPermanentCache().Get(nameof(GetAuthorityTypes),
                () =>
                {
                    var data = Enum.GetValues(typeof(AuthorityType));
                    List<AxisAuthorityDto> result = new List<AxisAuthorityDto>();

                    foreach (var item in data)
                    {
                        result.Add(EnumUtils<AuthorityType>.GetAxisAuthorityEnumDescript((AuthorityType)item));
                    }
                    result = result.OrderBy(x => x.Order).ToList();
                    return new ListResultDto<AxisAuthorityDto>(result);
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AxisItemDto>> GetItems(AxisItemSearchDto input)
        {
            var line = _axisRepository.Get(input.AxisId);

            if (!_authorityManager.HasAuthority(AbpSession.GetUserId(), line, AuthorityType.View))
                Throw403Error();

            var filter = Mapper.Map<TimeAxisFilter>(input);
            var user = await GetCurrentUserAsync();

            var entity = _filterRepository.GetAll()
                        .Where(x => x.User.Id == user.Id && x.TimeAxis.Id == input.AxisId)
                        .FirstOrDefault();

            if (filter.HasAnyFilters())
            {
                if (entity == null)
                    entity = new TimeAxisFilter();

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
