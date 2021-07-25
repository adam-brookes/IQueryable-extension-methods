using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework.Configuration
{
    /// <summary>
    /// Class that represents the EF relationships for a <see cref="Class"/>
    /// </summary>
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Facility)
                .WithMany(fac => fac.Bookings)
                .HasForeignKey(c => c.FacilityId)
                .IsRequired();

        }
    }
}