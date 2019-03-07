using KKB.BLL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KKB.WEB.model
{
    public class ServiceMenu
    {
        private User user = null;
        public void MainMenu()
        {
            Console.WriteLine("1.Registration");
            Console.WriteLine("2.LogOn");
            Console.WriteLine(": ");
            int choice = Int32.Parse(Console.ReadLine());
            if (choice == 1)
            {
                RegistrationMenu();
            }
            else if (choice == 2)
            {
                LogOnMenu();
            }
        }

        private void LogOnMenu()
        {
            string login = "";
            string password = "";
            string message = "";
            Console.WriteLine("Enter login: ");
            login = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            password = Console.ReadLine();
            ServiceUser susr = new ServiceUser();
            user = susr.LogOn(login, password, out message);
            if (user != null)
            {
                AutoriseUserMenu();
            }
            else
            {
                Console.WriteLine(message);
                Thread.Sleep(3000);
                MainMenu();
            }
        }

        private void RegistrationMenu()
        {
            User user = new User();
            Console.Write("Enter login: ");
            user.login = Console.ReadLine();
            Console.Write("Enter password: ");
            user.password = Console.ReadLine();
            Console.Write("Enter your name: ");
            user.fullname = Console.ReadLine();
            Console.Write("Enter your IIN");
            user.iin = Console.ReadLine();

            string message = "";
            ServiceUser susr = new ServiceUser();
            if (susr.Registration(user, out message))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;

                Thread.Sleep(3000);
                MainMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
            }

               
        }

        public void AutoriseUserMenu()
        {
            Console.WriteLine("Приветствую вас {0}", user.fullname);

            Console.WriteLine("1. Вывод баланса");
            Console.WriteLine("2. Пополнение баланса");
            Console.WriteLine("3. Снять деньги со счета");
            Console.WriteLine("4. Выход");
        }
    }
}
