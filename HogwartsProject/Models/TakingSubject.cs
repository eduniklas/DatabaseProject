using System;
using System.Collections.Generic;

namespace HogwartsProject.Models
{
    public partial class TakingSubject
    {
        public int TakeSubjectId { get; set; }
        public int? FkStudentId { get; set; }
        public int? FkSubjectId { get; set; }
        public DateTime? GradeDate { get; set; }
        public int? FkGradeId { get; set; }

        public virtual Grade? FkGrade { get; set; }
        public virtual Student? FkStudent { get; set; }
        public virtual Subject? FkSubject { get; set; }
    }
}
