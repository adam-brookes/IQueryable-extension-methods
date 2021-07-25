using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework.Configuration
{
    /// <summary>
    /// Class that represents the EF relationships for a <see cref="ClassMember"/>
    /// </summary>
    public class ClassMemberConfiguration : IEntityTypeConfiguration<ClassMember>
    {
        public void Configure(EntityTypeBuilder<ClassMember> builder)
        {
            builder.HasKey(classMember => new {classMember.ClassId, classMember.MemberId});

            builder.HasOne(t => t.Class)
                .WithMany(c => c.Members)
                .HasForeignKey(t => t.ClassId)
                .IsRequired();
            
            builder.HasOne(t => t.Member)
                .WithMany(c => c.Classes)
                .HasForeignKey(t => t.MemberId)
                .IsRequired();
        }
    }
}