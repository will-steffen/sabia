using Sabia.Api.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace Sabia.Api.Model
{
    public class Course : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public float ExpectedHours { get; set; }

        public long CourseTypeId { get; set; }

        [ForeignKey("CourseTypeId")]
        [InverseProperty("Courses")]
        public virtual CourseType Type { get; set; }

        public virtual List<CourseClass> Classes { get; set; }

        public Level Level { get; set; }

        public long? RequirementCourseId { get; set; }

        [ForeignKey("RequirementCourseId")]
        public virtual Course RequiredCourse { get; set; }

        [StringLength(250)]
        public string ImagePath { get; set; }

        public CourseDTO ToDTO()
        {
            return new CourseDTO
            {
                Id = this.Id,
                RequiredCourseId = this.RequirementCourseId,
                Name = this.Name,
                Description = this.Description,
                ExpectedHours = this.ExpectedHours,
                Classes = this.Classes.Select(x => x.ToDTO()).ToList(),
                Level = this.Level,
                RequiredCourseName = this.RequiredCourse?.Name ?? "",
                ImagePath = this.ImagePath,
                UsedUsedHours = 0,
                UserCompleted = false,
                UserMeetRequirement = false,
                UserProgression = 0
            };
        }
    }
}
