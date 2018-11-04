using Sabia.Api.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.Model
{
    public class User : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Username { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [DefaultValue(0)]
        public float WorkedHours { get; set; }

        [DefaultValue(0)]
        public float StudyHours { get; set; }

        [DefaultValue(0)]
        public float TotalHour { get; set; }

        [DefaultValue(0)]
        public float MoneyEarned { get; set; }

        public virtual Job CurrentJob { get; set; }

        public virtual List<UserCourse> Courses { get; set; }

        public UserDTO toDTO()
        {
            return new UserDTO
            {
                Name = this.Name,
                Username = this.Username,
                Email = this.Email
            };
        }

    }
}
