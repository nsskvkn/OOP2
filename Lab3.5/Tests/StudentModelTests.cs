using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._5.BLL;
using NUnit.Framework;

namespace Lab3._5.Tests
{
    public class StudentModelTests
    {
        [Test]
        public void Constructor_ValidData_CreatesStudent()
        {
            var s = new Student("Іваненко", "Олена", 3, "S1", Sex.Female, "Київ", "Z1");

            Assert.AreEqual("Іваненко", s.LastName);
            Assert.AreEqual("Олена", s.FirstName);
            Assert.AreEqual(3, s.Course);
        }

        [Test]
        public void Constructor_Throws_OnEmptyLastName()
        {
            Assert.Throws<ArgumentException>(() =>
                new Student("", "Олена", 3, "S1", Sex.Female, "Київ", "Z1"));
        }

        [Test]
        public void Constructor_Throws_OnEmptyFirstName()
        {
            Assert.Throws<ArgumentException>(() =>
                new Student("Іваненко", "", 3, "S1", Sex.Female, "Київ", "Z1"));
        }

        [Test]
        public void Constructor_Throws_OnInvalidCourse()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Student("Іваненко", "Олена", 7, "S1", Sex.Female, "Київ", "Z1"));
        }

        [Test]
        public void Promote_IncreasesCourse_Until6()
        {
            var s = new Student("Іваненко", "Олена", 5, "S1", Sex.Female, "Київ", "Z1");
            s.Promote();
            Assert.AreEqual(6, s.Course);

            s.Promote(); // no more than 6
            Assert.AreEqual(6, s.Course);
        }

        [Test]
        public void IsFemaleFifthCourse_WorksCorrectly()
        {
            var s = new Student("А", "Б", 5, "S", Sex.Female, "Київ", "Z");
            Assert.IsTrue(s.IsFemaleFifthCourse());
        }

        [Test]
        public void LivesPermanentlyIn_IsCaseInsensitive()
        {
            var s = new Student("А", "Б", 3, "S", Sex.Female, "Київ", "Z");
            Assert.IsTrue(s.LivesPermanentlyIn("киЇв"));
        }

        [Test]
        public void MoveTo_ChangesResidence()
        {
            var s = new Student("А", "Б", 3, "S", Sex.Female, "Київ", "Z");
            s.MoveTo("Львів");
            Assert.AreEqual("Львів", s.Residence);
        }

        [Test]
        public void MoveTo_Throws_OnEmpty()
        {
            var s = new Student("А", "Б", 3, "S", Sex.Female, "Київ", "Z");
            Assert.Throws<ArgumentException>(() => s.MoveTo(""));
        }

        [Test]
        public void ShouldBePlacedInDormOnRelocation_Works()
        {
            Assert.IsTrue(Student.ShouldBePlacedInDormOnRelocation("Київ", "Львів"));
            Assert.IsTrue(Student.ShouldBePlacedInDormOnRelocation("", "Львів"));
            Assert.IsFalse(Student.ShouldBePlacedInDormOnRelocation("Київ", "Київ"));
        }

        [Test]
        public void ToString_ReturnsNonEmptyString()
        {
            var s = new Student("А", "Б", 3, "S", Sex.Female, "Київ", "Z");
            Assert.IsNotEmpty(s.ToString());
        }
    }
}