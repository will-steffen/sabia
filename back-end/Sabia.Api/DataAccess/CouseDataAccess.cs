using Microsoft.AspNetCore.Mvc;
using Sabia.Api.DTOs;
using Sabia.Api.Model;
using Sabia.Api.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DataAccess
{
    public class CourseDataAccess : BaseDataAccess<Course>
    {
        public UserDataAccess userDataAccess { get; set; }
        public UserCourseDataAccess userCourseDataAccess { get; set; }

        public CourseDataAccess(SabiaContext ctx) : base(ctx)
        {
            this.userDataAccess = new UserDataAccess(ctx);
            this.userCourseDataAccess = new UserCourseDataAccess(ctx);
        }

        internal Course GetBySlug(string slug)
        {
            return Context.Set<Course>().ToList().FirstOrDefault(x => x.Name.ToSlug() == slug);
        }

        internal Course GetByIdOrSlug(string id)
        {
            int intId = -1;
            if (int.TryParse(id, out intId))
            {
                return base.GetById(intId);
            }
            else
            {
                return GetBySlug(id.ToSlug());
            }
        }

        internal ActionResult<CourseDTO> Get(string courseId, string userId)
        {
            User user = userDataAccess.GetByIdOrSlug(userId);
            Course courseDB = GetByIdOrSlug(courseId);
            CourseDTO course = courseDB.ToDTO();

            UserCourse UserCourse = user.Courses.FirstOrDefault(x => x.CourseId == course.Id);
            UserCourse UserRequiredCourse = user.Courses.FirstOrDefault(x => x.CourseId == course.RequiredCourseId);
            course.UsedUsedHours = UserCourse?.UsedHours ?? 0;
            course.UserProgression = UserCourse?.Progression ?? 0;
            course.UserCompleted = (UserCourse != null) ? UserCourse?.Progression >= 100 : false;
            if (course.RequiredCourseId.HasValue)
            {
                course.UserMeetRequirement = (UserRequiredCourse != null) ? UserRequiredCourse.Progression >= 100 : false;
            }
            else
            {
                course.UserMeetRequirement = true;
                }

            return course;
        }

        internal bool AttributeCourse(string userId, string courseId)
        {
            User user = userDataAccess.GetByIdOrSlug(userId);
            Course course = GetByIdOrSlug(courseId);
            if (user == null || course == null)
            {
                return false;
            }
            UserCourse userCourse = Context.Set<UserCourse>().FirstOrDefault(x => x.UserId == user.Id && x.CourseId == course.Id)
                ?? new UserCourse { UserId = user.Id, CourseId = course.Id };
            try
            {
                userCourseDataAccess.Save(userCourse);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal List<CourseDTO> GetAll(string userId)
        {
            User user = userDataAccess.GetByIdOrSlug(userId);
            var Courses = Context.Set<Course>().ToList().Select(x => x.ToDTO()).ToList();
            Courses.ForEach(course =>
            {
                UserCourse UserCourse = user.Courses.FirstOrDefault(x => x.CourseId == course.Id);
                UserCourse UserRequiredCourse = user.Courses.FirstOrDefault(x => x.CourseId == course.RequiredCourseId);
                course.UsedUsedHours = UserCourse?.UsedHours ?? 0;
                course.UserProgression = UserCourse?.Progression ?? 0;
                course.UserCompleted = (UserCourse != null) ? UserCourse?.Progression >= 100 : false;
                course.CourseAssigned = (UserCourse != null);
                if (course.RequiredCourseId.HasValue)
                {
                    course.UserMeetRequirement = (UserRequiredCourse != null) ? UserRequiredCourse.Progression >= 100 : false;
                }
                else
                {
                    course.UserMeetRequirement = true;
                }
            });
            return Courses.ToList();
        }

        internal bool CompleteClass(string userId, string courseName, int classNumber)
        {
            User user = userDataAccess.GetByIdOrSlug(userId);
            Course course = Context.Set<Course>().FirstOrDefault(x => x.Name == courseName);
            if (user == null || course == null)
            {
                return false;
            }
            UserCourse userCourse = Context.Set<UserCourse>().FirstOrDefault(x => x.UserId == user.Id && x.CourseId == course.Id)
                ?? new UserCourse { UserId = user.Id, CourseId = course.Id };

            var value = (float)Math.Ceiling((decimal)classNumber / (decimal)course.Classes.Count * 100);
            userCourse.Progression = Math.Max(userCourse.Progression,
                Math.Min(value, 100));
            try
            {
                userCourseDataAccess.Save(userCourse);
                return true;
            }
            catch (Exception)
            {
                return false;
            } 
        }

        internal bool SetUsedHours(string userId, string courseName, float usedHours)
        {
            User user = userDataAccess.GetByIdOrSlug(userId);
            Course course = Context.Set<Course>().FirstOrDefault(x => x.Name == courseName);
            if (user == null || course == null)
            {
                return false;
            }
            UserCourse userCourse = Context.Set<UserCourse>().FirstOrDefault(x => x.UserId == user.Id && x.CourseId == course.Id)
                ?? new UserCourse { UserId = user.Id, CourseId = course.Id };

            userCourse.UsedHours = usedHours;
            try
            {
                userCourseDataAccess.Save(userCourse);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
