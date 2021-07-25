using System;
using System.Linq;
using Domain.Contracts;
using Domain.Extensions.Enumerable;
using NUnit.Framework;

namespace Domain.Tests.Extensions.Enumerable
{
    /// <summary>
    /// Stub class that implements the <see cref="INamed"/> interface.
    /// </summary>
    public class EntityWithIdStub : IEntityWithId
    {
        public Guid Id { get; set; }
    }

    /// <summary>
    /// Unit tests for the <see cref="IEntityWithId"/> enumerable extension methods.
    /// </summary>
    public class EntityWithIdExtensionTests
    {
        [Test]
        public void With_Id_Includes_Matching()
        {
            // Arrange
            var matchingId = new Guid();
            var matching = CreateStubEntityWithId(matchingId);
            var notMatching = CreateStubEntityWithId(new Guid());

            var fixture = new[] {matching, notMatching};

            // Act
            var result = fixture
                .WithId(matchingId)
                .ToList();

            // Assert
            Assert.IsTrue(result.Contains(matching));
            Assert.IsFalse(result.Contains(notMatching));
        }

        [Test]
        public void With_Id_Excludes_Matching_Id_Include_Is_False()
        {
            // Arrange
            var matchingId = new Guid();
            var matching = CreateStubEntityWithId(matchingId);

            var nonMatching = CreateStubEntityWithId(new Guid());

            var fixture = new[] {matching};
            
            // Act
            var result = fixture
                .WithId(matchingId, false)
                .ToList();

            // Assert
            Assert.IsFalse(result.Contains(matching));
            Assert.IsTrue(result.Contains(nonMatching));
        }


        /// <summary>
        /// Creates a new stub name entity.
        /// </summary>
        private static EntityWithIdStub CreateStubEntityWithId(Guid id) => new EntityWithIdStub {Id = id};
    }
}