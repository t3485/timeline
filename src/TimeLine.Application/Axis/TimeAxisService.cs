using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization;
using TimeLine.Axis.Dto;

namespace TimeLine.Axis
{
    public class TimeAxisService: ITimeAxisService
    {
        private readonly IRepository<TimeAxis> _axisRepository;

        public TimeAxisService(IRepository<TimeAxis> axisRepository)
        {
            _axisRepository = axisRepository;
        }

        [AbpAuthorize]
        public void CreateTimeAxis(CreateAxisDto input)
        {
            var entity = Mapper.Map<TimeAxis>(input);

            _axisRepository.Insert(entity);
        }
    }
}
