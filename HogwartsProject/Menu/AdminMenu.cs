using HogwartsProject.Authentication;
using HogwartsProject.AddToDb;
using HogwartsProject.RetreiveFromDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsProject.Menu
{
    public class AdminMenu : MainMenu
    {
        bool run = true;
        public void StartAdmin()
        {
            Console.Clear();
            string prompt = "Use up and down arrows to navigate and press Enter to select option\n";
            string[] options = { "Retrive employee", "Retrive student", "Retrive class", "Retrieve grades", "Retrive courses & grades", "Retrive active courses", "Department info", "Set grade", "Add student", "Add employee", "Exit" };
            var adminMenu = new MenuBuilder(prompt, options, 2, 1);
            int optionIndex = adminMenu.Run();

            while (optionIndex != 11)
            {
                while (run)
                {

                    switch (optionIndex)
                    {
                        case 0:
                            RetrieveEmployee retEmp = new RetrieveEmployee();
                            if (retEmp.GetEmployee() == false)
                            {
                                optionIndex = adminMenu.Run();
                            }
                            break;
                        case 1:
                            RetrieveStudent retStud = new RetrieveStudent();
                            if (retStud.GetStudent() == false)
                            {
                                optionIndex = adminMenu.Run();
                            }
                            break;
                        case 2:
                            RetrieveStudInClass retClass = new RetrieveStudInClass();
                            if (retClass.GetStudentsInClass() == false)
                            {
                                optionIndex = adminMenu.Run();
                            }
                            break;
                        case 3:
                            RetrieveGrade retGrade = new RetrieveGrade();
                            if (retGrade.GetGrades() == false)
                            {
                                optionIndex = adminMenu.Run();
                            }
                            break;
                        case 4:
                            RetrieveSubjectAndGrade retSubjectGrade = new RetrieveSubjectAndGrade();
                            if (retSubjectGrade.GetSubjectAndGrade() == false)
                            {
                                optionIndex = adminMenu.Run();
                            }
                            break;
                        case 5:
                            RetrieveActiveCourse retrieveActive = new RetrieveActiveCourse();
                            if (retrieveActive.ActiveCourse() == false)
                            {
                                optionIndex = adminMenu.Run();
                            }
                            break;
                        case 6:
                            RetrieveDepartment departm = new RetrieveDepartment();
                            if (departm.getDepartment() == false)
                            {
                                optionIndex = adminMenu.Run();
                            }
                            break;
                        case 7:
                            SetGrade setGrade = new SetGrade();
                            if (setGrade.setGrade() == false)
                            {
                                optionIndex = adminMenu.Run();
                            }
                            break;
                        case 8:
                            AddStudent stud = new AddStudent();
                            if (stud.NewStudent() == false)
                            {
                                optionIndex = adminMenu.Run();
                            }
                            break;
                        case 9:
                            AddEmployee emp = new AddEmployee();
                            if (emp.NewEmployee() == false)
                            {
                                optionIndex = adminMenu.Run();
                            }
                            break;
                        case 10:
                            optionIndex = Exit();
                            break;
                    }
                }
            }
        }
        public override int Exit()
        {
            Console.Clear();
            Console.Write("\nByee");
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Thread.Sleep(150);
                    Console.Write(".");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Thread.Sleep(150);
                    Console.Write(".");
                    Console.ResetColor();
                }
            }
            run = false;
            return 11;
        }
    }
}

