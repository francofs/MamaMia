using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class MorningDish : Dish
    {
        /// <summary>
        /// Initializes a new MorningDish instance with the specified dish type
        /// </summary>
        /// <param name="dishType">The dish type this MorningDish instance will represent.</param>
        public MorningDish(DishType dishType)
            : base(dishType)
        { }

        /// <summary>
        /// Returns a string representation of a MorningDish instance.
        /// </summary>
        /// <returns>A string representing a MorningDish instance</returns>
        public override string Serve()
        {
            switch (m_DishType)
            {
                case DishType.Drink:
                    return "coffee";

                case DishType.Entree:
                    return "eggs";

                case DishType.Side:
                    return "toast";

                default:
                    return "error";
            }
        }

        /// <summary>
        /// Determines where the MorningDish instance can be served more than once
        /// </summary>
        /// <returns>Whether the MorningDish instance is servable more than once</returns>
        public override bool CanServeMoreThanOnce()
        {
            if (m_DishType == DishType.Drink)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns whether this MoringDish instance represents an equal type as the provided IServable instance.
        /// </summary>
        /// <param name="other">The other IServable instance to compare with.</param>
        /// <returns>Whether the objects are equal (not reference equal).</returns>
        public override bool Equals(IServable other)
        {
            return base.Equals(other) && other is MorningDish;
        }
    }
}
