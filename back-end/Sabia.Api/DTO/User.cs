using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

    }
}
