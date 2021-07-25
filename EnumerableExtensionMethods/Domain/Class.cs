using System;
using System.Collections.Generic;
using Domain.Contracts;

namespace Domain
{
    /// <summary>
    /// A <see cref="Class"/> represents members being booking into a facility at a given time.
    /// </summary>
    public class Class : INamed, IEntityWithId
    {
        /// <summary>
        /// The unique identifier for the class.
        /// </summary>
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        /// <summary>
        /// The start date & time for the class.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date & time for the class.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The members that are attending the class.
        /// </summary>
        public ICollection<ClassMember> Members { get; set; } = new HashSet<ClassMember>();

        /// <summary>
        /// The facility where the class is being held.
        /// </summary>
        public Facility Facility { get; set; } = default!;

        /// <summary>
        /// The unique identifier for the facility. 
        /// </summary>
        public Guid FacilityId { get; set; }
        
        /// <summary>
        /// The capacity that facility can contain.
        /// </summary>
        public int Capacity { get; set; }
    }
}