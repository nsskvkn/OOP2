using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._5.BLL;
using Lab3._5.DAL;

namespace Lab3._5.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = args.Length > 0 ? args[0] : "students.json";

            var repo = new JsonFileStudentRepository(file);
            var service = new StudentService(repo);

            var femalesInKyiv = service.GetFemaleFifthCourseInCity("Київ").ToList();

            Console.WriteLine($"Студенток 5 курсу з Києва: {femalesInKyiv.Count}");
            foreach (var s in femalesInKyiv)
                Console.WriteLine(s);

            Console.WriteLine("Множення великих чисел:");
            Console.WriteLine(BigNumberUtils.Multiply("123456789", "987654321"));

            Console.WriteLine("Додаткові уміння:");
            new Photographer("Олег").TakePhoto("Професійний фотоапарат");
            new Joiner("Петро").DoJoin();
        }
    }
}
