using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenFramework.Interfaces.Parametros;
using GenFramework.Implementacion.Parametros;

namespace GenFramework.Test.Interfaces
{
    [TestClass]
    public class ParametrosTest
    {
        [TestMethod]
        public void ParametrosPropiedadesTest()
        {
            IParametros p = new Parametros();
            p.IntervaloPorVuelta = 1500;

            Assert.AreEqual(1500, p.IntervaloPorVuelta);
        }
    }
}
