using System;
using System.Collections.Generic;

namespace HogwartsProject.Models
{
    public partial class Subject
    {
        public Subject()
        {
            TakingSubjects = new HashSet<TakingSubject>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;
        public int? FkEmployeeId { get; set; }
        public string? SubjectDifficulty { get; set; }

        public virtual Employee? FkEmployee { get; set; }
        public virtual ICollection<TakingSubject> TakingSubjects { get; set; }
    }
}
