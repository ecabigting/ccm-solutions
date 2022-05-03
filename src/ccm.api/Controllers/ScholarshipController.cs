using System.Collections.ObjectModel;
using System;
using ccm.api.Repositories.Student;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ccm.entities.DTOs.Student;

namespace ccm.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScholarshipController : ApiBaseController
    {
        private readonly IScholarshipRepository repo;
        private readonly IMapper mapper;
        public ScholarshipController(IScholarshipRepository _repo,IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }
    
        [HttpGet]
        public async Task<IEnumerable<ScholarshipDTO>> GetAllEnabled() // to do add user role validation
        {
            return mapper.Map<IEnumerable<ScholarshipDTO>>(await repo.GetAllEnabled());
        }
    }
}