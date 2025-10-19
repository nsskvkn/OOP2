using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using  Lab3._2;
using Lab3_2.Collections;

namespace Lab3_Program
{

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Демонстрація: CipherString, колекції, бінарне дерево (preorder)");

            // 1) Generic List<CipherString>
            var list = new List<CipherString>
        {
            new CipherString("hello", 2),
            new CipherString("world", 3),
            new CipherString("abc", 1)
        };
            Console.WriteLine("Generic List:");
            foreach (var s in list) Console.WriteLine(" " + s);
            // До/видал/оновл
            list.Add(new CipherString("new", 1));
            list.RemoveAt(0);
            list[0] = new CipherString("replaced", 5);
            Console.WriteLine("Після змін:");
            foreach (var s in list) Console.WriteLine(" " + s);
            Console.WriteLine(new string('-', 40));

            // 2) Non-generic ArrayList
            var arrList = new ArrayList(list);
            arrList.Add(new CipherString("x", 7));
            Console.WriteLine("ArrayList (non-generic) та безпечна ітерація:");
            foreach (var o in arrList)
            {
                if (o is CipherString cs) Console.WriteLine(" " + cs);
                else Console.WriteLine("  (інший тип)");
            }
            Console.WriteLine(new string('-', 40));

            // 3) Масив
            var arr = new CipherString[list.Count];
            list.CopyTo(arr);
            Console.WriteLine("Масив:");
            for (int i = 0; i < arr.Length; i++) Console.WriteLine($" [{i}] {arr[i]}");
            Console.WriteLine(new string('-', 40));

            // 4) BinaryTree (preorder) — використовуємо стандартне порівняння (IComparable)
            var tree = new BinaryTree<CipherString>();
            foreach (var s in list) tree.Insert(s);
            tree.Insert(new CipherString("yy", 2));
            Console.WriteLine("Обхід дерева (preorder):");
            foreach (var s in tree) Console.WriteLine(" " + s);
            Console.WriteLine(new string('-', 40));

            // Демонстрація шифрування/дешифрування
            var demo = new CipherString("Test123", 1);
            Console.WriteLine("Before: " + demo);
            demo.Encrypt();
            Console.WriteLine("Encrypted: " + demo);
            demo.Decrypt();
            Console.WriteLine("Decrypted: " + demo);
        }
    }
}