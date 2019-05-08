using System;
using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(CalculateDistanceMethod.GetDistanceByAddresses("Jellingvej 15A, 7100", "Østerbrogade 20 2. Th., 7100"));
        }
    }
}
