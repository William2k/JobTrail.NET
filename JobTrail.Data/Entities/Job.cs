using JobTrail.Data.Entities.Base;
using JobTrail.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobTrail.Data.Entities
{
    public class Job : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        [ForeignKey(nameof(ParentJob))]
        public Guid? ParentJobId { get; set; }

        [ForeignKey(nameof(AssignedUser))]
        public Guid AssignedUserId { get; set; }

        [ForeignKey(nameof(Group))]
        public Guid GroupId { get; set; }


        [JsonIgnore]
        public User AssignedUser { get; set; }

        [JsonIgnore]
        public Job ParentJob { get; set; }

        [JsonIgnore]
        public Group Group { get; set; }

        [JsonIgnore]
        public ICollection<Job> ChildJobs { get; set; }

        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
    }
}
