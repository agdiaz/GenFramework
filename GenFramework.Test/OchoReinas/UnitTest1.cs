using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenFramework.OchoReinas.LogicaNegocio;

namespace GenFramework.Test.OchoReinas
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UnaReinaTest()
        {
            var tablero = new Tablero();

            tablero.AgregarReina(0, 0, 0);

            Assert.AreEqual(1, tablero.CalcularReinasVivas().Count);
        }

        [TestMethod]
        public void UnaReinaMedioTest()
        {
            var tablero = new Tablero();

            tablero.AgregarReina(3, 3, 0);

            Assert.AreEqual(1, tablero.CalcularReinasVivas().Count);
        }

        [TestMethod]
        public void DosReinasUnaEnMedioVivasTest()
        {
            var tablero = new Tablero();

            tablero.AgregarReina(3, 3, 0).AgregarReina(0, 2, 1);

            Assert.AreEqual(2, tablero.CalcularReinasVivas().Count);
        }

        [TestMethod]
        public void DosReinasSuperpuestasMuertasTest()
        {
            var tablero = new Tablero();

            tablero.AgregarReina(3, 3, 0).AgregarReina(3, 3, 1);

            Assert.AreEqual(0, tablero.CalcularReinasVivas().Count);
        }


        [TestMethod]
        public void TresUnaEnMedioVivasTest()
        {
            var tablero = new Tablero();

            tablero.AgregarReina(3, 3, 0).AgregarReina(0, 2, 1).AgregarReina(2, 1, 2);

            Assert.AreEqual(3, tablero.CalcularReinasVivas().Count);
        }

        [TestMethod]
        public void TresReinasTest()
        {
            var tablero = new Tablero();

            tablero.AgregarReina(0, 0, 0).AgregarReina(7, 7, 1).AgregarReina(3, 1, 2);

            Assert.AreEqual(1, tablero.CalcularReinasVivas().Count);
        }

        [TestMethod]
        public void OchoReinasVivasReinasTest()
        {
            var tablero = new Tablero();

            tablero.AgregarReina(0, 3, 0);
            tablero.AgregarReina(1, 6, 1);
            tablero.AgregarReina(2, 2, 2);
            tablero.AgregarReina(3, 7, 3);
            tablero.AgregarReina(4, 1, 4);
            tablero.AgregarReina(5, 4, 5);
            tablero.AgregarReina(6, 0, 6);
            tablero.AgregarReina(7, 5, 7);

            Assert.AreEqual(8, tablero.CalcularReinasVivas().Count);
        }
    }
}
