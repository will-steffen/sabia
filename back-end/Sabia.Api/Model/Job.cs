using Sabia.Api.DTOs;
using Sabia.Api.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.Model
{
    public class Job : BaseModel
    {
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string imagePath { get; set; }

        public long? UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("CurrentJob")]
        public virtual User UserDoingJob { get; set; }

        public long UsedHours { get; set; }

        public long ReportedProgression { get; set; }

        public bool Completed  { get; set; }

        public float Money { get; set; }

        [Column(TypeName = "LONGTEXT")]
        [DefaultValue("")]
        public string BaseCode { get; set; }

        [Column(TypeName = "LONGTEXT")]
        [DefaultValue("")]
        public string VerificationCode { get; set; }

        public virtual List<JobRequirement> Requirements { get; set; }

        public JobDTO ToDTO()
        {
            return new JobDTO
            {
                Title = this.Title,
                Slug = this.Title.ToSlug(),
                Description = this.Description,
                imagePath = this.imagePath,
                UserId = this.UserId,
                UsedHours = this.UsedHours,
                ReportedProgression = this.ReportedProgression,
                Completed = this.Completed,
                Requirements = this.Requirements.Select(x => x.ToDTO()).ToList(),
                UserDoingJob = this.UserDoingJob?.Name,

                Available = (this.UserDoingJob == null),
                UserMeetRequirement = false,
                YourUserDoing = false,
                BaseCode = "",
                VerificationCode = ""
            };
        }

    }
}
