using HogwartsProject;
using HogwartsProject.Data;
using HogwartsProject.Menu;
using HogwartsProject.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsProject.RetreiveFromDb
{
    public class RetrieveStudent
    //Extra utmaning -  Visa information om en elev, vilken klass hen tillhör och vilken/vilka lärare hen har
    //samt vilka betyg hen har fått i en specifik kurs. (SQL)
    {
        public bool GetStudent()
        {
            Console.Clear();
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true");
            SqlDataAdapter idData = new SqlDataAdapter("Select Students.StudentID from Students " +
                "order by StudentID ", sqlcon);
            DataTable idtable = new DataTable();
            idData.Fill(idtable);

            Console.WriteLine("Students ID\n");
            foreach (DataRow ids in idtable.Rows)
            {
                Console.WriteLine(ids["StudentID"]);
            }
            int id = InputAndOutput.ReadIntFromConsole("\nEnter ID: ");
            SqlDataAdapter sqlda = new SqlDataAdapter("SP_Student @ID = '"+id+"'", sqlcon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);

            Console.Clear();
            Console.WriteLine("|{0, -19}|{1, -18}|{2, -10}|{3, -15}|{4, -15}|", "Name", "Securety number", "Gender", "Class","Year");
            Console.WriteLine(new string('-', 83));
            foreach (DataRow dr in dtbl.Rows)
            {
                Console.WriteLine("|{0, -19}|{1, -18}|{2, -10}|{3, -15}|{4, -15}|", dr["Name"], dr["PersonalNumber"], dr["Gender"], dr["ClassName"], dr["ClassYear"]);
            }
            InputAndOutput.PressToContinue();
            
            string prompt = "Retrieve students by year";
            string[] options = { "Show all students", "Go back" };
            var allStudMenu = new MenuBuilder(prompt, options, 2, 1);
            int orderIndex = allStudMenu.Run();

            using HogwartsFinalContext context = new HogwartsFinalContext();
            if (orderIndex == 0)
            {
                Console.Clear();
                var myStudent = from s in context.Students
                                join c in context.Classes on s.FkClassId equals c.ClassId
                                where s.FkClassId == c.ClassId
                                orderby c.ClassYear
                                select new
                                {
                                    s.StudentId,
                                    s.FirstName,
                                    s.LastName,
                                    s.Gender,
                                    s.PersonalNumber,
                                    c.ClassName,
                                    c.ClassYear
                                };
                Console.WriteLine("|{0, -15}|{1, -15}|{2, -10}|{3, -18}|{4, -15}|{5, -15}|", "First name", "Last name", "Gender", "Securety number", "Class", "Year");
                Console.WriteLine(new string('-', 95));

                foreach (var student in myStudent)
                {
                    Console.WriteLine("|{0, -15}|{1, -15}|{2, -10}|{3, -18}|{4, -15}|{5, -15}|", student.FirstName, student.LastName, student.Gender, student.PersonalNumber, student.ClassName, student.ClassYear);
                }
                Console.WriteLine(new string('-', 95));
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
