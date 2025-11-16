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
    [TestFixture]
    public class StudentServiceTests
{
    private Mock<IRepository> _repoMock = null!;
    private StudentService _service = null!;

    [SetUp]
    public void Setup()
    {
        _repoMock = new Mock<IRepository>();
        _repoMock.Setup(r => r.FilePath).Returns("dummy.json");
        _repoMock.Setup(r => r.GetFromFile<Student>()).Returns(new List<Student>
        {
            new Student("Іваненко","Олена",5,"S1",Sex.Female,"Київ","Z1"),
            new Student("Петренко","Марія",5,"S2",Sex.Female,"Київ","Z2"),
            new Student("Сидоренко","Олександра",5,"S3",Sex.Female,"Львів","Z3"),
            new Student("Коваль","Іван",4,"S4",Sex.Male,"Київ","Z4")
        });

        _service = new StudentService(_repoMock.Object);
        var load = _service.LoadFromFile();

        Assert.That(load.IsSuccess, Is.True);
    }

    [Test]
    public void GetFemaleFifthCourseInCity_Kyiv_CountsTwo()
    {
        var list = _service.GetFemaleFifthCourseInCity("Київ").ToList();

        Assert.That(list, Has.Count.EqualTo(2));

        Assert.That(list, Is.All.Matches<Student>(s =>
            s.IsFemaleFifthCourse() &&
            s.LivesPermanentlyIn("Київ")
        ));
    }

    [Test]
    public void MoveStudentToCity_AssignsDormOnRelocation()
    {
        var s = new Student("Новак", "Аня", 3, "S10", Sex.Female, "Львів", "Z10");
        _service.AddStudent(s);

        _service.MoveStudentToCity(s, "Київ");

        Assert.That(s.Residence, Does.StartWith("(Гуртожиток)"));
    }

    [Test]
    public void MoveStudentToCity_NoDormIfSameCity()
    {
        var s = new Student("Новак", "Аня", 3, "S11", Sex.Female, "Київ", "Z11");
        _service.AddStudent(s);

        _service.MoveStudentToCity(s, "Київ");

        Assert.That(s.Residence, Does.Not.StartWith("(Гуртожиток)"));
    }

    [Test]
    public void SaveToFile_CallsRepoSave()
    {
        _repoMock.Setup(r => r.SaveToFile(It.IsAny<ICollection<Student>>()));

        var s = new Student("A", "B", 1, "Sx", Sex.Female, "K", "Z");
        _service.AddStudent(s);

        var res = _service.SaveToFile();

        Assert.That(res.IsSuccess, Is.True);

        _repoMock.Verify(r => r.SaveToFile(It.IsAny<ICollection<Student>>()), Times.Once);
    }
}

}
