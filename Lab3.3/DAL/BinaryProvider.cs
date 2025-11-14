#pragma warning disable SYSLIB0011
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab3._3.DAL
{
    public class BinaryProvider<T> : IDataProvider<T>
    {
        public void Save(string path, IEnumerable<T> items)
        {
            var bf = new BinaryFormatter();
            using var fs = File.Create(path);
            bf.Serialize(fs, new List<T>(items));
        }

        public IEnumerable<T> Load(string path)
        {
            if (!File.Exists(path)) return new List<T>();
            var bf = new BinaryFormatter();
            using var fs = File.OpenRead(path);
            return (List<T>)bf.Deserialize(fs);
        }
    }
}
#pragma warning restore SYSLIB0011
