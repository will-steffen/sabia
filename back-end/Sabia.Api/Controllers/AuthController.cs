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
    public class AuthController : ControllerBase
    {
        public UserDataAccess userDataAccess { get; set; }

        public AuthController(UserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        [HttpPost]
        public ActionResult<User> Login([FromBody] AuthData item)
        {         
            var user = userDataAccess.GetByName(item.Name);
            if (user == null)
            {
                return NotFound();
            }
            return user;
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
