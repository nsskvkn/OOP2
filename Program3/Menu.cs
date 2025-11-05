using System;
using System.Collections.Generic;
using Lab3._3;
using Lab3.DAL.DataProviders;

namespace Program3

{
    public static class Menu
    {
        public static void MainMenu()
        {
            var stringEntities = new List<StringEntity>
            {
                new StringEntity("Hello, world!", 2),
                new StringEntity("Привіт!", 1)
            };

            Console.WriteLine("Обирайте тип збереження: 1-JSON, 2-XML, 3-Binary, 4-Custom");
            var choice = Console.ReadLine();
            string path = "data_strings";
            IDataProvider<StringEntity> providerEntity = new JsonProvider<StringEntity>();
            if (choice == "1") { path += ".json"; providerEntity = new JsonProvider<StringEntity>(); }
            else if (choice == "2") { path += ".xml"; providerEntity = new XmlProvider<StringEntity>(); }
            else if (choice == "3") { path += ".bin"; providerEntity = new BinaryProvider<StringEntity>(); }
            else { path += ".txt"; }

            var ctx = new EntityContext<StringEntity>(providerEntity);
            ctx.Save(path, stringEntities);
            var restored = ctx.Load(path);

            var sSvc = new StringService();
            foreach (var s in restored)
            {
                var encrypted = sSvc.Encrypt(s);
                var decrypted = sSvc.Decrypt(s, encrypted);
                Console.WriteLine($"Original: {s.Value}");
                Console.WriteLine($"Encrypted: {encrypted}");
                Console.WriteLine($"Decrypted: {decrypted}");
                Console.WriteLine("----");
            }

            //Робота зі студентами
            var students = new List<StudentEntity>
            {
             new StudentEntity { LastName = "Іваненко", FirstName = "Марія", Course = 5, StudentId = "ST001", Sex = "Ж", Residence = "Київ", RecordBookNumber = "RB101" },
             new StudentEntity { LastName = "Петренко", FirstName = "Олег", Course = 4, StudentId = "ST002", Sex = "Ч", Residence = "Київ", RecordBookNumber = "RB102" },
             new StudentEntity { LastName = "Сидоренко", FirstName = "Олена", Course = 5, StudentId = "ST003", Sex = "Ж", Residence = "Львів", RecordBookNumber = "RB103" },
             new StudentEntity { LastName = "Гончар", FirstName = "Юлія", Course = 5, StudentId = "ST004", Sex = "Ж", Residence = "Київ", RecordBookNumber = "RB104" }
            };

            Console.WriteLine("\n=== Серіалізація студентів ===");
            Console.WriteLine("Оберіть формат: 1 - JSON, 2 - XML, 3 - Binary");
            var studentChoice = Console.ReadLine();
            string studentPath = "students";
            IDataProvider<StudentEntity> studentProvider = new JsonProvider<StudentEntity>();

            if (studentChoice == "1") { studentPath += ".json"; studentProvider = new JsonProvider<StudentEntity>(); }
            else if (studentChoice == "2") { studentPath += ".xml"; studentProvider = new XmlProvider<StudentEntity>(); }
            else if (studentChoice == "3") { studentPath += ".bin"; studentProvider = new BinaryProvider<StudentEntity>(); }

            var studentCtx = new EntityContext<StudentEntity>(studentProvider);
            studentCtx.Save(studentPath, students);

            var loadedStudents = studentCtx.Load(studentPath);
            var studentService = new StudentService();

            try
            {
                var selected = studentService.FemaleFifthCourseInKyiv(loadedStudents);
                Console.WriteLine("\nСтудентки 5-го курсу, які постійно проживають у Києві:");
                foreach (var s in selected)
                    Console.WriteLine($" - {s.LastName} {s.FirstName}, {s.Residence}");
            }
            catch (BusinessLogicException ex)
            {
                Console.WriteLine("Помилка бізнес-логіки: " + ex.Message);
            }

        }
    }
}
