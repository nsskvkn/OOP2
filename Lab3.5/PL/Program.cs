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
            var path = args.Length > 0 ? args[0] : "students.json";
            var service = StudentService.CreateJsonEntityService(path);

            var load = service.LoadFromFile();
            if (!load.IsSuccess) Console.WriteLine($"Load warning: {load.Message}");

            var kyivGirls = service.GetFemaleFifthCourseInCity("Київ");
            Console.WriteLine($"Кількість студенток 5-го курсу, що постійно проживають у Києві: {kyivGirls?.Count() ?? 0}");
            foreach (var s in kyivGirls!) Console.WriteLine(s);

            Console.WriteLine();
            var photog = new Photographer("Олег");
            photog.TakePhonePhoto();
            photog.TakeProCameraPhoto();

            Console.WriteLine();
            Console.WriteLine("123456789 × 987654321 = " + BigNumberUtils.Multiply("123456789", "987654321"));
        }
    }
}
