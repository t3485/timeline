using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Authorization.Users;
using TimeLine.Plans.Dto;
using System.Linq;
using TimeLine.Repository;

namespace TimeLine.Plans
{
    [AbpAuthorize]
    public class PlanService : TimeLineAppServiceBase, IPlanService
    {
        #region Fileds
        private readonly IRepository<PlanWeek> _planWeekRepository;
        private readonly IRepository<PlanComplete> _planCompleteRepository;
        private readonly UserManager _userManager;
        private readonly ICacheManager _cacheManager;
        private readonly IPlanRepository _planAwardRepository;
        #endregion

        #region Ctor
        public PlanService(IRepository<PlanComplete> planCompleteRepository,
            IPlanRepository planAwardRepository,
            UserManager userManager,
            IRepository<PlanWeek> planWeekRepository,
            ICacheManager cacheManager)
        {
            _planCompleteRepository = planCompleteRepository;
            _planWeekRepository = planWeekRepository;
            _userManager = userManager;
            _planAwardRepository = planAwardRepository;
            _cacheManager = cacheManager;
        }
        #endregion

        #region Week plan

        public PlanWeekDto GetPlanWeek(EntityDto<int> input)
        {
            var entity = _planWeekRepository.Get(input.Id);

            return Mapper.Map<PlanWeekDto>(entity);
        }

        public ListResultDto<PlanWeekDto> GetManyPlanWeek(QueryPlanDto input)
        {
            var plans = _planWeekRepository.GetAll()
                .Skip(input.SkipCount).Take(input.MaxResultCount);

            var complete = _planCompleteRepository.GetAllList(x => x.Time == input.Time);

            var result = Mapper.Map<List<PlanWeekDto>>(plans);

            foreach (var item in result)
            {
                item.Status = complete.Find(x => x.PlanWeek.Id == item.Id)?.Status ?? PlanCompleteStatus.Wating;                 
            }

            return new ListResultDto<PlanWeekDto>(result);
        }

        public PlanWeekDto CreateWeekPlan(CreatePlanWeekDto input)
        {
            var entity = Mapper.Map<PlanWeek>(input);
            var id = _planWeekRepository.InsertAndGetId(entity);

            return Mapper.Map<PlanWeekDto>(_planWeekRepository.Get(id));
        }
        #endregion

        #region plan Completion
        public PlanCompleteDto GetPlanComplete(EntityDto<int> input)
        {
            var entity = _planCompleteRepository.Get(input.Id);

            return Mapper.Map<PlanCompleteDto>(entity);
        }

        public PagedResultDto<PlanCompleteDto> GetManyPlanComplete(PagedResultRequestDto input)
        {
            var lines = _planCompleteRepository.GetAll()
                .Skip(input.SkipCount).Take(input.MaxResultCount);

            var result = Mapper.Map<List<PlanCompleteDto>>(lines);

            return new PagedResultDto<PlanCompleteDto>(0, result);
        }

        public async Task<PlanAwardDto> CreateCompletePlan(CreatePlanCompleteDto input)
        {
            var user = await GetCurrentUserAsync();
            var plan = _planWeekRepository.Get(input.PlanId);

            var entity = Mapper.Map<PlanComplete>(plan);
            entity.User = user;
            entity.CompleteTime = DateTimeOffset.Now;
            entity.Time = DateTimeOffset.Now.Date;
            _planCompleteRepository.InsertAndGetId(entity);

            var award = _planAwardRepository.CompletePlan(entity);

            return Mapper.Map<PlanAwardDto>(award);
        }
        #endregion

        public PlanAwardDto GetPlanAward(EntityDto<int> input)
        {
            var entity = _planAwardRepository.Single(x => x.User.Id == input.Id);

            return Mapper.Map<PlanAwardDto>(entity);
        }

        public PlanAwardDto SpendAward()
        {

            return null;
        }
    }
}
