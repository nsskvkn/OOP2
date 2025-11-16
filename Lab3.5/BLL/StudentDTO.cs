using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._5.BLL
{
    public class StudentDTO
    {
        public string LastName = "NA";
        public string FirstName = "NA";
        public int Course = 1;
        public string StudentId = "NA";
        public Sex Sex = Sex.Female;
        public string Residence = "NA";
        public string GradebookNumber = "NA";

        public Student ToEntity() => new Student(LastName, FirstName, Course, StudentId, Sex, Residence, GradebookNumber);
    }
}