using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using HogwartsProject.Authentication;

namespace HogwartsProject.Menu
{
    public class LogInMenu : AuthenticateUser
    {
        bool run = true;
        public void login()
        {
            string prompt = "Are you admin or a teacher?";
            string[] adOrTea = { "Admin", "Teacher" };
            var loginAs = new MenuBuilder(prompt, adOrTea, 2, 1);
            int index = loginAs.Run();
            while (run)
            {
                switch (index)
                {
                    case 0:
                        string name = InputAndOutput.setName("Enter username: ");
                        string password = InputAndOutput.setName("Enter password: ");
                        if (SignInAdmin(name, password) == false)
                            run = false;
                        break;
                    case 1:
                        name = InputAndOutput.setName("Enter username: ");
                        password = InputAndOutput.setName("Enter password: ");
                        if (SignInTeacher(name, password) == false)
                            run = false;
                        break;
                }
            }
        }
    }
}
