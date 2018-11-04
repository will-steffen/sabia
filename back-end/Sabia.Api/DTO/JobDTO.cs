using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DTOs
{
    public class JobDTO
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string imagePath { get; set; }

        public long? UserId { get; set; }

        public string UserDoingJob { get; set; }

        public long UsedHours { get; set; }

        public long ReportedProgression { get; set; }

        public bool Completed  { get; set; }

        public List<JobRequirementDTO> Requirements { get; set; }

        public bool UserMeetRequirement { get; set; }

        public bool Available { get; set; }

        public bool YourUserDoing { get; set; }

        public string BaseCode { get; set; }

        public string VerificationCode { get; set; }
    }
}
