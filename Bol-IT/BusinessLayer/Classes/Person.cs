using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public abstract class Person
    {
        #region Properties

        //Simone
        public int Id { get; set; }

        public string FName { get; set; }

        public string MName { get; set; }

        public string LName { get; set; }

        public int PhoneNr { get; set; }

        public string Address { get; set; }

        public int Zipcode { get; set; }

        public string Mail { get; set; }

        #endregion
    }
}
