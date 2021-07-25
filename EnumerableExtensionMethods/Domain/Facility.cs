using System;
using System.Collections.Generic;
using Domain.Contracts;

namespace Domain
{
    /// <summary>
    /// A Facility is a location where a person can have a class..
    /// </summary>
    public class Facility : INamed, IEntityWithId
    {
        /// <summary>
        /// The id of the facility
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Name of the facility
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// The classes that are booked at the facility.
        /// </summary>
        public ICollection<Class> Bookings { get; set; } = new HashSet<Class>();

        /// <summary>
        /// The maximum amount of people that the facility can contain.
        /// </summary>
        public int Capacity { get; set; }
    }
}