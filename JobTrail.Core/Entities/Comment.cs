using JobTrail.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrail.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public Job Job { get; set; }
    }
}
