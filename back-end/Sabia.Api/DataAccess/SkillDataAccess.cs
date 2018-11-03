using Sabia.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DataAccess
{
    public class SkillDataAccess : BaseDataAccess<Skill>
    {
        public SkillDataAccess(SabiaContext ctx) : base(ctx) { }

        public string test()
        {
            return "teste";
        }
    }
}
