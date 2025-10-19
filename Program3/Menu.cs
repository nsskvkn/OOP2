using System;
using System.Collections.Generic;
using Lab3._3;

namespace Program3
{
    public class Menu
    {
        private EntityService _service;
        private EntityContext _context;

        public Menu()
        {
            // За замовчуванням — JSON provider. PL вирішує який провайдер використовувати та передає шлях.
            _context = new EntityContext(new JsonProvider());
            _service = new EntityService(_context);
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Лабораторна: Серіалізація та 3-рівнева архітектура ===");
                Console.WriteLine("1. Вибрати провайдер (json/xml/binary/custom)");
                Console.WriteLine("2. Завантажити з файлу");
                Console.WriteLine("3. Зберегти в файл");
                Console.WriteLine("4. Додати рядок");
                Console.WriteLine("5. Показати всі");
                Console.WriteLine("6. Зашифрувати елемент");
                Console.WriteLine("7. Розшифрувати елемент");
                Console.WriteLine("8. Знайти за підрядком");
                Console.WriteLine("9. Видалити по індексу");
                Console.WriteLine("0. Вийти");
                Console.Write("Вибір: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ChooseProvider();
                        break;
                    case "2":
                        LoadFromFile();
                        break;
                    case "3":
                        SaveToFile();
                        break;
                    case "4":
                        AddItem();
                        break;
                    case "5":
                        ShowAll();
                        break;
                    case "6":
                        EncryptItem();
                        break;
                    case "7":
                        DecryptItem();
                        break;
                    case "8":
                        Find();
                        break;
                    case "9":
                        Remove();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір");
                        break;
                }
            }
        }

        private void ChooseProvider()
        {
            Console.Write("Введіть тип провайдера (json/xml/binary/custom): ");
            string t = Console.ReadLine().Trim().ToLower();
            switch (t)
            {
                case "json":
                    _context.SetProvider(new JsonProvider());
                    break;
                case "xml":
                    _context.SetProvider(new XmlProvider());
                    break;
                case "binary":
                    _context.SetProvider(new BinaryProvider());
                    break;
                case "custom":
                    _context.SetProvider(new CustomProvider());
                    break;
                default:
                    Console.WriteLine("Невідомий тип провайдера. Залишено поточний.");
                    break;
            }
        }

        private void LoadFromFile()
        {
            Console.Write("Введіть шлях до файлу для завантаження: ");
            var path = Console.ReadLine();
            try
            {
                _service.Load(path);
                Console.WriteLine($"Завантажено {_service.Count} елементів.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка під час завантаження: " + ex.Message);
            }
        }

        private void SaveToFile()
        {
            Console.Write("Введіть шлях до файлу для збереження: ");
            var path = Console.ReadLine();
            try
            {
                _service.Save(path);
                Console.WriteLine("Збережено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка під час збереження: " + ex.Message);
            }
        }

        private void AddItem()
        {
            Console.Write("Введіть значення рядка: ");
            var val = Console.ReadLine();
            Console.Write("Введіть ключ (ціле число, зсув): ");
            if (!int.TryParse(Console.ReadLine(), out int key)) key = 1;
            Console.Write("Напрям (1 - вперед / 0 - назад): ");
            var dirStr = Console.ReadLine();
            bool dir = dirStr == "1" || dirStr?.ToLower() == "true";
            var item = new CipherString(val, key, dir);
            _service.Add(item);
            Console.WriteLine("Додано.");
        }

        private void ShowAll()
        {
            var all = _service.GetAll();
            int i = 0;
            foreach (var it in all)
            {
                Console.WriteLine($"[{i}] {it}");
                i++;
            }
            if (i == 0) Console.WriteLine("Немає елементів.");
        }

        private void EncryptItem()
        {
            Console.Write("Введіть індекс елемента для шифрування: ");
            if (!int.TryParse(Console.ReadLine(), out int idx)) { Console.WriteLine("Некоректний індекс"); return; }
            var list = new List<CipherString>(_service.GetAll());
            if (idx < 0 || idx >= list.Count) { Console.WriteLine("Індекс поза діапазоном"); return; }
            list[idx].Encrypt();
            // Оновлюємо внутрішній список — просте рішення: пересохранити весь список в сервісі
            // (в реальному BLL краще зробити метод Update)
            // Тут ми використовуємо рефлексію/доступ — але для простоти:
            // заміна: видалити і вставити
            _service.RemoveAt(idx);
            _service.Add(list[idx]);
            Console.WriteLine("Зашифровано та оновлено.");
        }

        private void DecryptItem()
        {
            Console.Write("Введіть індекс елемента для розшифрування: ");
            if (!int.TryParse(Console.ReadLine(), out int idx)) { Console.WriteLine("Некоректний індекс"); return; }
            var list = new List<CipherString>(_service.GetAll());
            if (idx < 0 || idx >= list.Count) { Console.WriteLine("Індекс поза діапазоном"); return; }
            list[idx].Decrypt();
            _service.RemoveAt(idx);
            _service.Add(list[idx]);
            Console.WriteLine("Розшифровано та оновлено.");
        }

        private void Find()
        {
            Console.Write("Введіть підрядок для пошуку: ");
            var q = Console.ReadLine();
            var found = _service.FindByValue(q);
            if (found.Count == 0) Console.WriteLine("Нічого не знайдено.");
            else
            {
                foreach (var f in found) Console.WriteLine(f);
            }
        }

        private void Remove()
        {
            Console.Write("Введіть індекс для видалення: ");
            if (!int.TryParse(Console.ReadLine(), out int idx)) { Console.WriteLine("Некоректний індекс"); return; }
            if (_service.RemoveAt(idx)) Console.WriteLine("Видалено.");
            else Console.WriteLine("Не вдалося видалити (індекс невірний).");
        }
    }
}
