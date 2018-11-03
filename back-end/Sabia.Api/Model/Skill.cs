using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sabia.Api.Model
{
    public class Skill : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; }

        public virtual List<UserSkill> UserSkillList { get; set; }
    }
}
