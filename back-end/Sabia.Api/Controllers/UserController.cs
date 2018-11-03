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
    public class UserController : ControllerBase
    {
        public UserDataAccess userDataAccess { get; set; }

        public UserController(UserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return userDataAccess.List().ToList();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetById(long id)
        {
            var item = userDataAccess.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Save([FromBody] User item)
        {
            userDataAccess.Save(item);
            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
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
