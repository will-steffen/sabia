using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DTOs
{
    public class JobRequirementDTO
    {
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public bool UserMeetRequirement { get; set; }
        
    }
}
