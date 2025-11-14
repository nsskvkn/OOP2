using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._5.BLL
{
    public class Student
    {
        public string LastName { get; init; }
        public string FirstName { get; init; }
        public int Course { get; private set; }
        public string StudentId { get; init; }
        public Sex Sex { get; init; }
        public string Residence { get; private set; }
        public string GradebookNumber { get; init; }

        public Student(string lastName, string firstName, int course, string studentId, Sex sex, string residence, string gradebookNumber)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("LastName required");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("FirstName required");

            if (course < 1 || course > 6)
                throw new ArgumentOutOfRangeException(nameof(course));

            LastName = lastName.Trim();
            FirstName = firstName.Trim();
            Course = course;
            StudentId = studentId?.Trim() ?? "";
            Sex = sex;
            Residence = residence?.Trim() ?? "";
            GradebookNumber = gradebookNumber?.Trim() ?? "";
        }

        public void Promote()
        {
            if (Course < 6) Course++;
        }

        public bool IsFemaleFifthCourse() => Sex == Sex.Female && Course == 5;

        public bool LivesPermanentlyIn(string city)
        {
            if (string.IsNullOrWhiteSpace(city)) return false;
            return string.Equals(Residence.Trim(), city.Trim(),
                StringComparison.OrdinalIgnoreCase);
        }

        public void MoveTo(string newResidence)
        {
            if (string.IsNullOrWhiteSpace(newResidence))
                throw new ArgumentException("newResidence required");
            Residence = newResidence.Trim();
        }

        public static bool ShouldBePlacedInDormOnRelocation(string previous, string next)
        {
            if (string.IsNullOrWhiteSpace(next)) return false;
            if (string.IsNullOrWhiteSpace(previous)) return true;
            return !string.Equals(previous.Trim(), next.Trim(),
                StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}, Course:{Course}, Residence:{Residence}";
        }
    }
}
