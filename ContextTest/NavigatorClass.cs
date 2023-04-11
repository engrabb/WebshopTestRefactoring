using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopTest
{
    public class NavigatorClass
    {
        public void UserButtons(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Console.Write(i + 1 + "\t");
            }
            Console.WriteLine();
            for (int i = 1; i < y; i++)
            {
                Console.Write("\t");
            }
            Console.WriteLine("|");
            Console.WriteLine("Your buttons are Left, Right, OK, Back and Quit.");
        }
    }
}
