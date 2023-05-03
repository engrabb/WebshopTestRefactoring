using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTest.ContextTest;
namespace WebshopTest
{
    public class WaresMenu : IWebshopSystem
    {
        NavigatorClass nav = new NavigatorClass();
        Dictionary<string, ICommands> commands;
        List<Product> products;
        List<string> options;
        string info = "What would you like to do?";
        int currentChoice;
        int amountOfOptions;
        Customer currentCustomer;
        string Logout = "4. Logout";
        
        public WaresMenu()
        {
            WebShopContext web = new WebShopContext();
            products = web.products;
            currentChoice = 1;
            amountOfOptions = 4;
            options = new List<string>();
            commands = new Dictionary<string, ICommands>();
            options.Add("1. See all wares");
            options.Add("2. Purchase a ware");
            options.Add("3. Sort wares");
            options.Add("4. Login");
            commands.Add("3", new SortMenuCommand());
            commands.Add("4", new LoginMenuCommand());
        }
        public void CurrentMenu(WebShopContext state)
        {
            Console.WriteLine(info);
            currentCustomer = state.CurrentCustomer;
            PrintMenu();
            nav.UserButtons(amountOfOptions, currentChoice);
            OptionsNavigator(state);
        }
        private void PrintMenu()
        {
            for (int i = 0; i < options.Count; i++)
            {
                if (currentCustomer != null && options[i].Equals("4. Login"))
                {
                    options[i] = Logout;
                }
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
                    foreach (Product product in state.products)
                    {
                        product.PrintInfo();
                    }
                }
                if (currentChoice == 2 && currentCustomer != null)
                {
                    state.SwitchState(new PurchaseMenu());
                }
                if (currentChoice == 2 && currentCustomer == null)
                {
                    Console.WriteLine("You have to be logged in to purchase a ware.");
                }
                if (currentChoice == 4 && currentCustomer != null)
                {
                    state.CurrentCustomer = null;
                    Console.WriteLine("You have logged out!");
                }
                ExecuteCommand(currentChoice, state);

            }
            if (choice == "back" || choice == "b")
            {
                state.SwitchState(new MainMenu());
                state.CurrentMenu();
            }
            if(choice == "quit" || choice == "q")
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(1);
            }
        }
        public void ExecuteCommand(int currentChoice, WebShopContext state)
        {
            string choice = Convert.ToString(currentChoice);
            if (commands.ContainsKey(choice))
            {
                commands[choice].Execute(state);
            }
        }
    }
}
