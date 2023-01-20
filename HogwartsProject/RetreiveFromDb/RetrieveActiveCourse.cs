using HogwartsProject.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsProject.RetreiveFromDb
{
    public class RetrieveActiveCourse
    {
        public bool ActiveCourse()
        {
            Console.Clear();
            HogwartsFinalContext context = new HogwartsFinalContext();
            var actCourse = from ac in context.Subjects
                            join t in context.Employees on ac.FkEmployeeId equals t.EmployeeId
                            where ac.SubjectDifficulty != null
                            orderby ac.SubjectName
                            select new
                            {
                                ac.SubjectName, ac.SubjectDifficulty,
                                t.Fname, t.Lname,

                            };

            Console.WriteLine("Active courses\n");

            Console.WriteLine("|{0,-15}|{1,-15}|{2,-23}|","Name", "Difficulty","Teacher");
            Console.WriteLine(new string('-',57));
            foreach (var actC in actCourse)
            {
                Console.WriteLine("|{0,-15}|{1,-15}|{2,-11}{3,-11} |",actC.SubjectName, actC.SubjectDifficulty, actC.Fname, actC.Lname);
            }
            Console.WriteLine(new string('-',57));
            InputAndOutput.PressToContinue();
            return false;
        }
        
    }
}
