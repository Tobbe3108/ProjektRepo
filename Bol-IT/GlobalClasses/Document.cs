using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses
{
    public class Document
    {
        public int CaseNr { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public Byte[] Data { get; set; }
    }
}
