using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public abstract class Dish : IServable
    {
        protected DishType m_DishType;

        protected Dish(DishType m_DishType)
        {
            this.m_DishType = m_DishType;
        }

        /// <summary>
        /// Gets the DishType this Dish instance represents
        /// </summary>
        public virtual DishType DishType
        {
            get
            {
                return this.m_DishType;
            }
        }

        /// <summary>
        /// Returns a string representation of a IServable instance.
        /// </summary>
        /// <returns>A string representing a IServable instance</returns>
        public abstract string Serve();

        /// <summary>
        /// Determines where the IServable instance can be served more than once
        /// </summary>
        /// <returns>Whether the IServable instance is servable more than once</returns>
        public virtual bool CanServeMoreThanOnce()
        {
            return false;
        }

        /// <summary>
        /// Returns whether this Dish instance represents an equal type as the provided IServable instance.
        /// </summary>
        /// <param name="other">The other IServable instance to compare with.</param>
        /// <returns>Whether the objects are equal (not reference equal)</returns>
        public virtual bool Equals(IServable other)
        {
            Dish dish = other as Dish;

            if (dish == null)
                return false;

            if (m_DishType == dish.DishType)
                return true;

            return false;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is IServable && Equals((IServable)obj);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return (int)m_DishType;
        }

        /// <summary>
        /// Determines whether the specified System.Object instances are the same instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if objA is the same instance as objB or if both are null; otherwise, false.</returns>
        public bool ReferenceEquals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Serves as the default hash function (reference hash).
        /// </summary>
        /// <returns>A reference hash code for the current object.</returns>
        public int GetReferenceHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compares the current Dish object with another Dish object.
        /// </summary>
        /// <param name="other">An Dish to compare with this Dish object.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The
        ///     return value has the following meanings: Value Meaning Less than zero This object
        ///     is less than the other parameter.Zero This object is equal to other. Greater
        ///     than zero This object is greater than other.</returns>
        public int CompareTo(IServable other)
        {
            Dish otherDish = other as Dish;

            if (otherDish == null)
                return 1;

            return (int)this.DishType - (int)otherDish.DishType;
        }
    }
}
