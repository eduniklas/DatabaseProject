﻿using System;
using System.Collections.Generic;

namespace HogwartsProject.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int ClassId { get; set; }
        public string? ClassYear { get; set; }
        public string? ClassName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
