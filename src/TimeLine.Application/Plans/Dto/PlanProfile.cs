using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Plans.Dto
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<PlanWeek, PlanWeekDto>();
            CreateMap<CreatePlanWeekDto, PlanWeek>();


            CreateMap<PlanComplete, PlanCompleteDto>();
            CreateMap<PlanWeek, PlanComplete>()
                .ForMember(x => x.PlanCompleteCopy, opt => opt.MapFrom(x => x))
                .ForMember(x => x.PlanWeek, opt => opt.MapFrom(x => x));


            CreateMap<PlanAward, PlanAwardDto>();
        }
    }
}
