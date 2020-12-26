using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace JobTrail.Data.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public Role() : base()
        {

        }

        public Role(string roleName) : base(roleName)
        {

        }

        [JsonIgnore]
        public ICollection<Group> Groups { get; set; }

        [JsonIgnore]
        public ICollection<User> Members { get; set; }
    }
}
