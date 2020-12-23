using JobTrail.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace JobTrail.Core.Entities
{
    public class Job : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public User AssignedUser { get; set; }

        public Job ParentJob { get; set; }

        public ICollection<Job> ChildJobs { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
