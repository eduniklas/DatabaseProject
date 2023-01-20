using System;
using System.Collections.Generic;

namespace HogwartsProject.Models
{
    public partial class Student
    {
        public Student()
        {
            TakingSubjects = new HashSet<TakingSubject>();
        }

        public int StudentId { get; set; }
        public string PersonalNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int? FkClassId { get; set; }

        public virtual Class? FkClass { get; set; }
        public virtual ICollection<TakingSubject> TakingSubjects { get; set; }
    }
}
