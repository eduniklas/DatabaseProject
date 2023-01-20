using HogwartsProject.Menu;
using HogwartsProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HogwartsProject.AddToDb
{
    public class SetGrade
    {
        public bool setGrade()
        {
            Console.Clear();
            SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true");

            string subPrompt = "Which subject do you want to grade?";
            string[] subOption = { "Math", "English", "Swedish", "Construction", "Webbdev", "Dance", };
            var subMenu = new MenuBuilder(subPrompt, subOption, 2, 1);
            int subIndex = subMenu.Run();

            SqlDataAdapter diffData = new SqlDataAdapter("Select SubjectID, SubjectName, SubjectDifficulty from Subjects " +
                "Where SubjectName = '" + subOption[subIndex] +"' " +
                "Order by SubjectDifficulty ",cn);
            DataTable diffTbl= new DataTable();
            diffData.Fill(diffTbl);

            Console.Clear();
            Console.WriteLine("|{0,-15}|{1,-15}|", "SubjectID", "SubjectDifficulty");
            foreach (DataRow diff in diffTbl.Rows)
            {
                Console.WriteLine("|{0,-15}|{1,-15}|",diff["SubjectID"], diff["SubjectDifficulty"]);
            }
            int subId = InputAndOutput.ReadIntFromConsole("\nEnter ID for difficulty of the subject: ");

            SqlDataAdapter sqlData = new SqlDataAdapter("Select Concat(FirstName, ' ', LastName) As Student, StudentID from Students", cn);
            DataTable studData = new DataTable();
            sqlData.Fill(studData);

            Console.Clear();
            Console.WriteLine("|{0,-20}|{1,-5}|", "Student", "ID");
            Console.WriteLine(new string('-', 28));
            foreach (DataRow stud in studData.Rows)
            {
                Console.WriteLine("|{0,-20}|{1,-5}|", stud["Student"], stud["StudentID"]);
            }
            Console.WriteLine(new string('-', 28));
            int studId = InputAndOutput.ReadIntFromConsole("\nEnter student ID: ");
            Console.Clear();
            string gradePrompt = "What grade do this student get?";
            string[] gradeOption = { "1", "2", "3", "4", "5" };
            var gradeMenu = new MenuBuilder(gradePrompt, gradeOption, 2, 1);
            int gradeIndex = gradeMenu.Run();
            Console.Clear();



            string prompt3 = "Do you want to save this to the database?\n\n" +
                "Student ID: " + studId + "\nSubject: " + subOption[subIndex] + "\nGrade: " + gradeOption[gradeIndex] + "\n";
            string[] yesOrNo = { "Yes", "No" };
            var save = new MenuBuilder(prompt3, yesOrNo, 5, 1);
            int optionIndex3 = save.Run();
            Console.Clear();

            if (optionIndex3 == 0)
            {
                string sqlQuery = "Insert into TakingSubjects(FK_StudentID, FK_SubjectID, GradeDate, FK_GradeID)" +
                    "Values(@Stud, @Sub, @GD, @Grade)";
                try
                {
                    using (TransactionScope updateTransaction = new TransactionScope())
                    {
                        using SqlConnection cn2 = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true");
                        cn2.Open();
                        using (SqlCommand cmd = new SqlCommand(sqlQuery, cn2))
                        {
                            cmd.Parameters.Add("@Stud", SqlDbType.Int).Value = studId;
                            cmd.Parameters.Add("@Sub", SqlDbType.Int).Value = subId;
                            cmd.Parameters.Add("@GD", SqlDbType.Date).Value = DateTime.Now;
                            cmd.Parameters.Add("@Grade", SqlDbType.Int).Value = gradeIndex + 1;

                            cmd.ExecuteNonQuery();
                        }
                        
                        updateTransaction.Complete();

                    }
                    InputAndOutput.Saved();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

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

