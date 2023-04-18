using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopTest
{
    public interface ICustomerBuild
    {
            ICustomerBuild GetUsername();
            ICustomerBuild GetPassword();
            ICustomerBuild GetFirstName();
            ICustomerBuild GetLastName();
            ICustomerBuild GetEmail();
            ICustomerBuild GetAge();
            ICustomerBuild GetAddress();
            ICustomerBuild GetPhoneNumber();
            Customer CreateCustomer();
    }
}
