using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._5.DAL;

namespace Lab3._5.BLL
{
    public class StudentService
    {
        private List<Student> _students = new();
        private IRepository _repo;

        public StudentService(IRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

        public string FilePath { get => _repo.FilePath; set => _repo.FilePath = value; }
        public int StudentsCount => _students.Count;

        public FileAccessResult SaveToFile()
        {
            try
            {
                _repo.SaveToFile(_students);
                return FileAccessResult.EmptySuccess;
            }
            catch (Exception e)
            {
                return new FileAccessResult(false, $"Error while saving: {e.Message}");
            }
        }

        public FileAccessResult LoadFromFile()
        {
            try
            {
                var loaded = _repo.GetFromFile<Student>();
                if (loaded == null) return new FileAccessResult(false, "File empty or missing");
                _students = loaded.ToList();
                return FileAccessResult.EmptySuccess;
            }
            catch (Exception e)
            {
                return new FileAccessResult(false, $"Error while loading: {e.Message}");
            }
        }

        public void AddStudent(Student s) => _students.Add(s);
        public void AddStudent(StudentDTO dto) => _students.Add(dto.ToEntity());
        public bool RemoveStudentAt(int idx)
        {
            if (idx < 0 || idx >= _students.Count) return false;
            _students.RemoveAt(idx);
            return true;
        }
        public void Clear() => _students.Clear();

        public IEnumerable<Student> GetFemaleFifthCourseInCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city)) return Enumerable.Empty<Student>();
            return _students.Where(s => s.IsFemaleFifthCourse() && s.LivesPermanentlyIn(city)).ToList();
        }

        public void MoveStudentToCity(Student student, string newCity)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            if (string.IsNullOrWhiteSpace(newCity)) throw new ArgumentException("newCity required", nameof(newCity));

            var previous = student.Residence;
            bool needDorm = Student.ShouldBePlacedInDormOnRelocation(previous, newCity);

            student.MoveTo(newCity);

            if (needDorm)
                student.MoveTo("(Гуртожиток) " + student.Residence);

            var idx = _students.FindIndex(s => s.StudentId == student.StudentId);
            if (idx >= 0) _students[idx] = student;
            else _students.Add(student);
        }

        public string GetAllStudentsInfo()
        {
            if (_students.Count == 0) return "None";
            var sb = new StringBuilder();
            for (int i = 0; i < _students.Count; i++)
            {
                sb.AppendLine($"=== {i} ===");
                foreach (var prop in _students[i].GetType().GetProperties())
                    sb.AppendLine($"{prop.Name} = {prop.GetValue(_students[i])}");
            }
            return sb.ToString();
        }

        public static StudentService CreateJsonEntityService(string filePath) => new StudentService(new JsonRepository(filePath));
    }
}
