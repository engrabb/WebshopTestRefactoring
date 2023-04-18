using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTest.ContextTest;

namespace WebshopTest
{

    public class InputClass
    {
        public List<Customer> customers;
        Database database = new Database();
        string username;
        public string GetStringInput(string message)
        {
            Console.WriteLine("Do you want a " + message + "? y/n");
            string choice = Console.ReadLine();
            if (choice.Equals("y"))
            {
                return GetUserInfo(message);
            }
            return "";
        }
        public string GetUserInfo(string message)
        {
            while (true)
            {
                Console.WriteLine("Please write your " + message + ".");
                string input = Console.ReadLine();
                if (input.Equals(""))
                {
                    Console.WriteLine("Please actually write something.");
                    continue;
                }
                if(input != null)
                {
                    return input;
                }
            }
        }
        public int GetIntInput(string message)
        {
            int intInput;
                Console.WriteLine("Do you want an " + message + "? y/n");
                string choice = Console.ReadLine();
                if (choice.Equals("y"))
                {
                 return GetIntUserInfo(message);
                }
                return 0;
        }
        public int GetIntUserInfo(string message)
        {
            while (true)
            {
                Console.WriteLine("Please write your " + message + ".");
                string input = Console.ReadLine();
                try
                {
                    if (input.Equals(""))
                    {
                        Console.WriteLine("Please actually write something.");
                        continue;
                    }
                    if(input != null)
                    {
                        return Convert.ToInt32(input);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Not a valid input!");
                }
            }
        }
        public string GetUsernameString(string message)
        {
            string stringInput;
            while (true)
            {
                Console.WriteLine(message);
                stringInput = Console.ReadLine();
                if (stringInput == null || stringInput == "")
                {
                    CheckAvailableUsername();
                    Console.WriteLine("Please actually write something.");
                    continue;
                }
                return stringInput;
            }
        }
        public void CheckAvailableUsername()
        {
            
            database.GetCustomers();
            foreach (Customer customer in customers)
            {
                if (customer.Username.Equals(username))
                {
                    Console.WriteLine("Username already exists.");
                    break;
                }
            }
        }
    }
}
