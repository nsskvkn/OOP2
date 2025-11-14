using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._5.BLL;
using Lab3._5.DAL;
using Moq;
using NUnit.Framework;

namespace Lab3._5.Tests
{
    public class StudentServiceTests
    {
        private Mock<IStudentRepository> _repo;
        private StudentService _service;

        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IStudentRepository>();

            _repo.Setup(r => r.LoadAll()).Returns(new List<Student>
            {
                new Student("Іваненко", "Олена", 5, "S1", Sex.Female, "Київ", "Z1"),
                new Student("Петренко", "Марія", 5, "S2", Sex.Female, "Львів", "Z2"),
                new Student("Коваль", "Ірина", 5, "S3", Sex.Female, "Київ", "Z3"),
                new Student("Сидоренко", "Олег", 4, "S4", Sex.Male, "Київ", "Z4")
            });

            _service = new StudentService(_repo.Object);
        }

        [Test]
        public void GetFemaleFifthCourseInCity_Kyiv_ReturnsCorrectStudents()
        {
            var list = _service.GetFemaleFifthCourseInCity("Київ").ToList();
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void CountFemaleFifthCourseInCity_ReturnsNumber()
        {
            Assert.AreEqual(2, _service.CountFemaleFifthCourseInCity("Київ"));
        }

        [Test]
        public void GetFemaleFifthCourseInCity_EmptyCity_ReturnsEmptyList()
        {
            var list = _service.GetFemaleFifthCourseInCity("").ToList();
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void MoveStudent_ChangesResidence_AndSaves()
        {
            var s = new Student("Іваненко", "Олена", 5, "S10", Sex.Female, "Київ", "Z1");

            _repo.Setup(r => r.SaveAll(It.IsAny<IEnumerable<Student>>()));

            _service.MoveStudent(s, "Львів", assignDorm: false);

            Assert.AreEqual("Львів", s.Residence);

            _repo.Verify(r => r.SaveAll(It.IsAny<IEnumerable<Student>>()), Times.Once);
        }

        [Test]
        public void MoveStudent_DormitoryAssigned_WhenCityChanges()
        {
            var s = new Student("А", "Б", 3, "S20", Sex.Female, "Київ", "Z");

            _repo.Setup(r => r.SaveAll(It.IsAny<IEnumerable<Student>>()));

            _service.MoveStudent(s, "Одеса", assignDorm: true);

            Assert.IsTrue(s.Residence.StartsWith("(Гуртожиток)"));
        }

        [Test]
        public void MoveStudent_Throws_OnNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _service.MoveStudent(null, "Одеса"));
        }
    }
}
