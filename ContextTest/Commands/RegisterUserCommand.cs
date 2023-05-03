using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTest.ContextTest;

namespace WebshopTest
{
    public class RegisterUserCommand : ICommands
    {
        ICustomerBuild build = new CustomerBuilder();
        List<Customer> customers;
        public void Execute(WebShopContext state)
        {
            WebShopContext web = new WebShopContext();
            customers = web.customers;
            Customer cust = build.CreateCustomer();
            state.customers = customers;
            customers.Add(cust);
            state.CurrentCustomer = cust;
            Console.WriteLine(cust.Username + " is now registered and logged in!");
        }
    }
}
