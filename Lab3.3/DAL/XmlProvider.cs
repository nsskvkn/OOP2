using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Lab3._3.DAL
{
    public class XmlProvider<T> : IDataProvider<T>
    {
        public void Save(string path, IEnumerable<T> items)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using var fs = File.Create(path);
            serializer.Serialize(fs, new List<T>(items));
        }

        public IEnumerable<T> Load(string path)
        {
            if (!File.Exists(path)) return new List<T>();
            var serializer = new XmlSerializer(typeof(List<T>));
            using var fs = File.OpenRead(path);
            return (List<T>)serializer.Deserialize(fs)!;
        }
    }
}

