namespace Domain.Contracts
{
    /// <summary>
    /// An interface for entities that have a name.
    /// </summary>
    public interface INamed
    {
        /// <summary>
        /// The name of the entity.
        /// </summary>
        public string Name { get; set; }
    }
}