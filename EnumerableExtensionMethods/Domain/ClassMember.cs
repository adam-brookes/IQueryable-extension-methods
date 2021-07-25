using System;

namespace Domain
{
    /// <summary>
    /// The link between class's and team members.
    /// </summary>
    public class ClassMember
    {
        /// <summary>
        /// The unique identifier for the member
        /// </summary>
        public Guid MemberId { get; set; }

        /// <summary>
        /// The member attending the class.
        /// </summary>
        public Member Member { get; set; } = default!;

        /// <summary>
        /// The unique identifier for the class.
        /// </summary>
        public Guid ClassId { get; set; }

        /// <summary>
        /// The class.
        /// </summary>
        public Class Class { get; set; } = default!;
    }
}