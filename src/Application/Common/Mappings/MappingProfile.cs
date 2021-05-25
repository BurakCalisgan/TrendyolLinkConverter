using Application.RequestResponseHistories.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RequestResponseHistoryDto, RequestResponseHistory>()
            .ForMember(m => m.CreatedDate, map => map.Ignore())
            .ForMember(m => m.Id, map => map.Ignore());

            CreateMap<RequestResponseHistory, RequestResponseHistoryDto>();

        }
    }
}
