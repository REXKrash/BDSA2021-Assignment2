using System;
using Xunit;

namespace Assignment2.Tests
{
    public class StudentTest
    {
        [Fact]
        public void Student_ToString_Given_Student_ID_69_Name_Jens_Surname_Jensen_StartDate_Today_EndDate_Null_GraduationDate_3YearsFromToday_Return_String_Student_ID_69_Jens_Jensen_Status_New()
        {
            // Arrange
            var today = DateTime.Now;
            var graduation = today.AddYears(3);

            var student = new Student(69, "Jens", "Jensen", today, null, graduation);

            // Act
            var output = student.ToString();

            // Assert
            Assert.Equal("Student - ID: 69, Jens Jensen Status: NEW", output);
        }

        [Fact]
        public void Student_GetStatus_ActiveStudent()
        {
            // Arrange
            var today = DateTime.Now;
            var startDate = today.AddMonths(-8);
            var graduation = today.AddYears(3);

            var student = new Student(69, "Jens", "Jensen", startDate, null, graduation);

            // Act
            var output = student.StudentStatus;

            // Assert
            Assert.Equal(Status.ACTIVE, output);
        }

        [Fact]
        public void Student_GetStatus_DropoutStudent()
        {
            // Arrange
            var today = DateTime.Now;
            var startDate = today.AddMonths(-2);
            var endDate = today.AddMonths(-1);
            var graduation = today.AddYears(3);

            var student = new Student(69, "Jens", "Jensen", startDate, endDate, graduation);

            // Act
            var output = student.StudentStatus;

            // Assert
            Assert.Equal(Status.DROPOUT, output);
        }

        [Fact]
        public void Student_GetStatus_GraduatedStudent()
        {
            // Arrange
            var today = DateTime.Now;
            var graduation = today.AddDays(-3);

            var student = new Student(69, "Jens", "Jensen", today, null, graduation);

            // Act
            var output = student.StudentStatus;

            // Assert
            Assert.Equal(Status.GRADUATED, output);
        }
    }
}
