using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTest.ContextTest;

namespace WebshopTest
{
    public class SortMenu : IWebshopSystem
    {
        NavigatorClass nav = new NavigatorClass();
        List<Product> products;
        List<string> options;
        string info = "How would you like to sort them?";
        int currentChoice = 1;
        int amountOfOptions = 4;
        public SortMenu()
        {
            WebShopContext web = new WebShopContext();
            products = web.products;
            currentChoice = 1;
            amountOfOptions = 4;
            options = new List<string>();
            options.Add("1. Sort by name, descending");
            options.Add("2. Sort by name, ascending");
            options.Add("3. Sort by price, descending");
            options.Add("4. Sort by price, ascending");
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
            foreach (string option in options)
            {
                Console.WriteLine(option);
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
                    QuickSort("name", false);
                    state.products = products;
                    Console.WriteLine("Wares are sorted.");
                }
                if (currentChoice == 2)
                {
                    QuickSort("name", true);
                    state.products = products;
                }
                if (currentChoice == 3)
                {
                    QuickSort("price", false);
                    state.products = products;
                    Console.WriteLine("Wares are sorted.");
                }
                if (currentChoice == 4)
                {
                    QuickSort("price", true);
                    state.products = products;
                    Console.WriteLine("Wares are sorted.");
                }
            }
            if (choice == "back" || choice == "b")
            {
                state.SwitchState(new WaresMenu());
            }
            if (choice == "quit" || choice == "q")
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(1);
            }

        }
        public void QuickSort(string variable, bool ascending)
        {
            int left = 0;
            int right = products.Count - 1;
            QuickSortHelper(variable, ascending, left, right);
        }

        public void QuickSortHelper(string variable, bool ascending, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = Partition(variable, ascending, left, right);
                QuickSortHelper(variable, ascending, left, partitionIndex - 1);
                QuickSortHelper(variable, ascending, partitionIndex + 1, right);
            }
        }

        public int Partition(string variable, bool ascending, int left, int right)
        {
            if (variable.Equals("name"))
            {
                string pivot = products[right].Name;
                int i = left - 1;
                for (int j = left; j < right; j++)
                {
                    if (ascending)
                    {
                        if (products[j].Name.CompareTo(pivot) > 0)
                        {
                            i++;
                            Product temp = products[i];
                            products[i] = products[j];
                            products[j] = temp;
                        }
                    }
                    else
                    {
                        if (products[j].Name.CompareTo(pivot) < 0)
                        {
                            i++;
                            Product temp = products[i];
                            products[i] = products[j];
                            products[j] = temp;
                        }
                    }
                }
                Product temp2 = products[i + 1];
                products[i + 1] = products[right];
                products[right] = temp2;
                return i + 1;
            }
            else if (variable.Equals("price"))
            {
                decimal pivot = products[right].Price;
                int i = left - 1;
                for (int j = left; j < right; j++)
                {
                    if (ascending)
                    {
                        if (products[j].Price > pivot)
                        {
                            i++;
                            Product temp = products[i];
                            products[i] = products[j];
                            products[j] = temp;
                        }
                    }
                    else
                    {
                        if (products[j].Price < pivot)
                        {
                            i++;
                            Product temp = products[i];
                            products[i] = products[j];
                            products[j] = temp;
                        }
                    }
                }
                Product temp2 = products[i + 1];
                products[i + 1] = products[right];
                products[right] = temp2;
                return i + 1;
            }
            return -1;
        }
    }

}


    

