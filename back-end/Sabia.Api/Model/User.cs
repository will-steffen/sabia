using Sabia.Api.DTOs;
using Sabia.Api.Util;
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

        public virtual List<Job> CurrentJobs { get; set; }

        public virtual List<UserCourse> Courses { get; set; }

        public UserDTO toDTO()
        {
            return new UserDTO
            {
                Id = this.Id,
                Name = this.Name,
                Username = this.Username,
                Email = this.Email,
                Slug = this.Name.ToSlug(),
                WorkedHours = this.WorkedHours,
                StudyHours = this.StudyHours,
                TotalHour = this.TotalHour,
                MoneyEarned = this.MoneyEarned,
                CurrentJobName =  "",
                Courses = this.Courses
                .Where(x=>x.Progression >= 100 && !x.Course.Type.Basic)
                .GroupBy(x=>x.Course.Type.Name).Select(x=> new UserCourseTypeDTO
                {
                    CourseTypeName = x.Key,
                    Level = x.Max(y=>(int)y.Course.Level)
                }).ToList()
            };
        }

    }
}
