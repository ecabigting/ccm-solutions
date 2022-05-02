using System.Collections.ObjectModel;
using System;
using ccm.api.Repositories.Student;
using Microsoft.AspNetCore.Mvc;
using ccm.entities.DTOs;

namespace ccm.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScholarshipController : ApiBaseController
    {
        private readonly IScholarshipRepository repo;
        public ScholarshipController(IScholarshipRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public async Task<IEnumerable<ScholarshipDTO>> GetAllEnabled()
        {
            return await repo.GetAllEnabled();
        }
    }
}