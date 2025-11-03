using System;
using Lab3._3;

namespace Program3
{
    class Program
    {
        static void Main()
        {
            AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", true);
            Menu.MainMenu();
            Console.WriteLine("...");
            Console.ReadLine();
        }
    }
}
