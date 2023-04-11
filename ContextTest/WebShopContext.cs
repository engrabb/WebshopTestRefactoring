using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopTest.ContextTest
{
    public class WebShopContext
    {
        private IWebshopSystem _state;
        public Customer CurrentCustomer { get; set; }
        public Database Database = new Database();

        public List<Product> products = new List<Product>();
        public WebShopContext()
        {
            products = Database.GetProducts();
            _state = new MainMenu();
        }

        public void SwitchState(IWebshopSystem state)
        {
            _state = state;
        }
        public void CurrentMenu()
        {
            _state.CurrentMenu(this);
           
        }

    }
}
