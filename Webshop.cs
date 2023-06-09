﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace WebshopTest
{
    public class WebShop
    {
        bool running = true;
        Database database = new Database();
        List<Product> products = new List<Product>();
        List<Customer> customers = new List<Customer>();
        InputClass checkInput = new InputClass();
        string currentMenu = "main menu";
        int currentChoice = 1;
        int amountOfOptions = 3;
        string option1 = "See Wares";
        string option2 = "Customer Info";
        string option3 = "Login";
        string option4 = "";
        string info = "What would you like to do?";

        string username = null;
        string password = null;
        Customer currentCustomer;
        ICustomerBuilder customerBuilder;

        public WebShop()
        {
            products = database.GetProducts();
            customers = database.GetCustomers();
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the WebShop!");
            while (running)
            {
                Console.WriteLine(info);

                if (currentMenu.Equals("purchase menu"))
                {
                    for (int i = 0; i < amountOfOptions; i++)
                    {
                        Console.WriteLine(i + 1 + ": " + products[i].Name + ", " + products[i].Price + "kr");
                    }
                    Console.WriteLine("Your funds: " + currentCustomer.Funds);
                }
                else
                {
                    Console.WriteLine("1: " + option1);
                    Console.WriteLine("2: " + option2);
                    if (amountOfOptions > 2)
                    {
                        Console.WriteLine("3: " + option3);
                    }

                }

                for (int i = 0; i < amountOfOptions; i++)
                {
                    Console.Write(i + 1 + "\t");
                }
                for (int i = 1; i < currentChoice; i++)
                {
                    Console.Write("\t");
                }
                Console.WriteLine("|");

                Console.WriteLine("Your buttons are Left, Right, OK, Back and Quit.");
                if (currentCustomer != null)
                {
                    Console.WriteLine("Current user: " + currentCustomer.Username);
                }
                else
                {
                    Console.WriteLine("Nobody logged in.");
                }

                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "left":
                    case "l":
                        if (currentChoice > 1)
                        {
                            currentChoice--;
                        }
                        break;
                    case "right":
                    case "r":
                        if (currentChoice < amountOfOptions)
                        {
                            currentChoice++;
                        }
                        break;
                    case "ok":
                    case "k":
                    case "o":
                        if (currentMenu.Equals("main menu"))
                        {
                            switch (currentChoice)
                            {
                                case 1:
                                    option1 = "See all wares";
                                    option2 = "Purchase a ware";
                                    option3 = "Sort wares";
                                    if (currentCustomer == null)
                                    {
                                        option4 = "Login";
                                    }
                                    else
                                    {
                                        option4 = "Logout";
                                    }
                                    amountOfOptions = 4;
                                    currentChoice = 1;
                                    currentMenu = "wares menu";
                                    info = "What would you like to do?";
                                    break;
                                case 2:
                                    if (currentCustomer != null)
                                    {
                                        option1 = "See your orders";
                                        option2 = "Set your info";
                                        option3 = "Add funds";
                                        option4 = "";
                                        amountOfOptions = 3;
                                        currentChoice = 1;
                                        info = "What would you like to do?";
                                        currentMenu = "customer menu";
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nobody is logged in.");
                                    }
                                    break;
                                case 3:
                                    if (currentCustomer == null)
                                    {
                                        option1 = "Set Username";
                                        option2 = "Set Password";
                                        option3 = "Login";
                                        option4 = "Register";
                                        amountOfOptions = 4;
                                        currentChoice = 1;
                                        info = "Please submit username and password.";
                                        username = null;
                                        password = null;
                                        currentMenu = "login menu";
                                    }
                                    else
                                    {
                                        option3 = "Login";

                                        Console.WriteLine(currentCustomer.Username + " logged out.");

                                        currentChoice = 1;
                                        currentCustomer = null;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Not an option.");
                                    break;
                            }
                        }
                        else if (currentMenu.Equals("customer menu"))
                        {
                            switch (currentChoice)
                            {
                                case 1:
                                    currentCustomer.PrintOrders();
                                    break;
                                case 2:
                                    currentCustomer.PrintInfo();
                                    break;
                                case 3:
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
                                    break;
                                default:
                                    Console.WriteLine("Not an option.");
                                    break;
                            }
                        }
                        else if (currentMenu.Equals("sort menu"))
                        {
                            bool back = true;
                            switch (currentChoice)
                            {
                                case 1:
                                    bubbleSort("name", false);
                                    Console.WriteLine("\n", "Wares sorted.");
                                    break;
                                case 2:
                                    bubbleSort("name", true);
                                    Console.WriteLine("\n", "Wares sorted.");
                                    break;
                                case 3:
                                    bubbleSort("price", false);
                                    Console.WriteLine("\n", "Wares sorted.");
                                    break;
                                case 4:
                                    bubbleSort("price", true);
                                    Console.WriteLine("\n", "Wares sorted.");
                                    break;
                                default:
                                    back = false;
                                    Console.WriteLine("\n", "Not an option.");
                                    break;
                            }
                            if (back)
                            {
                                option1 = "See all wares";
                                option2 = "Purchase a ware";
                                option3 = "Sort wares";
                                if (currentCustomer == null)
                                {
                                    option4 = "Login";
                                }
                                else
                                {
                                    option4 = "Logout";
                                }
                                amountOfOptions = 4;
                                currentChoice = 1;
                                currentMenu = "wares menu";
                                info = "What would you like to do?";
                            }
                        }
                        else if (currentMenu.Equals("wares menu"))
                        {
                            switch (currentChoice)
                            {
                                case 1:
                                    foreach (Product product in products)
                                    {
                                        product.PrintInfo();
                                    }
                                    break;
                                case 2:
                                    if (currentCustomer != null)
                                    {
                                        currentMenu = "purchase menu";
                                        info = "What would you like to purchase?";
                                        currentChoice = 1;
                                        amountOfOptions = products.Count;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You must be logged in to purchase wares.");
                                        currentChoice = 1;
                                    }
                                    break;
                                case 3:
                                    option1 = "Sort by name, descending";
                                    option2 = "Sort by name, ascending";
                                    option3 = "Sort by price, descending";
                                    option4 = "Sort by price, ascending";
                                    info = "How would you like to sort them?";
                                    currentMenu = "sort menu";
                                    currentChoice = 1;
                                    amountOfOptions = 4;
                                    break;
                                case 4:
                                    if (currentCustomer == null)
                                    {
                                        option1 = "Set Username";
                                        option2 = "Set Password";
                                        option3 = "Login";
                                        option4 = "Register";
                                        amountOfOptions = 4;
                                        info = "Please submit username and password.";
                                        currentChoice = 1;
                                        currentMenu = "login menu";
                                    }
                                    else
                                    {
                                        option4 = "Login";
                                        Console.WriteLine(currentCustomer.Username + " logged out.");
                                        currentCustomer = null;
                                        currentChoice = 1;
                                    }
                                    break;
                                case 5:
                                    break;
                                default:
                                    Console.WriteLine("Not an option.");
                                    break;
                            }
                        }
                        else if (currentMenu.Equals("login menu"))
                        {
                            switch (currentChoice)
                            {
                                case 1:
                                    Console.WriteLine("A keyboard appears.");
                                    Console.WriteLine("Please input your username.");
                                    username = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("A keyboard appears.");
                                    Console.WriteLine("Please input your password.");
                                    password = Console.ReadLine();
                                    break;
                                case 3:
                                    if (username == null || password == null)
                                    {
                                        Console.WriteLine("\n", "Incomplete data.");
                                    }
                                    else
                                    {
                                        bool found = false;
                                        foreach (Customer customer in customers)
                                        {
                                            if (username.Equals(customer.Username) && customer.CheckPassword(password))
                                            {
                                                Console.WriteLine(customer.Username + " logged in.");
                                                currentCustomer = customer;
                                                found = true;
                                                option1 = "See Wares";
                                                option2 = "Customer Info";
                                                if (currentCustomer == null)
                                                {
                                                    option3 = "Login";
                                                }
                                                else
                                                {
                                                    option3 = "Logout";
                                                }
                                                info = "What would you like to do?";
                                                currentMenu = "main menu";
                                                currentChoice = 1;
                                                amountOfOptions = 3;
                                                break;
                                            }
                                        }
                                        if (found == false)
                                        {
                                            Console.WriteLine("Invalid credentials.");
                                        }
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("Please write your username.");
                                    string newUsername = Console.ReadLine();
                                    foreach (Customer customer in customers)
                                    {
                                        if (customer.Username.Equals(username))
                                        {
                                            Console.WriteLine("Username already exists.");
                                            break;
                                        }
                                    }
                                    // Would have liked to be able to quit at any time in here.
                                    choice = "";
                                    bool next = false;
                                    string newPassword = null;
                                    string firstName = null;
                                    string lastName = null;
                                    string email = null;
                                    int age = -1;
                                    string address = null;
                                    int phoneNumber = 0;
                                    while (true)
                                    {
                                        Console.WriteLine("Do you want a password? y/n");
                                        choice = Console.ReadLine();
                                        if (choice.Equals("y"))
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("Please write your password.");
                                                newPassword = Console.ReadLine();
                                                if (newPassword.Equals(""))
                                                {
                                                    Console.WriteLine("\n", "Please actually write something.");
                                                    continue;
                                                }
                                                else
                                                {
                                                    next = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (choice.Equals("n") || next)
                                        {
                                            next = false;
                                            break;
                                        }
                                        Console.WriteLine("y or n, please.");
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Do you want a first name? y/n");
                                        choice = Console.ReadLine();
                                        if (choice.Equals("y"))
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("Please write your first name.");
                                                firstName = Console.ReadLine();
                                                if (firstName.Equals(""))
                                                {
                                                    Console.WriteLine("\n", "Please actually write something.");
                                                    continue;
                                                }
                                                else
                                                {
                                                    next = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (choice.Equals("n") || next)
                                        {
                                            next = false;
                                            break;
                                        }
                                        Console.WriteLine("\n", "y or n, please.");
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Do you want a last name? y/n");
                                        choice = Console.ReadLine();
                                        if (choice.Equals("y"))
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("Please write your last name.");
                                                lastName = Console.ReadLine();
                                                if (lastName.Equals(""))
                                                {
                                                    Console.WriteLine("\n", "Please actually write something.");
                                                    continue;
                                                }
                                                else
                                                {
                                                    next = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (choice.Equals("n") || next)
                                        {
                                            next = false;
                                            break;
                                        }
                                        Console.WriteLine("\n", "y or n, please.");
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Do you want an email? y/n");
                                        choice = Console.ReadLine();
                                        if (choice.Equals("y"))
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("Please write your email.");
                                                email = Console.ReadLine();
                                                if (email.Equals(""))
                                                {
                                                    Console.WriteLine("\n", "Please actually write something.");
                                                    continue;
                                                }
                                                else
                                                {
                                                    next = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (choice.Equals("n") || next)
                                        {
                                            next = false;
                                            break;
                                        }
                                        Console.WriteLine("\n", "y or n, please.");
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Do you want an age? y/n");
                                        choice = Console.ReadLine();
                                        if (choice.Equals("y"))
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("Please write your age.");
                                                string ageString = Console.ReadLine();
                                                try
                                                {
                                                    age = int.Parse(ageString);
                                                }
                                                catch (FormatException e)
                                                {
                                                    Console.WriteLine("\n", "Please write a number.");
                                                    continue;
                                                }
                                                next = true;
                                                break;
                                            }
                                        }
                                        if (choice.Equals("n") || next)
                                        {
                                            next = false;
                                            break;
                                        }
                                        Console.WriteLine("\n", "y or n, please.");
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Do you want an address? y/n");
                                        choice = Console.ReadLine();
                                        if (choice.Equals("y"))
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("Please write your address.");
                                                address = Console.ReadLine();
                                                if (address.Equals(""))
                                                {
                                                    Console.WriteLine("\n", "Please actually write something.");
                                                    continue;
                                                }
                                                else
                                                {
                                                    next = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (choice.Equals("n") || next)
                                        {
                                            next = false;
                                            break;
                                        }
                                        Console.WriteLine("\n", "y or n, please.");
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Do you want a phone number? y/n");
                                        choice = Console.ReadLine();
                                        if (choice.Equals("y"))
                                        {
                                            while (true)
                                            {

                                                Console.WriteLine("Please write your age.");
                                                string nrString = Console.ReadLine();
                                                try
                                                {
                                                    phoneNumber = int.Parse(nrString);
                                                }
                                                catch (FormatException e)
                                                {
                                                    Console.WriteLine("\n", "Please write a number.");
                                                    continue;
                                                }
                                            }
                                        }
                                        if (choice.Equals("n") || next)
                                        {
                                            break;
                                        }
                                        Console.WriteLine("\n", "y or n, please.");
                                    }

                                    Customer newCustomer = new Customer(newUsername, newPassword, firstName, lastName, email, age, address, phoneNumber);
                                    customers.Add(newCustomer);
                                    currentCustomer = newCustomer;
                                    Console.WriteLine("\n", newCustomer.Username + " successfully added and is now logged in.");
                                    option1 = "See Wares";
                                    option2 = "Customer Info";
                                    if (currentCustomer == null)
                                    {
                                        option3 = "Login";
                                    }
                                    else
                                    {
                                        option3 = "Logout";
                                    }
                                    info = "What would you like to do?";
                                    currentMenu = "main menu";
                                    currentChoice = 1;
                                    amountOfOptions = 3;
                                    break;
                                default:
                                    Console.WriteLine("\n", "Not an option.");
                                    break;
                            }
                        }
                        else if (currentMenu.Equals("purchase menu"))
                        {
                            int index = currentChoice - 1;
                            Product product = products[index];
                            if (product.InStock())
                            {
                                if (currentCustomer.CanAfford(product.Price))
                                {
                                    currentCustomer.Funds -= product.Price;
                                    product.NrInStock--;
                                    currentCustomer.Orders.Add(new Order(product.Name, product.Price, DateTime.Now));
                                    Console.WriteLine("\n", "Successfully bought " + product.Name);
                                }
                                else
                                {
                                    Console.WriteLine("\n", "You cannot afford.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n", "Not in stock.");
                            }
                        }
                        break;
                    case "back":
                    case "b":
                        if (currentMenu.Equals("main menu"))
                        {
                            Console.WriteLine("You're already on the main menu.");
                        }
                        else if (currentMenu.Equals("purchase menu"))
                        {
                            option1 = "See all wares";
                            option2 = "Purchase a ware";
                            option3 = "Sort wares";
                            if (currentCustomer == null)
                            {
                                option4 = "Login";
                            }
                            else
                            {
                                option4 = "Logout";
                            }
                            amountOfOptions = 4;
                            currentChoice = 1;
                            currentMenu = "wares menu";
                            info = "What would you like to do?";
                        }
                        else
                        {
                            option1 = "See Wares";
                            option2 = "Customer Info";
                            if (currentCustomer == null)
                            {
                                option3 = "Login";
                            }
                            else
                            {
                                option3 = "Logout";
                            }
                            info = "What would you like to do?";
                            currentMenu = "main menu";
                            currentChoice = 1;
                            amountOfOptions = 3;
                        }
                        break;
                    case "quit":
                    case "q":
                        Console.WriteLine("The console powers down. You are free to leave.");
                        return;
                    default:
                        Console.WriteLine("That is not an applicable option.");
                        break;
                }
            }
        }
        private void bubbleSort(string variable, bool ascending)
        {
            if (variable.Equals("name"))
            {
                int length = products.Count;
                for (int i = 0; i < length - 1; i++)
                {
                    bool sorted = true;
                    int length2 = length - i;
                    for (int j = 0; j < length2 - 1; j++)
                    {
                        if (ascending)
                        {
                            if (products[j].Name.CompareTo(products[j + 1].Name) < 0)
                            {
                                Product temp = products[j];
                                products[j] = products[j + 1];
                                products[j + 1] = temp;
                                sorted = false;
                            }
                        }
                        else
                        {
                            if (products[j].Name.CompareTo(products[j + 1].Name) > 0)
                            {
                                Product temp = products[j];
                                products[j] = products[j + 1];
                                products[j + 1] = temp;
                                sorted = false;
                            }
                        }
                    }
                    if (sorted == true)
                    {
                        break;
                    }
                }
            }
            else if (variable.Equals("price"))
            {
                int length = products.Count;
                for (int i = 0; i < length - 1; i++)
                {
                    bool sorted = true;
                    int length2 = length - i;
                    for (int j = 0; j < length2 - 1; j++)
                    {
                        if (ascending)
                        {
                            if (products[j].Price > products[j + 1].Price)
                            {
                                Product temp = products[j];
                                products[j] = products[j + 1];
                                products[j + 1] = temp;
                                sorted = false;
                            }
                        }
                        else
                        {
                            if (products[j].Price < products[j + 1].Price)
                            {
                                Product temp = products[j];
                                products[j] = products[j + 1];
                                products[j + 1] = temp;
                                sorted = false;
                            }
                        }
                    }
                    if (sorted == true)
                    {
                        break;
                    }
                }
            }
        }
    }
}*/
