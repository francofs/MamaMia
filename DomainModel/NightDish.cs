using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// This class is a concrete implementation of the Dish class. It represents a dish served only at night.
    /// </summary>
    public class NightDish : Dish
    {
        /// <summary>
        /// Initializes a new NightDish instance with the specified dish type
        /// </summary>
        /// <param name="dishType">The dish type this NightDish instance will represent.</param>
        public NightDish(DishType dishType)
            : base(dishType)
        { }

        /// <summary>
        /// Returns a string representation of a NightDish instance.
        /// </summary>
        /// <returns>A string representing a NightDish instance</returns>
        public override string Serve()
        {
            switch (m_DishType)
            {
                case DishType.Dessert:
                    return "cake";

                case DishType.Drink:
                    return "wine";

                case DishType.Entree:
                    return "steak";

                case DishType.Side:
                    return "potato";

                default:
                    return "error";
            }
        }

        /// <summary>
        /// Determines where the NightDish instance can be served more than once
        /// </summary>
        /// <returns>Whether the NightDish instance is servable more than once</returns>
        public override bool CanServeMoreThanOnce()
        {
            if (m_DishType == DishType.Side)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns whether this NightDish instance represents an equal type as the provided IServable instance.
        /// </summary>
        /// <param name="other">The other IServable instance to compare with.</param>
        /// <returns>Whether the objects are equal (not reference equal).</returns>
        public override bool Equals(IServable other)
        {
            return base.Equals(other) && other is NightDish;
        }
    }
}
