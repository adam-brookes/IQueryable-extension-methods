using System;
using System.Linq;
using Domain.Extensions.Enumerable;
using NUnit.Framework;

namespace Domain.Tests.Extensions.Enumerable
{
    /// <summary>
    /// Unit tests for the <see cref="Class"/> enumerable extension methods.
    /// </summary>
    public class ClassesTests
    {
        [Test]
        public void Within_Dates_Includes_Classes_Within_Date_Range()
        {
            // Arrange
            static Class ClassWithDates(DateTime start, DateTime end) => 
                new Class
                {
                    StartDate = start, 
                    EndDate = end
                };
            
            var startDateForFilter = DateTime.Now;

            var endDateForFilter = startDateForFilter.AddDays(2);

            var expectedClass1 = ClassWithDates(startDateForFilter.AddHours(5), endDateForFilter);
            
            var expectedClass2 = ClassWithDates(startDateForFilter.AddDays(1), endDateForFilter.AddDays(-1));

            var fixture = new[] {expectedClass1, expectedClass2};

            // Act
            var result = fixture.WithinDates(startDateForFilter, endDateForFilter).ToList();

            // Assert
            Assert.IsTrue(result.Contains(expectedClass1));
            Assert.IsTrue(result.Contains(expectedClass1));
        }
    }
}