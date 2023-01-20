using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HogwartsProject.Data;
using HogwartsProject.Menu;
using HogwartsProject.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace HogwartsProject.AddToDb
{
    public class AddEmployee
    {
        public bool NewEmployee()
        {
            Console.Clear();
            string[] options = { "F", "M" };
            string prompt = "What gender is this new hire?";
            var genMenu = new MenuBuilder(prompt, options, 2, 1);
            int optionIndex = genMenu.Run();
            string gen = options[optionIndex];
            Console.Clear();

            string prompt2 = "What position in this new hire filling?";
            string[] roleOptions = { "Teacher", "Admin", "Caretaker" };
            var roleMenu = new MenuBuilder(prompt2, roleOptions, 2, 1);
            int roleIndex = roleMenu.Run();
            int roleId = roleIndex + 2;
            Console.Clear();

            string firstName = InputAndOutput.setName("Enter first name: ");
            string lastName = InputAndOutput.setName("Enter last name: ");
            string secNum = Convert.ToString(InputAndOutput.ReadIntFromConsole("Enter security number, Ex. 19201021 : "));
            decimal sal = Convert.ToDecimal(InputAndOutput.ReadIntFromConsole("Enter monthly salary, Ex. 34500 : "));
            Console.Clear();


            string prompt3 = "Do you want to save this to the database?\n" +
                "\nName: " + firstName + " " + lastName + "\nSecurity number: " + secNum + "\nPosition: " + roleOptions[roleIndex] + "\nGender: " + options[optionIndex] + "\n" +"Salary: " + sal;
            string[] yesOrNo = { "Yes", "No" };
            var save = new MenuBuilder(prompt3, yesOrNo, 8, 1);
            int optionIndex3 = save.Run();

            if (optionIndex3 == 0)
            {
                using HogwartsFinalContext context = new HogwartsFinalContext();
                Employee e = new Employee()
                {
                    PersonalNumber = secNum,
                    Fname = firstName,
                    Lname = lastName,
                    Gender = gen,
                    FkRoleId = roleId,
                    Salary = sal,
                    DateOfEmployment= DateTime.Now,

                };
                context.Employees.Add(e);

                context.SaveChanges();

                if (roleOptions[roleIndex] == "Teacher")
                {
                    AddTeacher(context, e);
                }
                AddToDepartment(context,roleId);

                InputAndOutput.Saved();
                InputAndOutput.PressToContinue();
                return false;
            }
            else
            {
                InputAndOutput.NotSaved();
                InputAndOutput.PressToContinue();
                return false;
            }
        } //E-F Inte klar
        public void AddTeacher(HogwartsFinalContext context, Employee e)
        {
            Console.Clear();
            var takenSubject = from sub in context.Subjects
                               orderby sub.SubjectName
                               select sub;

            Console.WriteLine("Subject without a set difficulty are free to take\n");
            Console.WriteLine("|{0,-14}|{1,-14}|", "Subject", "Difficulty");
            Console.WriteLine(new string('-', 30));
            foreach (var subs in takenSubject)
            {
                Console.WriteLine("|{0,-14}|{1,-14}|", subs.SubjectName, subs.SubjectDifficulty);
            }
            Console.WriteLine(new string('-', 30));

            string subPrompt = "Which subject is this hire teaching?";
            string[] subOptions = { "Math", "English", "Swedish", "Construction", "WebbDev", "Dance" };
            var subMenu = new MenuBuilder(subPrompt, subOptions, 25, 1);
            int subIndex = subMenu.Run();
            Console.Clear();

            takenSubject = from sub in context.Subjects
                           where sub.SubjectName == subOptions[subIndex]
                           orderby sub.SubjectName
                           select sub;

            Console.WriteLine("Choose the missing difficulty level of that subject\n");
            Console.WriteLine("|{0,-14}|{1,-14}|", "Subject", "Difficulty");
            Console.WriteLine(new string('-', 30));
            foreach (var subs in takenSubject)
            {
                Console.WriteLine("|{0,-14}|{1,-14}|", subs.SubjectName, subs.SubjectDifficulty);
            }
            Console.WriteLine(new string('-', 30));

            string difPrompt = "Which subject difficulty is this hire teaching?";
            string[] difOptions = { "Beginner", "Moderate", "Advanced", };
            var difMenu = new MenuBuilder(difPrompt, difOptions, 10, 2);
            int difIndex = difMenu.Run();
            Console.Clear();

            var emps = from em in context.Employees
                       orderby em.EmployeeId
                       select new
                       {
                           em.EmployeeId,
                           em.Fname,
                           em.Lname,
                       };
            Console.WriteLine("|{0,-10}|{1,-15}{2,-15}|", "ID", "First name", "Last name");
            Console.WriteLine(new string('-',43));
            foreach (var emp in emps)
            {
                Console.WriteLine("|{0,-10}|{1,-15}{2,-15}|", emp.EmployeeId, emp.Fname, emp.Lname);
            }
            Console.WriteLine(new string('-',43));

            string subject = subOptions[subIndex],
                subjectDif = difOptions[difIndex];
            int empID = InputAndOutput.ReadIntFromConsole("\nWhat employeeID was asigned to the new hire?\nEnter it here: "); ;
            Subject s = new Subject()
            {
                SubjectName = subject,
                FkEmployeeId = empID,
                SubjectDifficulty = subjectDif,
            };
            context.Subjects.Add(s);
            context.SaveChanges();
        }
        public void AddToDepartment(HogwartsFinalContext context, int roleId)
        {
            Console.Clear();
            var department = from dep in context.Departments
                             orderby dep.DepartmentId
                             select dep;

            Console.WriteLine("|{0,-10}|{1,-15}|", "ID","Name");
            Console.WriteLine(new string('-',28));
            foreach (var deps in department)
            {
                Console.WriteLine("|{0,-10}|{1,-15}|", deps.DepartmentId, deps.DepartmentName);
            }
            Console.WriteLine(new string('-',28));

            string depPrompt = "Which department is this new hire going to work in?";
            string[] depOptions = { "1","2","3","4","5","6","7" };
            var depMenu = new MenuBuilder(depPrompt,depOptions,12,1);
            int depIndex = depMenu.Run();
            Console.Clear();

            var emps = from em in context.Employees
                       orderby em.EmployeeId
                       select new
                       {
                           em.EmployeeId,
                           em.Fname,
                           em.Lname,
                       };
            Console.WriteLine("|{0,-10}|{1,-15}{2,-15}|","ID","First name","Last name");
            Console.WriteLine(new string('-',43));
            foreach (var emp in emps)
            {
                Console.WriteLine("|{0,-10}|{1,-15}{2,-15}|",emp.EmployeeId, emp.Fname, emp.Lname);
            }
            Console.WriteLine(new string('-',43));
            
            int empID = InputAndOutput.ReadIntFromConsole("\nWhat employeeID was asigned to the new hire?\nEnter it here: ");
            WorkInDept w = new WorkInDept()
            {
                FkDepartmentId= depIndex + 1,
                FkRoleId = roleId,
                FkEmployeeId = empID,
            };
            context.WorkInDepts.Add(w);
            context.SaveChanges();
        }
    }
}
