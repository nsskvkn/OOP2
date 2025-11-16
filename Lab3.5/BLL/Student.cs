using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab3._5.BLL

{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Course { get; set; }
        public string StudentId { get; set; }
        public Sex Sex { get; set; }
        public string Residence { get; set; }
        public string GradebookNumber { get; set; }

        [JsonConstructor]
        public Student() : this("NA", "NA", 1, "NA", Sex.Female, "NA", "NA") { }

        public Student(string last, string first, int course, string studentId, Sex sex, string residence, string gradebookNumber)
        {
            if (string.IsNullOrWhiteSpace(last)) throw new ArgumentException("LastName required", nameof(last));
            if (string.IsNullOrWhiteSpace(first)) throw new ArgumentException("FirstName required", nameof(first));
            if (course < 1 || course > 6) throw new ArgumentOutOfRangeException(nameof(course), "Course must be 1..6");

            LastName = last;
            FirstName = first;
            Course = course;
            StudentId = studentId ?? string.Empty;
            Sex = sex;
            Residence = residence ?? string.Empty;
            GradebookNumber = gradebookNumber ?? string.Empty;
        }

        public bool IsFemaleFifthCourse() => Sex == Sex.Female && Course == 5;

        public bool LivesPermanentlyIn(string city)
        {
            if (string.IsNullOrWhiteSpace(city)) return false;
            return string.Equals(Residence?.Trim(), city.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        public void Promote()
        {
            if (Course >= 6) throw new InvalidOperationException("Cannot promote beyond course 6");
            Course++;
        }

        public void MoveTo(string newCity)
        {
            if (string.IsNullOrWhiteSpace(newCity)) throw new ArgumentException("newCity required", nameof(newCity));
            Residence = newCity.Trim();
        }

        public static bool ShouldBePlacedInDormOnRelocation(string previousResidence, string newResidence)
        {
            if (string.IsNullOrWhiteSpace(newResidence)) return false;
            if (string.IsNullOrWhiteSpace(previousResidence)) return true;
            return !string.Equals(previousResidence.Trim(), newResidence.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() =>
            $"{LastName} {FirstName} | Course: {Course} | ID: {StudentId} | Sex: {Sex} | Residence: {Residence} | Gradebook: {GradebookNumber}";
    }
}
