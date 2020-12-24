using JobTrail.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JobTrail.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        [JsonIgnore]
        public Job Job { get; set; }
    }
}
