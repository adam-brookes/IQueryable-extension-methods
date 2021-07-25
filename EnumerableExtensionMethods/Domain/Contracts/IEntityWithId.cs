using System;

namespace Domain.Contracts
{
    /// <summary>
    /// Contract for entities that have an Id.
    /// </summary>
    public interface IEntityWithId
    {
        public Guid Id { get; set; }
    }
}