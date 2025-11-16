using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    public interface IFileRepository
    {
        void SavePerson(IPerson person);
        IPerson[] LoadAll();
    }
}
