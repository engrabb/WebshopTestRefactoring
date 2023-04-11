using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTest.ContextTest;

namespace WebshopTest
{
    public class PurchaseMenu : IWebshopSystem
    {
        NavigatorClass nav = new NavigatorClass();
        List<Product> products;
        string info = "What would you like to purchase?";
        int currentChoice;
        int amountOfOptions;
        Customer currentCustomer;
        public PurchaseMenu()
        {
            WebShopContext web = new WebShopContext();
            products = web.products;
            currentChoice = 1;
            amountOfOptions = products.Count;
        }
        public void CurrentMenu(WebShopContext state)
        {
            Console.WriteLine(info);
            currentCustomer = state.CurrentCustomer;
            PrintWares(state);
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
            if (choice == "back" || choice == "b")
            {
                state.SwitchState(new MainMenu());
                state.CurrentMenu();
            }
            if(choice == "ok" || choice == "k" || choice == "o")
            {
                BuyProduct(state);
            }
            if (choice == "quit" || choice == "q")
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(1);
            }

        }
        public void PrintWares(WebShopContext state)
        {
            for (int i = 0; i < state.products.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + state.products[i].Name + ", " + state.products[i].Price + "kr");
            }
            if (currentCustomer != null)
            {
                Console.WriteLine("Your funds: " + currentCustomer.Funds);
            }
        }
        public void BuyProduct(WebShopContext state)
        {
            int index = currentChoice - 1;
            Product product = state.products[index];
            if (product.InStock())
            {
                if (currentCustomer.CanAfford(product.Price))
                {
                    currentCustomer.Funds -= product.Price;
                    product.NrInStock--;
                    currentCustomer.Orders.Add(new Order(product.Name, product.Price, DateTime.Now));
                    Console.WriteLine("\nSuccessfully bought {0}", product.Name);
                }
                else
                {
                    Console.WriteLine("\nYou cannot afford.");
                }
            }
            else
            {
                Console.WriteLine("\nNot in stock.");
            }
        }
    }
}
