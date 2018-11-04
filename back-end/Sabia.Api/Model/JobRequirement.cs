using Sabia.Api.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.Model
{
    public class JobRequirement : BaseModel
    {
        public long JobId { get; set; }

        [ForeignKey("JobId")]
        [InverseProperty("Requirements")]
        public virtual Job Job { get; set; }

        public long CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public JobRequirementDTO ToDTO()
        {
            return new JobRequirementDTO
            {
                CourseId = this.CourseId,
                CourseName = this.Course.Name,
                UserMeetRequirement = false,
            };
        }
    }
}
