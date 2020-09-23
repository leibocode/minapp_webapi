using _02_Mapping_Welfare_Domain.DomainModels;
using _03_Mapping_Welfare_Infrastructure.Data.Dtos.BannerDtos;
using _03_Mapping_Welfare_Infrastructure.Data.Dtos.Comments;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0_Mapping_Welfare_API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Banner, BannerDto>();

            CreateMap<Comments, CommentDto>();
        }
    }
}
