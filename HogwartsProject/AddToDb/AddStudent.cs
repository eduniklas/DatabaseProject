using System.Data.SqlClient;
using HogwartsProject.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace HogwartsProject.AddToDb
{
    public class AddStudent
    {
        public bool NewStudent()
        {
            Console.Clear();
            string prompt = "What gender is the new student?\n";
            string[] genOptions = { "F", "M" };
            var genMenu = new MenuBuilder(prompt, genOptions, 2, 1);
            int genIndex = genMenu.Run();
            Console.Clear();

            string classPrompt = "Which class is this student joining?\n";
            string[] classOptions = { "Orange", "Apple", "Mango", "Blueberry", "Pineapple", "Pear" };
            var classMenu = new MenuBuilder(classPrompt, classOptions, 2, 1);
            int classIndex = classMenu.Run();
            int studClass = classIndex + 1;
            Console.Clear();

            string firstName = InputAndOutput.setName("Enter first name: ");
            string lastName = InputAndOutput.setName("Enter last name: ");
            string secNum = Convert.ToString(InputAndOutput.ReadIntFromConsole("Enter security number, Ex. 19880310 : "));
            Console.Clear();

            string prompt3 = "Do you want to save this to the database?\n" +
                "\nName: " + firstName + " " + lastName + "\nSecurity number: " + secNum + "\nClass: " + classOptions[classIndex] + "\nGender: " + genOptions[genIndex]+"\n";
            string[] yesOrNo = { "Yes", "No" };
            var save = new MenuBuilder(prompt3, yesOrNo,7,1);
            int optionIndex3 = save.Run();
            Console.Clear();

            if (optionIndex3 == 0)
            {
                string sqlQuery = "Insert Into Students(PersonalNumber, FirstName, LastName, Gender, FK_ClassID)" +
                    "Values(@PN, @FN, @LN, @Gen, @FK_ClassID)";

                
                using (SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true"))
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cn))
                {
                    cmd.Parameters.Add("@PN", System.Data.SqlDbType.NVarChar, 15).Value = secNum;
                    cmd.Parameters.Add("@FN", System.Data.SqlDbType.NVarChar, 50).Value = firstName;
                    cmd.Parameters.Add("@LN", System.Data.SqlDbType.NVarChar, 50).Value = lastName;
                    cmd.Parameters.Add("@Gen", System.Data.SqlDbType.Char, 1).Value = genOptions[genIndex];
                    cmd.Parameters.Add("@FK_ClassID", System.Data.SqlDbType.Int).Value = studClass;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
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
        }
    }
}
