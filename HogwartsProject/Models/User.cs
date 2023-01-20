using System;
using System.Collections.Generic;

namespace HogwartsProject.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? Pword { get; set; }
        public int? FkEmployeeId { get; set; }
        public string? UserName { get; set; }

        public virtual Employee? FkEmployee { get; set; }
    }
}
