using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api.DTOs
{
    public class FinishJobDTO
    {
        public string UserId { get; set; }

        public string JobId { get; set; }

    }
}
