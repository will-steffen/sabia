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
    public class UserController : ControllerBase
    {
        public UserDataAccess userDataAccess { get; set; }

        public UserController(UserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetAll()
        {
            return userDataAccess.GetList().ToList().Select(x=>x.toDTO()).ToList();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<UserDTO> GetById(string id)
        {
            var item = userDataAccess.GetByIdOrSlug(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item.toDTO());
        }

        [HttpPost("Save")]
        public IActionResult Save([FromBody] User item)
        {
            userDataAccess.Save(item);
            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }

        [HttpPost("UpdateHours")]
        public IActionResult UpdateHours([FromBody] UserHoursDTO dto)
        {
            bool ok = userDataAccess.UpdateHours(dto.UserId, dto.WorkedHours, dto.StudyHours);
            if (ok)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult AddSeconds([FromBody] UserHoursDTO dto)
        {
            bool ok = userDataAccess.UpdateHours(dto.UserId, dto.WorkedHours, dto.StudyHours);
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
