using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework.Configuration
{
    /// <summary>
    /// Class that represents the EF relationships for a <see cref="Member"/>
    /// </summary>
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(mem => mem.Id);
        }
    }
}