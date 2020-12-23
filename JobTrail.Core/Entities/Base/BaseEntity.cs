﻿using System;
using System.ComponentModel.DataAnnotations;

namespace JobTrail.Core.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
