using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebshopTest.ICustomerBuild;

namespace WebshopTest
{
    public class CustomerBuilder : ICustomerBuild
    {
        InputClass inputs = new InputClass();
        private string username;
        private string password;
        private string firstName;
        private string lastName;
        private string email;
        private int age;
        private string address;
        private int phoneNumber;

        public ICustomerBuild GetUsername()
        {
            string Username = inputs.GetUsernameString("Please write your username. ");
            username = Username;
            return this;
        }

        public ICustomerBuild GetPassword()
        {
            string Password = inputs.GetStringInput("password");
            password = Password;
            return this;
        }

        public ICustomerBuild GetFirstName()
        {
            string FirstName = inputs.GetStringInput("first name");
            firstName = FirstName;
            return this;
        }

        public ICustomerBuild GetLastName()
        {
            string LastName = inputs.GetStringInput("last name");
            lastName = LastName;
            return this;
        }

        public ICustomerBuild GetEmail()
        {
            string Email = inputs.GetStringInput("an email");
            email = Email;
            return this;
        }

        public ICustomerBuild GetAge()
        {
            int Age = inputs.GetIntInput("age");
            age = Age;
            return this;
        }

        public ICustomerBuild GetAddress()
        {
            string Address = inputs.GetStringInput("address");
            address = Address;
            return this;
        }

        public ICustomerBuild GetPhoneNumber()
        {
            int PhoneNumber = inputs.GetIntInput("phone number");
            phoneNumber = PhoneNumber;
            return this;
        }
        public Customer CreateCustomer()
        {
            
             GetUsername();
             GetPassword();
             GetFirstName();
             GetLastName();
             GetEmail();
             GetAge();
             GetAddress();
             GetPhoneNumber();

             return new Customer(username, password, firstName, lastName, email, age, address, phoneNumber);
             
            
        }
    }
}

