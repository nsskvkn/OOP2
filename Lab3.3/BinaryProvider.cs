using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._3

{
    public class BinaryProvider : IDataProvider
    {
        public List<CipherString> Load(string path)
        {
            var result = new List<CipherString>();
            if (!File.Exists(path)) return result;

            using (var br = new BinaryReader(File.OpenRead(path)))
            {
                try
                {
                    int count = br.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        string value = br.ReadString();
                        int key = br.ReadInt32();
                        bool dir = br.ReadBoolean();
                        result.Add(new CipherString(value, key, dir));
                    }
                }
                catch (EndOfStreamException) { /* файл пошкоджено */ }
            }
            return result;
        }

        public void Save(string path, IEnumerable<CipherString> items)
        {
            using (var bw = new BinaryWriter(File.Create(path)))
            {
                var list = new List<CipherString>(items);
                bw.Write(list.Count);
                foreach (var it in list)
                {
                    bw.Write(it.Value ?? string.Empty);
                    bw.Write(it.Key);
                    bw.Write(it.Direction);
                }
            }
        }
    }
}
