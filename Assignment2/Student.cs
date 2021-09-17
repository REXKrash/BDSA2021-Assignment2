using System;
using System.Reflection;

namespace Assignment2
{
    public class Student
    {
        public int id { get; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public Status StudentStatus
        {
            get
            {
                var today = DateTime.Now;
                var newStudentLimit = StartDate.AddMonths(6);

                if (EndDate != null && EndDate <= today)
                {
                    return Status.DROPOUT;
                }
                else if (GraduationDate != null && GraduationDate <= today)
                {
                    return Status.GRADUATED;
                }
                else if (StartDate <= today && today <= newStudentLimit)
                {
                    return Status.NEW;
                }
                else if (StartDate <= today && today <= GraduationDate)
                {
                    return Status.ACTIVE;
                }
                return Status.INACTIVE;
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? GraduationDate { get; set; }

        public Student(int id, string GivenName, string Surname, DateTime StartDate, DateTime? EndDate, DateTime? GraduationDate)
        {
            this.id = id;
            this.GivenName = GivenName;
            this.Surname = Surname;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.GraduationDate = GraduationDate;
        }

        public override string ToString()
        {
            return $"Student - ID: {id}, {GivenName} {Surname} Status: {StudentStatus.ToString()}";
        }
    }
}