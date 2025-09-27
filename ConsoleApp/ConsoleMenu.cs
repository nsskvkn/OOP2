namespace Lab3._1.ConsoleApp
using System;
using CoreLib;
using FileIO;
using global::CoreLib;
{
    public class ConsoleMenu
    {
        private IFileRepository _repo;

        public ConsoleMenu(IFileRepository repo)
        {
            _repo = repo;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Додати студента");
                Console.WriteLine("2. Додати столяра");
                Console.WriteLine("3. Додати фотографа");
                Console.WriteLine("4. Показати всіх");
                Console.WriteLine("5. Вийти");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                if (choice == "1") AddStudent();
                else if (choice == "2") AddJoiner();
                else if (choice == "3") AddPhotographer();
                else if (choice == "4") ShowAll();
                else if (choice == "5") break;
            }
        }

        private void AddStudent()
        {
            Console.Write("Ім'я: ");
            string fn = Console.ReadLine();
            Console.Write("Прізвище: ");
            string ln = Console.ReadLine();
            Console.Write("Курс: ");
            int c = int.Parse(Console.ReadLine());
            Console.Write("Студ. квиток: ");
            string id = Console.ReadLine();
            Console.Write("Стать: ");
            string g = Console.ReadLine();
            Console.Write("Місто: ");
            string city = Console.ReadLine();
            Console.Write("Залікова книжка: ");
            string rec = Console.ReadLine();

            Student s = new Student(fn, ln, c, id, g, city, rec);
            _repo.SavePerson(s);
        }

        private void AddJoiner()
        {
            Console.Write("Ім'я: ");
            string fn = Console.ReadLine();
            Console.Write("Прізвище: ");
            string ln = Console.ReadLine();
            Console.Write("Номер сертифіката: ");
            string cert = Console.ReadLine();

            Joiner j = new Joiner(fn, ln, cert);
            _repo.SavePerson(j);
        }

        private void AddPhotographer()
        {
            Console.Write("Ім'я: ");
            string fn = Console.ReadLine();
            Console.Write("Прізвище: ");
            string ln = Console.ReadLine();
            Console.Write("Модель камери: ");
            string cam = Console.ReadLine();

            Photographer p = new Photographer(fn, ln, cam);
            _repo.SavePerson(p);
        }

        private void ShowAll()
        {
            IPerson[] persons = _repo.LoadAll();
            Console.WriteLine("Зчитані з файлу:");
            foreach (var p in persons)
            {
                if (p != null)
                    Console.WriteLine(p.ToString());
            }
        }
    }
}

