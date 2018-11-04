using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public float WorkedHours { get; set; }

        public float StudyHours { get; set; }

        public float TotalHour { get; set; }

        public float MoneyEarned { get; set; }

        public string CurrentJobName { get; set; }

        public virtual List<UserCourseTypeDTO> Courses { get; set; }

    }
}
