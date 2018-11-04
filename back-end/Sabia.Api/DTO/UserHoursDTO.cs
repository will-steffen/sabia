using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DTOs
{
    public class UserHoursDTO
    {
        public string UserId { get; set; }

        public float WorkedHours { get; set; }

        public float StudyHours { get; set; }

    }
}
