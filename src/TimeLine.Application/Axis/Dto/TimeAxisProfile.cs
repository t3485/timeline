using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Filters;
using TimeLine.Axis.Lines;
using TimeLine.Extensions;

namespace TimeLine.Axis.Dto
{
    public class TimeAxisProfile : Profile
    {
        public TimeAxisProfile()
        {
            CreateMap<CreateAxisDto, TimeAxisAuthority>();

            CreateMap<AxisDto, TimeAxis>()
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.TimeAxisAuthority, opt => opt.Ignore())
                .ForMember(x => x.Items, opt => opt.Ignore());

            CreateMap<TimeAxis, AxisDto>()
                .ForMember(x => x.Creator, opt => opt.MapFrom(y => y.User.Name))
                .ForMember(x => x.Authorities,
                    opt => opt.MapFrom(y => y.TimeAxisAuthority
                            .OrderBy(x => (int)x.AuthorityType)
                            .Join(exp => EnumUtils<AuthorityType>.GetEnumDescript(exp.AuthorityType))))
                .ForMember(x => x.AuthorityList, opt => opt.MapFrom(y => y.TimeAxisAuthority.Select(z => z.AuthorityType)));


            CreateMap<CreateAxisDto, TimeAxis>();

            CreateMap<AuthorityType, string>().ConvertUsing(x => x.ToString());

            CreateMap<CreateItemDto, TimeAxisItem>();
            CreateMap<AxisItemDto, TimeAxisItem>();
            CreateMap<TimeAxisItem, AxisItemDto>();

            //更新
            CreateMap<UpdateAxisItemDto, TimeAxisItem>()
                .ForMember(x => x.TimeAxis, opt => opt.Ignore());

            //列表
            CreateMap<AxisItemSearchDto, TimeAxisFilter>()
                .ForMember(x => x.MaxDate, opt => opt.MapFrom(x => x.EndTime))
                .ForMember(x => x.MinDate, opt => opt.MapFrom(x => x.StartTime));

            CreateMap<TimeAxisFilter, TimeAxisFilter>()
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.TimeAxis, opt => opt.Ignore());

            CreateMap<User, UserAuthDto>()
                .ForMember(x => x.UID, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.Authority, opt => opt.MapFrom(y => y.TimeAxisAuthorities.Select(z => z.AuthorityType.ToString())));
        }
    }
}