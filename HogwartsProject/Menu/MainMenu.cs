using HogwartsProject.RetreiveFromDb;
using HogwartsProject.AddToDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsProject.Menu
{
    public class MainMenu
    {
        bool run = true;
        public void Start()
        {
            Console.Clear();
            string prompt = "Use up and down arrows to navigate and press Enter to select option\n";
            string[] options = { "Retrive employee", "Retrieve student", "Retrieve class", "Retrieve grades", "Retrieve courses & grades","Retrieve active courses", "Set grade", "Exit" };
            var mainMenu = new MenuBuilder(prompt, options, 2, 1);
            int optionIndex = mainMenu.Run();

            while (optionIndex != 8)
            {
                while (run)
                {
                    switch (optionIndex)
                    {
                        case 0:
                            RetrieveEmployee retEmp = new RetrieveEmployee();
                            if (retEmp.GetEmployee() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 1:
                            RetrieveStudent retStud = new RetrieveStudent();
                            if (retStud.GetStudent() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 2:
                            RetrieveStudInClass retClass = new RetrieveStudInClass();
                            if (retClass.GetStudentsInClass() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 3:
                            RetrieveGrade retGrade = new RetrieveGrade();
                            if (retGrade.GetGrades() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 4:
                            RetrieveSubjectAndGrade retSubjectGrade = new RetrieveSubjectAndGrade();
                            if (retSubjectGrade.GetSubjectAndGrade() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 5:
                            RetrieveActiveCourse retrieveActive = new RetrieveActiveCourse();
                            if (retrieveActive.ActiveCourse() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 6:
                            SetGrade grading = new SetGrade();
                            if (grading.setGrade() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 7:
                            optionIndex = Exit();
                            break;
                    }
                }
            }
        }
        public virtual int Exit()
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
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Thread.Sleep(150);
                    Console.Write(".");
                    Console.ResetColor();
                }
            }
            run = false;
            return 8;
        }
    }
}

