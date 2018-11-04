using Sabia.Api.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DTOs
{
    public class CourseDTO
    {
        public long Id { get; set; }

        public long? RequiredCourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float ExpectedHours { get; set; }

        public List<CourseClassDTO> Classes { get; set; }

        public Level Level { get; set; }

        public string RequiredCourseName { get; set; }

        public string ImagePath { get; set; }

        public float UsedUsedHours { get; set; }

        public float UserProgression { get; set; }

        public bool UserMeetRequirement { get; set; }

        public bool UserCompleted { get; set; }

    }
}
