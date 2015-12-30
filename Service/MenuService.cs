using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MenuService
    {
        private static MenuService m_SingletonInstance;

        static MenuService()
        {
            m_SingletonInstance = new MenuService();
        }

        private MenuService()
        { }

        public static MenuService GetInstance()
        {
            return m_SingletonInstance;
        }

        public string GetOrderSummary(string input)
        {
            if (input == null || input.Length <= 1)
                throw new ArgumentException("Input argument must have at least two instances separated by comma.");

            string[] turns = new string[] { "morning", "night" };
            string[] inputArr = input.ToLower().Split(',');
            string output = string.Empty;

            if (!turns.Contains(inputArr[0]))
                throw new ArgumentException("First input argument must be either morning or night");

            string dishDescription = inputArr[0];
            int dishType = 0;

            Order order = new Order();
            for (int i = 1; i < inputArr.Length; i++)
            {
                if (!int.TryParse(inputArr[i], out dishType))
                    throw new ArgumentException("All arguments after the first must be numeric.");

                order.AddServable(CreateDishInstance(dishDescription, (DishType)dishType));
            }

            output = order.OrderSummary;

            return output;
        }

        private Dish CreateDishInstance(string description, DishType dishType)
        {
            if (description == "morning")
                return new MorningDish(dishType);

            if (description == "night")
                return new NightDish(dishType);

            return null;
        }
    }
}
