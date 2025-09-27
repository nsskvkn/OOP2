namespace Lab3._1.ConsoleApp
using System;
using CoreLib;
using FileIO;

{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "data.txt";
            IFileRepository repo = new TextFileRepository(path);

            ConsoleMenu menu = new ConsoleMenu(repo);
            menu.Show();
        }
    }
}
