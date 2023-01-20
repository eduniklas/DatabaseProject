using HogwartsProject.Models;
using System;
using System.Collections.Generic;

namespace HogwartsProject.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AdminUsers = new HashSet<AdminUser>();
            Subjects = new HashSet<Subject>();
            Users = new HashSet<User>();
            
        }

        public int EmployeeId { get; set; }
        public string? PersonalNumber { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Gender { get; set; }
        public int? FkRoleId { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        
        public virtual Role? FkRole { get; set; }
        public virtual ICollection<AdminUser> AdminUsers { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<User> Users { get; set; }
        
    }
}
