using System;
using System.Collections.Generic;
using Domain.Contracts;

namespace Domain
{
    /// <summary>
    /// A member is a person who is registered at our Gym.
    /// </summary>
    public class Member : INamed, IEntityWithId
    {
        /// <summary>
        /// The unique identifier for the member.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The members name.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// The classes the member has been booked on.
        /// </summary>
        public ICollection<ClassMember> Classes { get; set; } = new HashSet<ClassMember>();
    }
}