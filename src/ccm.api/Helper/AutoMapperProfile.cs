using System;
using AutoMapper;
using ccm.entities.DTOs.Student;
using ccm.entities.DTOs.User;
using ccm.entities.Entities.Student;
using ccm.entities.Entities.User;

namespace ccm.api.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ScholarshipDTO,StudentScholarship>().ReverseMap();
            CreateMap<UserAccessTokenDTO,UserAccessToken>().ReverseMap();
        }
    }
}