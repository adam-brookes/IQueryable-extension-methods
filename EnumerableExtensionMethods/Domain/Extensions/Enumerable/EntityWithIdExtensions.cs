using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Contracts;

namespace Domain.Extensions.Enumerable
{
    /// <summary>
    /// <see cref="Enumerable"/> extension methods for entities implementing the <see cref="IEntityWithId"/> interface.
    /// </summary>
    public static class EntityWithIdExtensions
    {
        /// <summary>
        /// Filters the IEnumerable based of instances that contain the name provided.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable"/> to be filtered.</param>
        /// <param name="id">The id to check for.</param>
        /// <param name="include">If to include results that match the id of exclude them.</param>
        /// <typeparam name="TEntity">The type of Entity which must inherit from <see cref="IEntityWithId"/></typeparam>
        /// <returns>An <see cref="IQueryable"/> that is filtered based of entries that have the <param name="id"></param></returns>
        public static IQueryable<TEntity> WithId<TEntity>(this IEnumerable<TEntity> source,
            Guid id = default!, bool include = true) where TEntity : class, IEntityWithId =>
            source.AsQueryable().Where(entity => entity.Id == id == include);
    }
}