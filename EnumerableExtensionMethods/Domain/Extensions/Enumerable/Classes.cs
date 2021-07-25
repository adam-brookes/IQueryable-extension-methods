using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Extensions.Enumerable
{
    /// <summary>
    /// <see cref="Enumerable"/> extension methods for the <see cref="Class"/> entity.
    /// </summary>
    public static class Classes
    {
        /// <summary>
        /// Filters the IEnumerable to <see cref="Class"/>'s that fall within the provided the dates. 
        /// </summary>
        /// <param name="source">The IEnumerable to be filtered.</param>
        /// <param name="startDate">The start date the class must be on or after.</param>
        /// <param name="endDate">The end date the class must be on or before.</param>
        /// <returns></returns>
        public static IQueryable<Class> WithinDates(this IEnumerable<Class> source, DateTime startDate, DateTime endDate) 
            => source.AsQueryable().Where(c => c.StartDate >= startDate && c.EndDate <= endDate);
        
        /// <summary>
        /// Filters the IEnumerable to <see cref="Class"/>'s that are at the specified facility. 
        /// </summary>
        /// <param name="source">The IEnumerable to be filtered.</param>
        /// <param name="facilityId">The facility id to filter the results by.</param>
        /// <param name="include">If classes in the specified facility should be included or excluded.</param>
        public static IQueryable<Class> InFacility(this IEnumerable<Class> source, Guid facilityId, bool include = true) 
            => source.AsQueryable().Where(c => c.FacilityId == facilityId == include);
    }
}