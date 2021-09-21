using System;

namespace Assignment2
{
    public record ImmutableStudent
    {
        public int Id { get; init; }
        public string GivenName { get; init; }
        public string Surname { get; init; }

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
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public DateTime? GraduationDate { get; init; }

        public ImmutableStudent(int Id, string GivenName, string Surname, DateTime StartDate, DateTime? EndDate, DateTime? GraduationDate)
        {
            this.Id = Id;
            this.GivenName = GivenName;
            this.Surname = Surname;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.GraduationDate = GraduationDate;
        }

        public override string ToString()
        {
            return "ImmutableStudent { Id = "+Id+", GivenName = "+GivenName+", Surname = "+Surname+", StudentStatus = "+StudentStatus.ToString()+", StartDate = "+StartDate.ToString("dd-MM-yyyy HH:mm:ss")+", EndDate = "+EndDate?.ToString("dd-MM-yyyy HH:mm:ss")+", GraduationDate = "+GraduationDate?.ToString("dd-MM-yyyy HH:mm:ss")+" }";
        }
    }
}