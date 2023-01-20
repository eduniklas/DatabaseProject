using HogwartsProject.Menu;
using HogwartsProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace HogwartsProject.RetreiveFromDb
{
    public class RetrieveGrade
    {
        public bool GetGrades()
        {
            Console.Clear();
            string days = Convert.ToString(InputAndOutput.ReadIntFromConsole("How many days back do you want to look?\nEnter number of days: "));
            Console.Clear();
            string[] options = { "Subject", "Student", "Grade", "Teacher","Date", "Go back" };
            string prompt = "In what order do you want to show this months grades?\n";
            var monthsGradeMenu = new MenuBuilder(prompt, options, 2, 1);
            int optionIndex = monthsGradeMenu.Run();
            
            if (optionIndex <= 4)
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true");

                SqlDataAdapter sqlda = new SqlDataAdapter("Select Concat(Students.FirstName,' ',Students.LastName) as Student, Concat(Subjects.SubjectDifficulty, ' - ',Subjects.SubjectName) as Subject, Grades.Grade, Concat(Employees.Fname, ' ',Employees.Lname) as Teacher, FORMAT(GradeDate,'yyyy-MM-dd') as Date From TakingSubjects " +
                    "Join Students On StudentID = FK_StudentID " +
                    "Join Subjects On SubjectID = FK_SubjectID " +
                    "Join Grades On GradeID = FK_GradeID " +
                    "join Employees On EmployeeID = FK_EmployeeID " +
                    "Where GradeDate >= Current_timestamp -"+days+" " +
                    "Order by '" + options[optionIndex] + "' ", sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                Console.Clear();
                Console.WriteLine("|{0, -20}|{1, -24}|{2, -7}|{3,-20}|{4,15}|", "Student", "Subject", "Grade", "Teacher", "Date");
                Console.WriteLine(new string('-', 92));
                foreach (DataRow dr in dtbl.Rows)
                {
                    Console.WriteLine("|{0, -20}|{1, -24}|{2, -7}|{3,-20}|{4,15}|", dr["Student"], dr["Subject"], dr["Grade"], dr["Teacher"], dr["Date"]);
                }
                Console.WriteLine(new string('-', 92));
                InputAndOutput.PressToContinue();
                return true;
            }
            else
            {
                Console.Clear();
                return false;
            }

        } 
    }
}
