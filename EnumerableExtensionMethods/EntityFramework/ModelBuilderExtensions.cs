using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    /// <summary>
    /// Extensions for the entity framework core model builder.
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Finds all of model builder assemblies and applies these when configuring migratoins
        /// </summary>
        internal static ModelBuilder ApplyConfigurations(this ModelBuilder modelBuilder)
        {
            return modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetAssembly(typeof(ModelBuilderExtensions)));
        }
    }
}