using JobTrail.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace JobTrail.Data.Entities
{
    public class Group : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(ParentGroup))]
        public Guid? ParentGroupId { get; set; }

        [JsonIgnore]
        public Group ParentGroup { get; set; }

        [JsonIgnore]
        public ICollection<Group> ChildGroups { get; set; }

        [JsonIgnore]
        public ICollection<Job> Jobs { get; set; }
    }
}
