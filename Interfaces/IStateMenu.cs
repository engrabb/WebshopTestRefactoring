﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopTest.Interfaces
{
    public interface IStateMenu
    {
        void ActiveMenu();

        void ChosenOption(string custInput);

    }
}
