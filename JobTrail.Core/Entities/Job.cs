using JobTrail.Core.Entities.Base;
using System;

namespace JobTrail.Core.Entities
{
    public class Job : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public User AssignedUser { get; set; }
    }
}
