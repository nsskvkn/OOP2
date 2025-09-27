using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using  Lab3._2;

namespace Lab3_Program
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Лабораторна: Трапеція, колекції, бінарне дерево (inorder) ===\n");

            // ===== Generic List<T> =====
            Console.WriteLine("1) Generic List<Trapezoid>:");
            var genericList = new List<Trapezoid>
            {
                new Trapezoid(10, 5, 4, Color.LightBlue, Color.DarkBlue),
                new Trapezoid(8, 2, 1, Color.Yellow, Color.Black),
                new Trapezoid(14, 10, 6, Color.Green, Color.Black),
                new Trapezoid(15, 5, 4, Color.Pink, Color.Red)
            };

            // Додавання
            genericList.Add(new Trapezoid(1, 2, 3));
            // Видалення (останній)
            genericList.RemoveAt(genericList.Count - 1);
            // Оновлення
            genericList[3] = new Trapezoid(20, 15, 10, Color.Beige, Color.Brown);
            // Пошук
            var found = genericList.Find(t => Math.Abs(t.Base1 - 8) < 1e-9);
            Console.WriteLine(found != null ? found.ToString() : "Not found");
            Console.WriteLine();

            Console.WriteLine("Вміст genericList:");
            foreach (var t in genericList) Console.WriteLine("  " + t);
            Console.WriteLine($"Кількість об'єктів (Trapezoid.InstanceCount): {Trapezoid.InstanceCount}");
            Console.WriteLine(new string('=', 40));

            // ===== Non-generic ArrayList =====
            Console.WriteLine("2) Non-generic ArrayList:");
            var nonGenericList = new ArrayList(genericList); // копіюємо елементи
            nonGenericList.Add(new Trapezoid(2, 3, 4));
            nonGenericList.RemoveAt(nonGenericList.Count - 1);
            nonGenericList[3] = new Trapezoid(13, 8, 3);

            Console.WriteLine("Вміст nonGenericList (перевірка типу при ітерації):");
            foreach (var item in nonGenericList)
            {
                if (item is Trapezoid tr)
                {
                    if (Math.Abs(tr.Height - 1.0) < 1e-9)
                    {
                        Console.WriteLine("  Found height == 1: " + tr);
                    }
                    Console.WriteLine("  " + tr);
                }
            }
            Console.WriteLine(new string('=', 40));

            // ===== Array =====
            Console.WriteLine("3) Масив Trapezoid[]:");
            Trapezoid[] array = new Trapezoid[4];
            for (int i = 0; i < Math.Min(genericList.Count, array.Length); i++)
            {
                array[i] = genericList[i];
            }

            // Додавання: створимо новий масив з додатковим елементом
            array = array.Append(new Trapezoid(5, 6, 7)).ToArray();
            // Видалення: видалимо елемент з індексом 4
            array = array.Where((_, idx) => idx != 4).ToArray();
            // Оновлення
            array[3] = new Trapezoid(19, 9, 5);
            // Пошук за умовою
            foreach (var t in array)
            {
                if (Math.Abs(t.Base2 - 9.0) < 1e-9)
                {
                    Console.WriteLine("Found base2 == 9: " + t);
                }
            }
            Console.WriteLine(new string('=', 40));

            // Очистити nonGenericList та масив
            nonGenericList.Clear();
            array = Array.Empty<Trapezoid>();

            // ===== Binary tree (inorder) =====
            Console.WriteLine("4) Бінарне дерево (BinaryTree<Trapezoid>) — порядок обходу: INORDER (центрований): left, current, right");
            // Створимо дерево з genericList
            var tree = new BinaryTree<Trapezoid>(genericList);

            // Додаємо ще кілька елементів
            tree.Insert(new Trapezoid(96, 54, 12));
            tree.Insert(new Trapezoid(3, 2, 0.5));

            Console.WriteLine("Обхід дерева (inorder):");
            foreach (var t in tree)
            {
                Console.WriteLine("  " + t);
            }

            // Пошук через дерево (наприклад, знайти перший з площею > 20)
            var foundInTree = tree.Find(x => x.GetArea() > 20.0);
            Console.WriteLine(foundInTree != null ? "Found in tree: " + foundInTree : "Not found in tree");
            Console.WriteLine(new string('=', 40));

            Console.WriteLine($"Кінець демонстрації. Поточна кількість створених об'єктів: {Trapezoid.InstanceCount}");
        }
    }
}
