using JobTrail.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace JobTrail.Core.Entities
{
    public class Address : BaseEntity
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string County { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
