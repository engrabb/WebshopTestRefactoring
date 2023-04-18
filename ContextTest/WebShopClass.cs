using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTest.ContextTest;

namespace WebshopTest
{
    public class WebShopClass
    {
        bool running = true;
        public WebShopClass()
        {

        }

        public void Run()
        {
            WebShopContext webbe = new WebShopContext();
            Console.WriteLine("Welcome to the WebShop!");
            while (running)
            {
                webbe.CurrentMenu();
            }
        }
    }
}
