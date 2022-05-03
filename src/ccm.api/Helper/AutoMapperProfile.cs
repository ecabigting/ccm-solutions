using System;
using AutoMapper;
using ccm.entities.DTOs.Student;

namespace ccm.api.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ScholarshipDTO,Scholarship>().ReverseMap();
        }
    }
}