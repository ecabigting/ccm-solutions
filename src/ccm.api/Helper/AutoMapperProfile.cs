using System;
using AutoMapper;
using ccm.entities.DTOs.Student;
using ccm.entities.Entities.Student;

namespace ccm.api.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ScholarshipDTO,StudentScholarship>().ReverseMap();
        }
    }
}