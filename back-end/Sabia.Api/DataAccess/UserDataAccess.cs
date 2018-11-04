using Sabia.Api.Model;
using Sabia.Api.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DataAccess
{
    public class UserDataAccess : BaseDataAccess<User>
    {
        public UserDataAccess(SabiaContext ctx) : base(ctx) { }

        internal User GetByUsername(string username)
        {
            return Context.Set<User>().Where(x => x.Username == username).FirstOrDefault();
        }

        internal User GetBySlug(string slug)
        {
            return Context.Set<User>().ToList().FirstOrDefault(x => x.Name.ToSlug() == slug);
        }

        public override void Save(User user)
        {
            base.GetById(user.Id);
        }

        internal User GetByIdOrSlug(string id)
        {
            int intId = -1;
            if(int.TryParse(id,out intId))
            {
                return base.GetById(intId);
            }
            else
            {
                return GetBySlug(id.ToSlug());
            }
        }

        internal bool UpdateHours(string userId, float workedHours, float studyHours)
        {
            User user = GetByIdOrSlug(userId);
            user.WorkedHours = Math.Max(user.WorkedHours, workedHours);
            user.StudyHours = Math.Max(user.StudyHours, studyHours);
            user.TotalHour = user.WorkedHours + user.StudyHours;
            try
            {
                base.Save(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
