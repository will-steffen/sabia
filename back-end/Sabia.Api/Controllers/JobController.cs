using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sabia.Api.DataAccess;
using Sabia.Api.DTOs;
using Sabia.Api.Model;

namespace Sabia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        public JobDataAccess jobDataAccess { get; set; }

        public JobController(JobDataAccess jobDataAccess)
        {
            this.jobDataAccess = jobDataAccess;
        }

        [HttpGet("{jobId}/{userId}")]
        public ActionResult<JobDTO> Get(string jobId, string userId)
        {
            return jobDataAccess.Get(jobId, userId);
        }

        [HttpGet("{userId}")]
        public ActionResult<List<JobDTO>> GetAll(string userId)
        {
            return jobDataAccess.GetAll(userId);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] UpdateJobDTO dto)
        {
            bool ok = jobDataAccess.Update(dto.UserId, dto.JobId, dto.UsedHours, dto.ReportedProgression, dto.Completed);
            if (ok)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
