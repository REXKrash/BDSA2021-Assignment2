using System;
using Xunit;

namespace Assignment2.Tests
{
    public class ImmutableStudentTest
    {
        [Fact]
        public void ImmutableStudent_ToString()
        {
            // Arrange
            var today = new DateTime(2021, 9, 17, 0, 0, 0);
            var graduation = today.AddYears(3);

            var student = new ImmutableStudent(69, "Jens", "Jensen", today, null, graduation);

            // Act
            var output = student.ToString();

            // Assert
            Assert.Equal("ImmutableStudent { Id = 69, GivenName = Jens, Surname = Jensen, StudentStatus = NEW, StartDate = 17-09-2021 00:00:00, EndDate = , GraduationDate = 17-09-2024 00:00:00 }", output);
        }

        [Fact]
        public void ImmutableStudent_Equality_Comparison()
        {
            // Arrange
            var today = DateTime.Now;
            var graduation = today.AddYears(3);

            var immutableStudent1 = new ImmutableStudent(69, "Jens", "Jensen", today, null, graduation);
            var immutableStudent2 = new ImmutableStudent(69, "Jens", "Jensen", today, null, graduation);

            var student1 = new Student(69, "Jens", "Jensen", today, null, graduation);
            var student2 = new Student(69, "Jens", "Jensen", today, null, graduation);

            // Assert
            Assert.Equal(immutableStudent1, immutableStudent2);
            Assert.NotEqual(student1, student2);
        }
    }
}
