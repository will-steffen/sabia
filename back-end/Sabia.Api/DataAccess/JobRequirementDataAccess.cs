using Sabia.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DataAccess
{
    public class JobRequirementDataAccess : BaseDataAccess<JobRequirement>
    {
        public JobRequirementDataAccess(SabiaContext ctx) : base(ctx) { }
    }
}
