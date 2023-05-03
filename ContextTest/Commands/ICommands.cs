using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTest.ContextTest;

namespace WebshopTest
{
    public interface ICommands
    {
        void Execute(WebShopContext state);
    }
}
