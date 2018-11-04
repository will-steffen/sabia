using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sabia.Api.Model
{
    public class CourseType : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; }

        public bool Basic { get; set; }

        public virtual List<Course> Courses { get; set; }
    }
}
