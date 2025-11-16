using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._5.DAL;

namespace Lab3._5.BLL
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private List<Student> _cache;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
            _cache = _repo.LoadAll().ToList();
        }

        public IEnumerable<Student> GetFemaleFifthCourseInCity(string city)
        {
            return _cache.Where(s => s.IsFemaleFifthCourse() && s.LivesPermanentlyIn(city));
        }

        public int CountFemaleFifthCourseInCity(string city) => GetFemaleFifthCourseInCity(city).Count();

        public void MoveStudent(Student student, string newResidence, bool assignDorm = true)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            var old = student.Residence;
            student.MoveTo(newResidence);

            if (assignDorm && Student.ShouldBePlacedInDormOnRelocation(old, newResidence))
            {
                student.MoveTo("(Гуртожиток) " + student.Residence);
            }

            var idx = _cache.FindIndex(s => s.StudentId == student.StudentId);

            if (idx >= 0) _cache[idx] = student;
            else _cache.Add(student);

            _repo.SaveAll(_cache);
        }
    }
}
