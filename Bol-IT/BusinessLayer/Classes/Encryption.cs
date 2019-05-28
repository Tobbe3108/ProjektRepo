using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Encryption
    {
        public string Username { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }
    }
}
