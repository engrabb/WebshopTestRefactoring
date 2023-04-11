using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using WebshopTest.ContextTest;

namespace WebshopTest
{
    public class CustomerMenu : IWebshopSystem
    {
        NavigatorClass nav = new NavigatorClass();
        List<string> options;
        string info = "What would you like to do?";
        int currentChoice = 1;
        int amountOfOptions = 3;
        Customer currentCustomer;


        public CustomerMenu()
        {
            currentChoice = 1;
            amountOfOptions = 3;
            options = new List<string>();
            options.Add("1. See your orders");
            options.Add("2. See your info");
            options.Add("3. Add funds");
            
        }
        public void CurrentMenu(WebShopContext state)
        {
            Console.WriteLine(info);
            currentCustomer = state.CurrentCustomer;
            PrintMenu();
            nav.UserButtons(amountOfOptions, currentChoice);
            OptionsNavigator(state);

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
                    currentCustomer.PrintOrders();
                }

                if (currentChoice == 2)
                {
                    currentCustomer.PrintInfo();
                }
                if(currentChoice == 3)
                {
                    AddFunds();
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

        private void PrintMenu()
        {
            foreach (string option in options)
            {
                Console.WriteLine(option);
            }

        }

        private void AddFunds()
        {
            Console.WriteLine("How many funds would you like to add?");
            string amountString = Console.ReadLine();
            try
            {
                int amount = int.Parse(amountString);
                if (amount < 0)
                {
                    Console.WriteLine("Don't add negative amounts.");
                }
                else
                {
                    currentCustomer.Funds += amount;
                    Console.WriteLine(amount + " added to your profile.");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please write a number next time.");
            }
        }

    }
    
}
