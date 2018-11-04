using Sabia.Api.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DTOs
{
    public class UserCourseTypeDTO
    {
        public string CourseTypeName { get; set; }
        
        public int Level { get; set; }

    }
}
