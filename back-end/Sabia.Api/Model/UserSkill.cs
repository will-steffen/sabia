using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sabia.Api.Model
{
    public class UserSkill : BaseModel
    {
        public long Level { get; set; }

        public long SkillId { get; set; }

        [ForeignKey("SkillId")]
        [InverseProperty("UserSkillList")]
        public virtual Skill Skill { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("UserSkillList")]
        public virtual User User { get; set; }
    }
}