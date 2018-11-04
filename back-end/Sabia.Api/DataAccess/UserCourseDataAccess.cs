using Sabia.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DataAccess
{
    public class UserCourseDataAccess : BaseDataAccess<UserCourse>
    {
        public UserCourseDataAccess(SabiaContext ctx) : base(ctx) { }
    }
}
