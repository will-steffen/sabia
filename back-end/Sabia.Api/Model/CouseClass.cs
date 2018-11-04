using Sabia.Api.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sabia.Api.Model
{
    public class CourseClass : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; }

        public int ClassNumber { get; set; }

        public long CourseId { get; set; }

        [ForeignKey("CourseId")]
        [InverseProperty("Classes")]
        public virtual Course Course { get; set; }

        public CourseClassDTO ToDTO()
        {
            return new CourseClassDTO
            {
                Name = this.Name,
                ClassNumber = this.ClassNumber
            };
        }
    }
}
