using JobTrail.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JobTrail.Data.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Address> Addresses { get; set; }

        [JsonIgnore]
        public ICollection<Job> Jobs { get; set; }
    }
}
