using HogwartsProject.Data;
using HogwartsProject.Menu;
using HogwartsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsProject.RetreiveFromDb
{
    public class RetrieveStudInClass
    {
        public bool GetStudentsInClass()
        {
            Console.WriteLine("\nThis might take awhile..");
            using (var context = new HogwartsFinalContext())
            {
                var allClasses = from c in context.Classes
                                 select c;
                Console.Clear();
                Console.WriteLine("|{0,-15}|{1,-15}|", "Class name", "Year");
                Console.WriteLine(new string('-', 33));
                foreach (var Cl in allClasses)
                {
                    Console.WriteLine("|{0,-15}|{1,-15}|", Cl.ClassName, Cl.ClassYear);
                }
                Console.WriteLine(new string('-', 33));
                InputAndOutput.PressToContinue();

                string[] options = { "Orange", "Apple", "Mango", "Blueberry", "Pineapple", "Pear" };
                string prompt = "Choose wich class you want to look up\n";
                var chooseClass = new MenuBuilder(prompt, options,2,1);
                int orderIndex = chooseClass.Run();
                string classInput = options[orderIndex];
                Console.Clear();

                string[] options2 = { "FirstName", "LastName", "FirstName DESC", "LastName DESC" };
                string prompt2 = "What order do you want the students in?\n";
                var chooseOrder = new MenuBuilder(prompt2, options2,2,1);
                int orderIndex2 = chooseOrder.Run();
                string orderInput = options2[orderIndex2];
                Console.Clear();

                switch (orderIndex2)
                {
                    case 0:
                        var studInClass = from c in context.Classes
                                          where c.ClassName == classInput
                                          join s in context.Students on c.ClassId equals s.FkClassId
                                          orderby s.FirstName
                                          select new
                                          {
                                              s.FirstName,
                                              s.LastName,
                                              c.ClassName,
                                          };
                        Console.Clear();
                        Console.WriteLine("|{0,-15}|{1,-15}|{2, -15}|", "Class name", "First name", "Last name");
                        Console.WriteLine(new string('-', 49));
                        foreach (var stud in studInClass)
                        {
                            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|", stud.ClassName, stud.FirstName, stud.LastName);
                        }
                        Console.WriteLine(new string('-', 49));
                        InputAndOutput.PressToContinue();
                        break;

                    case 1:
                        var studInClass1 = from c in context.Classes
                                           where c.ClassName == classInput
                                           join s in context.Students on c.ClassId equals s.FkClassId
                                           orderby s.LastName
                                           select new
                                           {
                                               s.FirstName,
                                               s.LastName,
                                               c.ClassName,
                                           };
                        Console.Clear();
                        Console.WriteLine("|{0,-15}|{1,-15}|{2, -15}|", "Class name", "First name", "Last name");
                        Console.WriteLine(new string('-', 49));
                        foreach (var stud in studInClass1)
                        {
                            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|", stud.ClassName, stud.FirstName, stud.LastName);
                        }
                        Console.WriteLine(new string('-', 49));
                        InputAndOutput.PressToContinue();
                        break;

                    case 2:
                        var studInClass2 = from c in context.Classes
                                           where c.ClassName == classInput
                                           join s in context.Students on c.ClassId equals s.FkClassId
                                           orderby s.FirstName descending
                                           select new
                                           {
                                               s.FirstName,
                                               s.LastName,
                                               c.ClassName,
                                           };
                        Console.Clear();
                        Console.WriteLine("|{0,-15}|{1,-15}|{2, -15}|", "Class name", "First name", "Last name");
                        Console.WriteLine(new string('-', 49));
                        foreach (var stud in studInClass2)
                        {
                            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|", stud.ClassName, stud.FirstName, stud.LastName);
                        }
                        Console.WriteLine(new string('-', 49));
                        InputAndOutput.PressToContinue();
                        break;

                    case 3:
                        var studInClass3 = from c in context.Classes
                                           where c.ClassName == classInput
                                           join s in context.Students on c.ClassId equals s.FkClassId
                                           orderby s.LastName descending
                                           select new
                                           {
                                               s.FirstName,
                                               s.LastName,
                                               c.ClassName,
                                           };
                        Console.Clear();
                        Console.WriteLine("|{0,-15}|{1,-15}|{2, -15}|", "Class name", "First name", "Last name");
                        Console.WriteLine(new string('-', 49));
                        foreach (var stud in studInClass3)
                        {
                            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|", stud.ClassName, stud.FirstName, stud.LastName);
                        }
                        Console.WriteLine(new string('-', 49));
                        InputAndOutput.PressToContinue();
                        break;

                }
            };
            return false;
        } //E-F
    }
}
