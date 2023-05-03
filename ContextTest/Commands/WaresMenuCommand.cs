using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebshopTest.ContextTest;

namespace WebshopTest
{
    public class WaresMenuCommand : ICommands
    {
        public void Execute(WebShopContext state)
        {
            state.SwitchState(new WaresMenu());
        }
    }
}
