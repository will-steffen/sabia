using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DTOs
{
    public class SetUsedHoursRequestDTO
    {
        public string UserId { get; set; }

        public string CourseName { get; set; }

        public float UsedHours { get; set; }

    }
}
