using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._1.CoreLib
{
    public class Student : Person
    {
        public int Course { get; set; }
        public string StudentId { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string RecordBook { get; set; }

        public Student(string firstName, string lastName,
            int course, string studentId, string gender,
            string city, string recordBook)
            : base(firstName, lastName)
        {
            Course = course;
            StudentId = studentId;
            Gender = gender;
            City = city;
            RecordBook = recordBook;
        }

        public void Study()
        {
            Course++;
        }
    }
}
