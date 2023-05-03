using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebshopTest.ContextTest;

namespace WebshopTest
{
    public class LogoutCommand : ICommands
    {
        public void Execute(WebShopContext state)
        {
            state.CurrentCustomer = null;
            Console.WriteLine("You have logged out!");
            state.SwitchState(new MainMenu());
        }
    }
}
