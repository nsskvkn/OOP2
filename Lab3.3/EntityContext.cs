using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._3

{
    public class EntityContext
    {
        private IDataProvider _provider;

        public EntityContext(IDataProvider provider)
        {
            _provider = provider;
        }

        public List<CipherString> Load(string path)
        {
            return _provider.Load(path);
        }

        public void Save(string path, IEnumerable<CipherString> items)
        {
            _provider.Save(path, items);
        }

        // Можна додати зміну провайдера "на льоту"
        public void SetProvider(IDataProvider provider)
        {
            _provider = provider;
        }
    }
}
