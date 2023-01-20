using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace HogwartsProject.RetreiveFromDb
{
    public class RetrieveSubjectAndGrade
    {
        public bool GetSubjectAndGrade() //SQL
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true");

            SqlDataAdapter sqlda = new SqlDataAdapter("Select Concat(Subjects.SubjectDifficulty,' - ', Subjects.SubjectName) as Subject, MAX(Grades.Grade) As 'TopGrade', MIN(Grades.Grade) As 'LowGrade', AVG(Grades.GradeID) As 'AverageGrade' From Grades " +
                "Join TakingSubjects On FK_GradeID = GradeID " +
                "Join Subjects On Subjects.SubjectID = FK_SubjectID " +
                "Group by SubjectDifficulty, SubjectName " +
                "Order by SubjectDifficulty ", sqlcon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);

            Console.Clear();
            Console.WriteLine("|{0, -25}|{1, -13}|{2, -13}|{3, -13}|", "Subject & Difficulty", "Top Grade", "Low Grade", "Average Grade");
            Console.WriteLine(new string('-', 69));
            foreach (DataRow dr in dtbl.Rows)
            {
                Console.WriteLine("|{0, -25}|{1, -13}|{2, -13}|{3, -13}|", dr["Subject"], dr["TopGrade"], dr["LowGrade"], dr["AverageGrade"]);
            }
            Console.WriteLine(new string('-', 69));
            InputAndOutput.PressToContinue();
            return false;
        }
    }
}
