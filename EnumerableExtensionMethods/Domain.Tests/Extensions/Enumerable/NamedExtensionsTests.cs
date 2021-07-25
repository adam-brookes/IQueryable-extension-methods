using System.Linq;
using Domain.Contracts;
using Domain.Extensions.Enumerable;
using NUnit.Framework;

namespace Domain.Tests.Extensions.Enumerable
{
    /// <summary>
    /// Stub class that implements the <see cref="INamed"/> interface.
    /// </summary>
    public class NamedStub : INamed
    {
        public string Name { get; set; } = default!;
    }

    /// <summary>
    /// Unit tests for the <see cref="INamed"/> enumerable extension methods.
    /// </summary>
    public class NamedExtensionsTests
    {
        [Test]
        public void Contains_Name_Includes_Matching()
        {
            // Arrange
            var matching1 = CreateStubINamed("test1");
            var matching2 = CreateStubINamed("IamTest2");
            var matching3 = CreateStubINamed("SomeOtherTest");

            var fixture = new[] {matching1, matching2, matching3};

            const string nameToMatch = "test";

            // Act
            var result = fixture
                    .ContainingName(nameToMatch)
                    .ToList();

            // Assert
            Assert.IsTrue(result.Contains(matching1));
            Assert.IsTrue(result.Contains(matching2));
            Assert.IsTrue(result.Contains(matching3));
        }

        [Test]
        public void Contains_Name_Excludes_Non_Matching()
        {
            // Arrange
            var matching1 = CreateStubINamed("test1");
            var matching2 = CreateStubINamed("IamTest2");

            var nonMatching1 = CreateStubINamed("I do not match");
            var nonMatching2 = CreateStubINamed("I also do not match");

            var fixture = new[] {matching1, matching2, nonMatching1, nonMatching2};

            const string nameToMatch = "test";

            // Act
            var result = fixture
                    .ContainingName(nameToMatch)
                    .ToList();

            // Assert
            Assert.IsTrue(result.Contains(matching1));
            Assert.IsTrue(result.Contains(matching2));
            Assert.IsFalse(result.Contains(nonMatching1));
            Assert.IsFalse(result.Contains(nonMatching2));
        }

        [Test]
        public void With_Name_Includes_Matching()
        {
            // Arrange
            var matching = CreateStubINamed("test");
            
            var fixture = new[] {matching};

            const string nameToMatch = "test";

            // Act
            var result = fixture
                .WithName(nameToMatch)
                .ToList();

            // Assert
            Assert.IsTrue(result.Contains(matching));
        }

        [Test]
        public void With_Name_Excludes_Non_Matching()
        {
            // Arrange
            var matching = CreateStubINamed("No Match");
            
            var fixture = new[] {matching};

            const string nameToMatch = "test";

            // Act
            var result = fixture
                .WithName(nameToMatch)
                .ToList();

            // Assert
            Assert.IsFalse(result.Contains(matching));
        }
        
        [Test]
        public void With_Name_Excludes_Matching_When_Include_Is_False()
        {
            // Arrange
            var matching = CreateStubINamed("test");
            
            var fixture = new[] {matching};

            const string nameToMatch = "test";

            // Act
            var result = fixture
                .WithName(nameToMatch, false)
                .ToList();

            // Assert
            Assert.IsFalse(result.Contains(matching));
        }

        /// <summary>
        /// Creates a new stub name entity.
        /// </summary>
        private static NamedStub CreateStubINamed(string name) => new NamedStub {Name = name};
    }
}