using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._5.BLL
{
    public interface IStudentService
    {
        IEnumerable<Student> GetFemaleFifthCourseInCity(string city);
        int CountFemaleFifthCourseInCity(string city);
        void MoveStudent(Student student, string newResidence, bool assignDorm = true);
    }
}
