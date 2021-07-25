using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain;

namespace Presentation.Models
{
    public class FacilityModel
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
        public IEnumerable<Guid> BookingIds { get; set; } = new HashSet<Guid>();

        /// <summary>
        /// The maximum amount of people that the facility can contain.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Transforms a <see cref="Facility"/>
        /// </summary>
        public Expression<Func<Facility, FacilityModel>> FromFacility { get; } = facility => new FacilityModel
        {
            Capacity = facility.Capacity,
            Id = facility.Id,
            Name = facility.Name,
            BookingIds = facility.Bookings.Select(b => b.FacilityId),
        };
    }
}