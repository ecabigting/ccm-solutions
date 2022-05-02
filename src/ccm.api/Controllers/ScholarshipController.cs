using System;
using ccm.api.Repositories.Student;
using Microsoft.AspNetCore.Mvc;

namespace ccm.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScholarhipController : ApiBaseController
    {
        private readonly IScholarshipRepository repo;
        public ScholarshipController(IScholarshipRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public async Task<IEnumerable<Scholarhip>> Get
    }
}