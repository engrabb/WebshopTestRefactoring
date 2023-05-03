using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebshopTest.ContextTest;

namespace WebshopTest
{
    public class QuitCommand : ICommands
    {
        public void Execute(WebShopContext state)
        {
            Console.WriteLine("");
            Environment.Exit(0);
        }
    }
}
