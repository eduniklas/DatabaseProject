using HogwartsProject.Menu;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;

namespace HogwartsProject.RetreiveFromDb
{
    public class RetrieveEmployee
    {
        public bool GetEmployee()
        {
            Console.Clear();
            string[] options = { "Headmaster", "Teacher", "Caretaker", "Admin", "All employees", "Go back" };
            string prompt = "Retrive employee\n";
            var getEmpMenu = new MenuBuilder(prompt, options,2,1);
            int optionIndex = getEmpMenu.Run();
            Console.Clear();
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true");

            if (optionIndex <= 3)
            {
                SqlDataAdapter sqlda = new SqlDataAdapter("Select Employees.FName, Employees.LName, Roles.RoleName, DATEDIFF(year,FORMAT(Employees.DateOfEmployment,'yyyy-MM-dd'),Current_Timestamp) As Date From Employees " +
                    "Join Roles On RoleID = FK_RoleID" +
                    " where Roles.RoleName = '" + options[optionIndex] + "' ",sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                Console.Clear();
                Console.WriteLine("|{0, -15}|{1, -15}|{2, -13}|{3, -15}|", "First name", "Last name", "Role","Employed years");
                Console.WriteLine(new string('-', 63));
                foreach (DataRow dr in dtbl.Rows)
                {
                    Console.WriteLine("|{0, -15}|{1, -15}|{2, -13}|{3, -15}|", dr["FName"], dr["LName"], dr["RoleName"], dr["Date"]);
                }
                Console.WriteLine(new string('-', 63));
                InputAndOutput.PressToContinue();
                return true;
            }
            else if (optionIndex == 4)
            {
                

                SqlDataAdapter sqlda = new SqlDataAdapter("Select Employees.FName, Employees.LName, Roles.RoleName, Departments.DepartmentName, DATEDIFF(year,FORMAT(Employees.DateOfEmployment,'yyyy-MM-dd'),Current_Timestamp) As Date From Employees " +
                    "Join Roles On RoleID = FK_RoleID " +
                    "Join WorkInDepts On FK_EmployeeID = EmployeeID " +
                    "Join Departments On DepartmentID = FK_DepartmentID " +
                    "Order by DepartmentName", sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                Console.Clear();
                Console.WriteLine("|{0, -15}|{1, -15}|{2, -13}|{3, -15}|{4, -15}|", "First name", "Last name", "Role","Department", "Employed years");
                Console.WriteLine(new string('-', 79));
                foreach (DataRow dr in dtbl.Rows)
                {
                    Console.WriteLine("|{0, -15}|{1, -15}|{2, -13}|{3, -15}|{4, -15}|", dr["FName"], dr["LName"], dr["RoleName"], dr["DepartmentName"], dr["Date"]);
                }
                Console.WriteLine(new string('-', 79));
                InputAndOutput.PressToContinue();
                return true;
            }
            else { return false; }

        } //SQL
    }
}
