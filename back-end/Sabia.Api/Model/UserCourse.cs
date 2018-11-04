using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.Model
{
    public class UserCourse : BaseModel
    {
        public long CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public long UserId { get; set; }

        [ForeignKey("CourseId")]
        [InverseProperty("Courses")]
        public virtual User User { get; set; }

        public float UsedHours { get; set; }

        public float Progression { get; set; }


    }
}
