using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Reports.Dto
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<TableData, ZCFZ>()
                .ConvertUsing(x => JsonConvert.DeserializeObject<ZCFZ>(x.Json));
            CreateMap<ZCFZ, TableData>()
                .ForMember(x => x.Json, opt => opt.MapFrom(x => JsonConvert.SerializeObject(x)))
                .ForMember(x => x.Code, opt => opt.MapFrom(x => x.SECURITYCODE))
                .ForMember(x => x.ReportTime, opt => opt.MapFrom(x => x.REPORTDATE))
                .AfterMap((x, y) => y.TableType = ReportTableType.ZCFZB);


            CreateMap<TableData, XJLLB>()
                .ConvertUsing(x => JsonConvert.DeserializeObject<XJLLB>(x.Json));
            CreateMap<XJLLB, TableData>()
                .ForMember(x => x.Json, opt => opt.MapFrom(x => JsonConvert.SerializeObject(x)))
                .ForMember(x => x.Code, opt => opt.MapFrom(x => x.SECURITYCODE))
                .ForMember(x => x.ReportTime, opt => opt.MapFrom(x => x.REPORTDATE))
                .AfterMap((x, y) => y.TableType = ReportTableType.XJLLB);


            CreateMap<TableData, LRB>()
                .ConvertUsing(x => JsonConvert.DeserializeObject<LRB>(x.Json));
            CreateMap<LRB, TableData>()
                .ForMember(x => x.Json, opt => opt.MapFrom(x => JsonConvert.SerializeObject(x)))
                .ForMember(x => x.Code, opt => opt.MapFrom(x => x.SECURITYCODE))
                .ForMember(x => x.ReportTime, opt => opt.MapFrom(x => x.REPORTDATE))
                .AfterMap((x, y) => y.TableType = ReportTableType.LRB);
        }
    }
}
