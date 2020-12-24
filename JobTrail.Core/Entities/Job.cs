using JobTrail.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JobTrail.Core.Entities
{
    public class Job : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        [JsonIgnore]
        public User AssignedUser { get; set; }

        [JsonIgnore]
        public Job ParentJob { get; set; }

        [JsonIgnore]
        public ICollection<Job> ChildJobs { get; set; }

        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
    }
}
