using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._3

{
    public class XmlProvider : IDataProvider
    {
        public List<CipherString> Load(string path)
        {
            if (!File.Exists(path)) return new List<CipherString>();
            var serializer = new XmlSerializer(typeof(List<CipherString>));
            using (var stream = File.OpenRead(path))
            {
                return (List<CipherString>)serializer.Deserialize(stream);
            }
        }

        public void Save(string path, IEnumerable<CipherString> items)
        {
            var serializer = new XmlSerializer(typeof(List<CipherString>));
            using (var stream = File.Create(path))
            {
                serializer.Serialize(stream, new List<CipherString>(items));
            }
        }
    }
}
