using HogwartsProject.AddToDb;
using HogwartsProject.Menu;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsProject.Authentication
{
    public class AuthenticateUser
    {
        public bool SignInAdmin(string name, string password)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true");
            string query = "Select UserName, Pword from AdminUsers " +
                "where UserName = '" + name + "' and Pword = '" + password + "' ";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            Console.Clear();

            if (dtbl.Rows.Count == 1)
            {
                AdminMenu adminMenu = new AdminMenu();
                adminMenu.StartAdmin();
                return false;
            }
            else
            {
                Console.WriteLine("\nWrong username or password, try again please\n");
                return true;
            }
        }
        public bool SignInTeacher(string name, string password)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true");
            string query = "Select UserName, Pword from Users " +
                "where UserName = '" + name + "' and Pword = '" + password + "' ";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            Console.Clear();

            if (dtbl.Rows.Count == 1)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Start();
                return false;
            }
            else
            {
                Console.WriteLine("\nWrong username or password, try again please\n");
                return true;
            }
        }
    }
}
