using System;
using HogwartsProject.Data;
using System.Collections.Generic;
using HogwartsProject.Models;

namespace HogwartsProject.Models
{
    public partial class AdminUser
    {
        public int AdminUserId { get; set; }
        public string? Pword { get; set; }
        public int? FkEmployeeId { get; set; }
        public string? UserName { get; set; }

        public virtual Employee? FkEmployee { get; set; }
    }
}
