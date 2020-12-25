using JobTrail.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace JobTrail.Data.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        [ForeignKey(nameof(Job))]
        public Guid? JobId { get; set; }

        [JsonIgnore]
        public Job Job { get; set; }
    }
}
