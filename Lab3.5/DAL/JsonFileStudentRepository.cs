using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lab3._5.BLL;

namespace Lab3._5.DAL
{
    public class JsonFileStudentRepository : IStudentRepository
    {
        private readonly string _file;

        public JsonFileStudentRepository(string filePath)
        {
            _file = filePath;
        }

        public IEnumerable<Student> LoadAll()
        {
            if (!File.Exists(_file)) return Enumerable.Empty<Student>();

            var json = File.ReadAllText(_file);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var dtos = JsonSerializer.Deserialize<List<Dto>>(json, options)
                       ?? new List<Dto>();

            return dtos.Select(d => d.ToStudent());
        }

        public void SaveAll(IEnumerable<Student> students)
        {
            var dtos = students.Select(Dto.FromStudent).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_file, json);
        }

        private class Dto
        {
            public string? LastName { get; set; }
            public string? FirstName { get; set; }
            public int Course { get; set; }
            public string?   StudentId { get; set; }
            public string? Sex { get; set; }
            public string? Residence { get; set; }
            public string? GradebookNumber { get; set; }

            public Student ToStudent()
            {
                Enum.TryParse<Sex>(Sex, true, out var sexParsed);

                return new Student(
                    LastName!,
                    FirstName!,
                    Course,
                    StudentId!,
                    sexParsed,
                    Residence!,
                    GradebookNumber!
                );
            }

            public static Dto FromStudent(Student s) => new Dto
            {
                LastName = s.LastName,
                FirstName = s.FirstName,
                Course = s.Course,
                StudentId = s.StudentId,
                Sex = s.Sex.ToString(),
                Residence = s.Residence,
                GradebookNumber = s.GradebookNumber
            };
        }
    }
}
