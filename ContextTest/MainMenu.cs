using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTest.ContextTest;

namespace WebshopTest
{
    public class MainMenu : IWebshopSystem
    {
        NavigatorClass nav = new NavigatorClass();
        List<string> options;
        string info = "What would you like to do?";
        string Logout = "3. Logout";
        int currentChoice;
        int amountOfOptions;
        Customer currentCustomer;
        public MainMenu()
        {
            currentChoice = 1;
            amountOfOptions = 3;
            options = new List<string>();
            options.Add("1. See Wares");
            options.Add("2. Customer info");
            options.Add("3. Login");
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
            for(int i = 0; i < options.Count; i++)
            {
                if (currentCustomer != null && options[i].Equals("3. Login"))
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
                    state.SwitchState(new WaresMenu());
                }
                if (currentChoice == 2 && currentCustomer != null)
                {
                    state.SwitchState(new CustomerMenu());
                }
                if(currentChoice == 2 && currentCustomer == null)
                {
                    Console.WriteLine("Nobody is logged in!");
                }
                if (currentChoice == 3 && currentCustomer == null)
                {
                    state.SwitchState(new LoginMenu());
                }
                if (currentChoice == 3 && currentCustomer != null)
                {
                    state.CurrentCustomer = null;
                    Console.WriteLine("You have logged out!");
                    state.SwitchState(new MainMenu());
                }
                if (currentChoice == 4)
                {
                    Console.WriteLine("");
                    Environment.Exit(0);
                }
            }
            if (choice == "back" || choice == "b")
            {
                Console.WriteLine("You are already in the main menu!");
            }
            if (choice == "quit" || choice == "q")
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(1);
            }

        }
    }
    
}
