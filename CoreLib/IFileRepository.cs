using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib;

namespace Lab3._1.CoreLib
{
    public interface IFileRepository
    {
        void SavePerson(IPerson person);
        IPerson[] LoadAll();
    }
}
