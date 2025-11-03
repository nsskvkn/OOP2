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
            Console.WriteLine("Лабораторна 3.3 — Варіант 10");
            // Приклад: демонстрація роботи з рядками
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

            // Далі: робота зі студентами, вибір файлу, підрахунок студенток 5-го курсу, що постійно проживають у Києві.
        }
    }
}
