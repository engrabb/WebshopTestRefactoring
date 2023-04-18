using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTest.ContextTest;
using static WebshopTest.CustomerMenu;

namespace WebshopTest
{
    public class LoginMenu : IWebshopSystem
    {
        ICustomerBuild build = new CustomerBuilder();
        NavigatorClass nav = new NavigatorClass();
        List<Customer> customers;
        List<string> options;
        string info = "Please submit username and password.";
        int currentChoice;
        int amountOfOptions;
        string username;
        string password;
        Customer currentCustomer;
        public LoginMenu()
        {
            WebShopContext web = new WebShopContext();
            customers = web.customers;
            currentChoice = 1;
            amountOfOptions = 4;
            options = new List<string>();
            options.Add("1. Set Username");
            options.Add("2. Set Password");
            options.Add("3. Login");
            options.Add("4. Register");

        }

        public void CurrentMenu(WebShopContext state)
        {
            Console.WriteLine(info);
            PrintMenu();
            nav.UserButtons(amountOfOptions, currentChoice);
            OptionsNavigator(state);
        }

        private void PrintMenu()
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine(options[i]);
            }

        }
        private void OptionsNavigator(WebShopContext state)
        {
            string choice = Console.ReadLine().ToLower();
            if (currentChoice > 1 && choice == "l" || choice == "left")
            {
                currentChoice--;
            }

            if (currentChoice < amountOfOptions && choice == "r" || choice == "right")
            {
                currentChoice++;
            }
            if (choice == "ok" || choice == "o" || choice == "k")
            {
                if (currentChoice == 1)
                {
                    LoginName();
                }

                if (currentChoice == 2)
                {
                    LoginPassword();
                }

                if (currentChoice == 3)
                {
                    Login(state);
                    state.SwitchState(new MainMenu());

                }
                if (currentChoice == 4)
                {
                    RegisterUser(state);
                    state.SwitchState(new MainMenu());
                }
            }
            if (choice == "back" || choice == "b")
            {
                state.SwitchState(new MainMenu());
            }
            if (choice == "quit" || choice == "q")
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(1);
            }
        }
        private void LoginName()
        {
            Console.WriteLine("A keyboard appears.");
            Console.WriteLine("Please input your username.");
            username = Console.ReadLine();
        }
        private void LoginPassword()
        {
            Console.WriteLine("A keyboard appears.");
            Console.WriteLine("Please input your password.");
            password = Console.ReadLine();
        }
        public void Login(WebShopContext state)
        {
            if (username == null || password == null)
            {
                Console.WriteLine("Incomplete data.");
            }
            if (username != null || password != null)
            {
                bool found = false;
                foreach (Customer customer in state.customers)
                {
                    if (username.Equals(customer.Username) && customer.CheckPassword(password))
                    {
                        Console.WriteLine(customer.Username + " logged in.");
                        currentCustomer = customer;
                        state.CurrentCustomer = currentCustomer;
                        found = true;
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("Invalid credentials.");
                }
            }
        }

        public void RegisterUser(WebShopContext state)
        {
            Customer cust = build.CreateCustomer();
            state.customers = customers;
            customers.Add(cust);
            state.CurrentCustomer = cust;
            Console.WriteLine(cust.Username + " is now registered and logged in!");
        }
    }

}
