using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Lab3._3
{
    public class CustomProvider : IDataProvider<string>
    {
        public void Save(string path, IEnumerable<string> items)
        {
            File.WriteAllLines(path, items);
        }

        public IEnumerable<string> Load(string path)
        {
            if (!File.Exists(path)) return new List<string>();
            return File.ReadAllLines(path);
        }
    }
}
