using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IServable : IEquatable<IServable>, IComparable<IServable>
    {
        /// <summary>
        /// Returns a string representation of a IServable instance.
        /// </summary>
        /// <returns>A string representing a IServable instance</returns>
        string Serve();

        /// <summary>
        /// Determines where the IServable instance can be served more than once
        /// </summary>
        /// <returns>Whether the IServable instance is servable more than once</returns>
        bool CanServeMoreThanOnce();
    }
}
