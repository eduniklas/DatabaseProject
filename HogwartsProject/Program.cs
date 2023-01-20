using HogwartsProject.Data;
using HogwartsProject.Menu;
using HogwartsProject.RetreiveFromDb;
using Microsoft.EntityFrameworkCore;

namespace HogwartsProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogInMenu logIn = new LogInMenu();
            logIn.login();
        }
    }
}