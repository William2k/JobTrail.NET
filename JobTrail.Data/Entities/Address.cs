using JobTrail.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobTrail.Data.Entities
{
    public class Address : BaseEntity
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string County { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
