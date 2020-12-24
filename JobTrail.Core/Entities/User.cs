using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JobTrail.Core.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        [JsonIgnore]
        public ICollection<Address> Addresses { get; set; }

        [JsonIgnore]
        public ICollection<Job> Jobs { get; set; }
    }
}
