using JobTrail.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrail.API.Models
{
    public class AddGroup
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? ParentGroupId { get; set; }

        public Group GetGroup()
        {
            var group = new Group
            {
                Name = Name,
                Description = Description,
                ParentGroupId = ParentGroupId
            };

            return group;
        }
    }
}
