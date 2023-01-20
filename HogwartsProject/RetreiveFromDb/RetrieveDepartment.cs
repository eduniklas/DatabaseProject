using HogwartsProject.Data;
using HogwartsProject.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HogwartsProject.RetreiveFromDb
{
    public class RetrieveDepartment
    {
        public bool getDepartment()
        {
            Console.Clear();
            using HogwartsFinalContext context = new HogwartsFinalContext();
            var dept = from d in context.WorkInDepts
                       join e in context.Departments on d.FkDepartmentId equals e.DepartmentId
                       select new { e.DepartmentName, d.FkDepartmentId, d.FkRoleId } into f
                       orderby f.DepartmentName
                       group f by new { f.DepartmentName } into n
                       select new
                       {
                           n.Key.DepartmentName,
                           CountOfEmployees = n.Where(a=>a.FkRoleId== 2).Select(a=>a.FkDepartmentId).Count()

                       };
 
            Console.WriteLine("|{0,-15}|{1,-17}|", "Department", "Teachers in dept");
            Console.WriteLine(new string('-', 35));
            foreach (var d in dept)
            {
                Console.WriteLine("|{0,-15}|{1,-17}|", d.DepartmentName, d.CountOfEmployees);
            }
            Console.WriteLine(new string('-', 35));
            InputAndOutput.PressToContinue();
            PayPerDept();
            InputAndOutput.PressToContinue();
            AvgPay();
            InputAndOutput.PressToContinue();
            return false;
        }
        public void PayPerDept()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true");
            SqlDataAdapter payData = new SqlDataAdapter("Select DepartmentName , SUM(Salary) as SalInDept from WorkInDepts " +
                "join Departments on DepartmentID = FK_DepartmentID " +
                "join Employees on EmployeeID = FK_EmployeeID " +
                "group by DepartmentName " +
                "order by DepartmentName", sqlCon);
            DataTable dtlb= new DataTable();
            payData.Fill(dtlb);
            Console.WriteLine("|{0,-20}|{1,-15}|", "Department","Total pay out");
            Console.WriteLine(new string('-', 38));
            foreach (DataRow sal in dtlb.Rows)
            {
                Console.WriteLine("|{0,-20}|{1,-15}|", sal["DepartmentName"], sal["SalInDept"]);
            }
            Console.WriteLine(new string('-', 38));
        }
        public void AvgPay()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true");
            SqlDataAdapter payData = new SqlDataAdapter("Select DepartmentName , AVG(Salary) as SalInDept from WorkInDepts " +
                "join Departments on DepartmentID = FK_DepartmentID " +
                "join Employees on EmployeeID = FK_EmployeeID " +
                "group by DepartmentName " +
                "order by DepartmentName", sqlCon);
            DataTable dtlb = new DataTable();
            payData.Fill(dtlb);
            Console.WriteLine("|{0,-15}|{1,-15}|", "Department", "Average salary");
            Console.WriteLine(new string('-', 33));
            foreach (DataRow sal in dtlb.Rows)
            {
                Console.WriteLine("|{0,-15}|{1,-15}|", sal["DepartmentName"], sal["SalInDept"]);
            }
            Console.WriteLine(new string('-', 33));
        }
    }
}
