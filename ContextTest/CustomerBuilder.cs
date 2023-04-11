using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopTest
{
    public class CustomerBuilder : ICustomerBuild
    {
        InputClass inputs = new InputClass();
        Database database = new Database();
        List<Customer> customers;
        public Customer CreateCustomer()
        {
            customers = database.GetCustomers();
            string Username = inputs.GetUsernameString("Whats your username?");
            string Password = inputs.GetStringInput("password");
            string FirstName = inputs.GetStringInput("first name");
            string LastName = inputs.GetStringInput("last name");
            string Email = inputs.GetStringInput("an email");
            int Age = inputs.GetIntInput("age");
            string Address = inputs.GetStringInput("address");
            int PhoneNumber = inputs.GetIntInput("phone number");
            
            Customer newCustomer = new Customer(Username, Password, FirstName, LastName, Email, Age, Address, PhoneNumber);

            return newCustomer;
        }
    }
}
