using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace JobTrail.Data.Entities
{
    public class UserGroupRoles
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Group))]
        public Guid GroupId { get; set; }

        [ForeignKey(nameof(Role))]
        public Guid RoleId { get; set; }


        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public Group Group { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }
    }
}
