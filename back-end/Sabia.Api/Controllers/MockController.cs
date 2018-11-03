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
    public class MockController : ControllerBase
    {
        public UserDataAccess userDataAccess { get; set; }

        public MockController(UserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        [HttpGet("Test")]
        public string Test()
        {
            return "Server is Online";
        }

        [HttpGet]
        public string Get()
        {
            User user = new User()
            {
                Name = "Willian Steffen",
                Username = "will",
                Password = "1234",
                Email = "willian.steffen@radixeng.com.br"
            };
            userDataAccess.Save(user);
            return userDataAccess.test();
        }
    }
}
