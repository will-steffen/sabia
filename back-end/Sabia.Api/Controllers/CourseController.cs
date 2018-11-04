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
    public class CourseController : ControllerBase
    {
        public CourseDataAccess courseDataAccess { get; set; }

        public CourseController(CourseDataAccess courseDataAccess)
        {
            this.courseDataAccess = courseDataAccess;
        }

        [HttpGet("{courseId}/{userId}")]
        public ActionResult<CourseDTO> Get(string courseId, string userId)
        {
            return courseDataAccess.Get(courseId, userId);
        }

        [HttpGet("{userId}")]
        public ActionResult<List<CourseDTO>> GetAll(string userId)
        {
            return courseDataAccess.GetAll(userId);
        }

        [HttpPost("CompleteClass")]
        public IActionResult CompleteClass([FromBody] CompleteClassRequestDTO dto)
        {
            if (courseDataAccess.CompleteClass(dto.UserId, dto.CourseName, dto.ClassNumber))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("SetUserHours")]
        public IActionResult SetUserHours([FromBody] SetUsedHoursRequestDTO dto)
        {
            if (courseDataAccess.SetUsedHours(dto.UserId, dto.CourseName, dto.UsedHours))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("AttributeCourse")]
        public IActionResult AttributeCourse([FromBody] CourseAssignRequestDTO dto)
        {
            bool ok = courseDataAccess.AttributeCourse(dto.UserId, dto.CourseId);
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
