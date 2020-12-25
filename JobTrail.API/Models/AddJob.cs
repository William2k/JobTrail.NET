using JobTrail.Data.Entities;
using JobTrail.Shared;
using System;
using System.ComponentModel.DataAnnotations;

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
            if(!AssignedUserId.HasValue)
            {
                throw new Exception("AssignedUserId must have a value");
            }

            var job = new Job
            {
                Name = Name,
                Description = Description,
                Priority = Priority,
                DueDate = DueDate,
                AssignedUserId = AssignedUserId.Value,
                ParentJobId = ParentJobId
            };

            return job;
        }
    }
}
