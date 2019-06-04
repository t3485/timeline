using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Filters;
using TimeLine.Axis.Lines;

namespace TimeLine.Axis.Dto
{
    public class TimeAxisProfile : Profile
    {
        public TimeAxisProfile()
        {
            CreateMap<CreateAxisDto, TimeAxisAuthority>();

            CreateMap<AxisDto, TimeAxis>();

            CreateMap<TimeAxis, AxisDto>();
            CreateMap<string, AxisDto>()
                .ForMember(x => x.Creator, opt => opt.MapFrom(y => y));

            CreateMap<CreateAxisDto, TimeAxis>();

            CreateMap<AuthorityType, string>().ConvertUsing(x => x.ToString());
            CreateMap<AssignAuthDto, TimeAxisAuthority>()
                .ForMember(x => x.AuthorityType,
                    opt => opt.MapFrom(x => Enum.Parse(typeof(AuthorityType), x.AuthorizeType)));

            CreateMap<CreateItemDto, TimeAxisItem>();
            CreateMap<AxisItemDto, TimeAxisItem>();
            CreateMap<TimeAxisItem, AxisItemDto>();

            //更新
            CreateMap<UpdateAxisItemDto, TimeAxisItem>()
                .ForMember(x => x.TimeAxis, opt => opt.Ignore());

            //列表
            CreateMap<AxisItemSearchDto, TimeAxisFilter>();
        }
    }
}