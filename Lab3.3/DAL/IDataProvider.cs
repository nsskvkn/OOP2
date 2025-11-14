using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._3.DAL
{
    public interface IDataProvider<T>
    {
        void Save(string path, IEnumerable<T> items);
        IEnumerable<T> Load(string path);
    }
}

