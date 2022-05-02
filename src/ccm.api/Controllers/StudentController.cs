using System;
using ccm.api.Repositories.Student;
using Microsoft.AspNetCore.Mvc;

namespace ccm.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ApiBaseController
    {
        private readonly IScholarshipRepository repo;

        public StudentController(IScholarshipRepository _repo)
        {
            repo = _repo;
        }
    }
}