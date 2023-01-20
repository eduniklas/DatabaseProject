using System;
using System.Collections.Generic;

namespace HogwartsProject.Models
{
    public partial class Grade
    {
        public Grade()
        {
            TakingSubjects = new HashSet<TakingSubject>();
        }

        public int GradeId { get; set; }
        public string? Grade1 { get; set; }

        public virtual ICollection<TakingSubject> TakingSubjects { get; set; }
    }
}
