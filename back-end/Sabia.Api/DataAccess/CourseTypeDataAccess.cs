using Sabia.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DataAccess
{
    public class CourseTypeDataAccess : BaseDataAccess<CourseType>
    {
        public CourseTypeDataAccess(SabiaContext ctx) : base(ctx) { }
    }
}
