using System.Collections;
using System.Collections.Generic;
using Domain.Contracts;
using System.Linq;

namespace Domain.Extensions.Enumerable
{
    /// <summary>
    /// <see cref="Enumerable"/> extension methods for entities implementing the <see cref="INamed"/> interface.
    /// </summary>
    public static class NamedExtensions
    {
        /// <summary>
        /// Filters the IEnumerable based of instances that contain the name provided.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable"/> to be filtered.</param>
        /// <param name="name">The name to check for matches on.</param>
        /// <typeparam name="TEntity">The type of Entity which must inherit from <see cref="INamed"/></typeparam>
        /// <returns>An <see cref="IQueryable"/> that is filtered based of entries that contain the <param name="name"></param></returns>
        public static IQueryable<TEntity> ContainingName<TEntity>(this IEnumerable<TEntity> source,
            string name = default!) where TEntity : class, INamed =>
            source.AsQueryable().Where(entity => entity.Name.ToLower().Contains(name.ToLower()));
        
        /// <summary>
        /// Filters the IEnumerable based of instances that exactly match the name provided.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable"/> to be filtered.</param>
        /// <param name="name">The name to check for matches on.</param>
        /// <param name="include">If we should include results that match the name provided.</param>
        /// <typeparam name="TEntity">The type of Entity which must inherit from <see cref="INamed"/></typeparam>
        /// <returns>An <see cref="IQueryable"/> that is filtered based of entries that match the <param name="name"></param></returns>
        public static IQueryable<TEntity> WithName<TEntity>(this IEnumerable<TEntity> source,
            string name = default!, bool include = true) where TEntity : class, INamed =>
            source.AsQueryable().Where(entity => string.Equals(entity.Name, name) == include);
    }
}