using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Encryption
    {
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }
        public string EncryptedPassword { get; set; }
    }
}
