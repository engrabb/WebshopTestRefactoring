﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTest.ContextTest;

namespace WebshopTest
{
    public class SortMenuCommand : ICommands
    {
        public void Execute(WebShopContext state)
        {
            state.SwitchState(new SortMenu());
        }
    }
}
