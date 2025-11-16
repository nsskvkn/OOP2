using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._5.BLL
{
    public class Joiner
    {
        public string Name { get; set; }

        public Joiner(string name) => Name = name ?? "Joiner";

        public void DoJoin()
        {
            Console.WriteLine($"{Name} виконує з'єднання деталей.");
        }
    }
}