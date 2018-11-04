using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DTOs
{
    public class CourseAssignRequestDTO
    {
        public string UserId { get; set; }
        public string CourseId { get; set; }
    }
}
