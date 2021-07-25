using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain;

namespace Presentation.Models
{
    /// <summary>
    /// Model representing a <see cref="Class"/>
    /// </summary>
    public class ClassModel
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
        /// The members ids that are attending the class.
        /// </summary>
        public IEnumerable<Guid> MemberIds { get; set; } = new HashSet<Guid>();
        
        /// <summary>
        /// The unique identifier for the facility. 
        /// </summary>
        public Guid FacilityId { get; set; }
        
        /// <summary>
        /// The capacity that facility can contain.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Method to transform a <see cref="Class"/> to a <see cref="ClassModel"/>
        /// </summary>
        public static Expression<Func<Class, ClassModel>> FromClass { get; } = entity => new ClassModel
        {
            Id = entity.Id,
            Capacity = entity.Capacity,
            Name = entity.Name,
            EndDate = entity.EndDate,
            FacilityId = entity.FacilityId,
            MemberIds = entity.Members.Select(classMember => classMember.MemberId),
            StartDate = entity.StartDate
        };
    }
}