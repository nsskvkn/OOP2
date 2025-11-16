using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib;

namespace CoreLib
{
    public class Joiner : Person
    {
        public string CertificateNumber { get; set; } 

        public Joiner(string firstName, string lastName, string certificateNumber) : base(firstName, lastName)
        {
            CertificateNumber = certificateNumber;
        }

        public void Work(){}

        public override string ToString()
        {
            return $"Joiner: {FirstName} {LastName}, Cert: {CertificateNumber}";
        }
    }
}
