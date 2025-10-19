using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::Lab3._3;

namespace Lab3._3

{
    public interface IDataProvider
    {
        void Save(string path, IEnumerable<CipherString> items);
        List<CipherString> Load(string path);
    }
}
