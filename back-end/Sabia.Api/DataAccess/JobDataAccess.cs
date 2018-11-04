using Microsoft.AspNetCore.Mvc;
using Sabia.Api.DTOs;
using Sabia.Api.Model;
using Sabia.Api.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sabia.Api.DataAccess
{
    public class JobDataAccess : BaseDataAccess<Job>
    {
        public UserDataAccess userDataAccess { get; set; }
        public UserCourseDataAccess userCourseDataAccess { get; set; }

        public JobDataAccess(SabiaContext ctx) : base(ctx)
        {
            this.userDataAccess = new UserDataAccess(ctx);
            this.userCourseDataAccess = new UserCourseDataAccess(ctx);
        }

        internal JobDTO Get(string jobId, string userId)
        {
            User user = userDataAccess.GetByIdOrSlug(userId);
            Job jobDB = GetByIdOrSlug(jobId);

            JobDTO JobDTO = jobDB.ToDTO();

            List<long> CompletedCourses = user.Courses
                .Where(x => x.Progression >= 100)
                .Select(x => x.CourseId)
                .ToList();
            JobDTO.Requirements.ForEach(req =>
            {
                req.UserMeetRequirement = CompletedCourses.Contains(req.CourseId);
            });
            JobDTO.UserMeetRequirement = JobDTO.Requirements.All(x => x.UserMeetRequirement);
            JobDTO.YourUserDoing = (JobDTO.UserDoingJob?.Equals(user.Name) ?? false);
            
            return JobDTO;
        }

        internal bool FinishJob(string userId, string jobId)
        {
            Job job = GetByIdOrSlug(jobId);
            User user = userDataAccess.GetByIdOrSlug(userId);
            if (user == null || job == null)
            {
                return false;
            }
            if (!job.Completed)
            {
                user.MoneyEarned += job.Money;
            }
            job.Completed = true;
            job.ReportedProgression = 100;
            try
            {
                userDataAccess.Save(user);
                base.Save(job);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal List<JobDTO> GetAll(string userId)
        {
            User user = userDataAccess.GetByIdOrSlug(userId);
            var Jobs = Context.Set<Job>().ToList()
                .Where(x=>!x.Completed)
                .Select(x => x.ToDTO()).ToList();
            Jobs.ForEach(job =>
            {
                List<long> CompletedCourses = user.Courses
                    .Where(x => x.Progression >= 100)
                    .Select(x=>x.CourseId)
                    .ToList();
                job.Requirements.ForEach(req =>
                {
                    req.UserMeetRequirement = CompletedCourses.Contains(req.CourseId);
                });
                job.UserMeetRequirement = job.Requirements.All(x => x.UserMeetRequirement);
                job.YourUserDoing = (job.UserDoingJob?.Equals(user.Name) ?? false);

            });
            return Jobs.OrderByDescending(x=>x.UserMeetRequirement).ThenBy(x=>x.YourUserDoing).ToList();
        }

        internal Job GetBySlug(string slug)
        {
            return Context.Set<Job>().ToList().FirstOrDefault(x => x.Title.ToSlug() == slug);
        }

        internal Job GetByIdOrSlug(string id)
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

        internal bool AttributeJob(string userId, string jobId)
        {
            Job job = GetByIdOrSlug(jobId);
            User user = userDataAccess.GetByIdOrSlug(userId);
            if ((job.UserId.HasValue && job.UserId != user.Id) || user == null || job == null)
            {
                return false;
            }
            job.UserId = user.Id;
            try
            {
                base.Save(job);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal bool Update(string UserId, string JobId, long UsedHours, long ReportedProgression, bool Completed)
        {
            Job job = GetByIdOrSlug(JobId);
            User user = userDataAccess.GetByIdOrSlug(UserId);
            if ((job.UserId.HasValue && job.UserId != user.Id) || user == null || job == null)
            {
                return false;
            }
            job.UserId = user.Id;
            job.UsedHours = Math.Max(Math.Max(job.UsedHours, UsedHours), 0);
            job.ReportedProgression = (long)Math.Floor((decimal)Math.Max(Math.Max(job.ReportedProgression, ReportedProgression), 0));
            if (Completed && !job.Completed)
            {
                user.MoneyEarned += job.Money;
            }
            job.Completed = Completed;
            if(job.Completed)
            {
                job.ReportedProgression = 100;
            }
            try
            {
                userDataAccess.Save(user);
                base.Save(job);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
