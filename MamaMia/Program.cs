using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DomainModel;

namespace MamaMia
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuService menu = MenuService.GetInstance();

            try
            {
                string input = Console.ReadLine();

                Console.WriteLine(menu.GetOrderSummary(input));
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Error");
                Console.ReadLine();
            }
        }
    }
}
