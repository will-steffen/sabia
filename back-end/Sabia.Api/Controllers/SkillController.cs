using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sabia.Api.DataAccess;
using Sabia.Api.Model;

namespace Sabia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        public SkillDataAccess skillDataAccess { get; set; }

        public SkillController(SkillDataAccess skillDataAccess)
        {
            this.skillDataAccess = skillDataAccess;
        }

        [HttpGet]
        public ActionResult<List<Skill>> GetAll()
        {
            return null;
        }

        [HttpGet("{id}", Name = "GetSkill")]
        public ActionResult<Skill> GetById(long id)
        {
            var item = skillDataAccess.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Save([FromBody] Skill item)
        {
            skillDataAccess.Save(item);
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        //[HttpGet]
        //public string Save(Skill )
        //{
        //    User user = new User()
        //    {
        //        Name = "Willian Steffen",
        //        Username = "will",
        //        Password = "1234",
        //        Email = "willian.steffen@radixeng.com.br"
        //    };
        //    userDataAccess.Save(user);
        //    return userDataAccess.test();
        //}
    }
}
