using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework.Configuration
{
    /// <summary>
    /// Class that represents the EF relationships for a <see cref="Facility"/>
    /// </summary>
    public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.HasKey(fac => fac.Id);
        }
    }
}