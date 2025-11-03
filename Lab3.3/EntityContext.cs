using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._3
{
    public class EntityContext<T>
    {
        private readonly IDataProvider<T> _provider;
        public EntityContext(IDataProvider<T> provider)
        {
            _provider = provider;
        }

        public void Save(string path, IEnumerable<T> items) => _provider.Save(path, items);
        public IEnumerable<T> Load(string path) => _provider.Load(path);
    }
}
