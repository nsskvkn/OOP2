using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._5.BLL;
using Lab3._5.DAL;
using NUnit.Framework;

namespace Lab3._5.Tests
{
    public class JsonFileStudentRepositoryTests
    {
        private string? _path;

        [SetUp]
        public void Setup()
        {
            _path = Path.GetTempFileName();
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(_path)) File.Delete(_path);
        }

        [Test]
        public void LoadAll_ReturnsEmpty_WhenFileMissing()
        {
            File.Delete(_path!);
            var repo = new JsonFileStudentRepository(_path!);

            var list = repo.LoadAll().ToList();
            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Test]
        public void SaveAll_CreatesFile()
        {
            var repo = new JsonFileStudentRepository(_path!);

            repo.SaveAll(new List<Student>
            {
                new Student("A","B",3,"S1",Sex.Female,"Kyiv","Z1")
            });

            Assert.That(File.Exists(_path), Is.True);
        }

        [Test]
        public void SaveLoad_CycleTest()
        {
            var repo = new JsonFileStudentRepository(_path!);

            var original = new List<Student>
            {
                new Student("A","B",3,"S1",Sex.Female,"Kyiv","Z1"),
                new Student("C","D",4,"S2",Sex.Male,"Lviv","Z2")
            };

            repo.SaveAll(original);

            var loaded = repo.LoadAll().ToList();

            Assert.That(loaded.Count, Is.EqualTo(2));
            Assert.That(loaded[0].LastName, Is.EqualTo("A"));
            Assert.That(loaded[1].Residence, Is.EqualTo("Lviv"));
        }
    }
}