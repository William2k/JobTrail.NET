using JobTrail.Core;
using JobTrail.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrail.API.Models
{
    public class AddJob
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Priority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public Guid? AssignedUserId { get; set; }

        public Guid? ParentJobId { get; set; }

        public Job GetJob()
        {
            var job = new Job
            {
                Name = Name,
                Description = Description,
                Priority = Priority,
                DueDate = DueDate
            };

            return job;
        }
    }
}
