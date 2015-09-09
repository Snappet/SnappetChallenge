﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyReport.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            Created = DateTime.UtcNow;
        }
    }
}
