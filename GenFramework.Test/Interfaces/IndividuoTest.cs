using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenFramework.Interfaces.Genetica;
using GenFramework.Implementacion.Genetica;
using GenFramework.Test.Fakes;

namespace GenFramework.Test.Interfaces
{
    [TestClass]
    public class IndividuoTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void ValidacionGenotipoTest()
        {
            var vaca = new IndividuoAnimal();
            var hombre = new IndividuoHumano();

            var ternero = vaca.GenerarDescendencia(vaca);
            var nene = hombre.GenerarDescendencia(hombre);

            Assert.AreNotEqual(ternero.Genotipo, nene.Genotipo);
        }
    }
}
