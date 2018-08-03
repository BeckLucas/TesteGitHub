using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteGitHub;

namespace TesteGitHubTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethodSucess()
        {
            ConversorTemperatura t1 = new ConversorTemperatura();
            Assert.AreEqual(t1.Soma(), 2);
        }

        [TestMethod]
        public void TestMethodError()
        {
            ConversorTemperatura t2 = new ConversorTemperatura();
            Assert.AreEqual(t2.Soma(), 2);
        }

        [TestMethod]
        public void Test()
        {
            ConversorTemperatura t1 = new ConversorTemperatura();
            Assert.AreEqual(t1.Soma(), 2);
        }
    }
}
