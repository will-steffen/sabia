using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DTOs
{
    public class UpdateJobDTO
    {
        public string UserId { get; set; }

        public string JobId { get; set; }

        public long UsedHours { get; set; }

        public long ReportedProgression { get; set; }

        public bool Completed { get; set; }
    }
}
