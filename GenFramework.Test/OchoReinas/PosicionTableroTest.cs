//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using GenFramework.OchoReinas.Genetica;
//using GenFramework.OchoReinas.Fitness;
//using System.Collections.Generic;

//namespace GenFramework.Test.OchoReinas
//{
//    [TestClass]
//    public class PosicionTableroTest
//    {
//        [TestMethod]
//        public void PosicionesProhibidasTest()
//        {
//            var posicionTablero = new PosicionTablero(0, 0);
//            var posicionesProhibidas = posicionTablero.PosicionesProhibidas();

//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(1, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(2, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(3, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(4, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(5, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(6, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(7, 0)));

//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 1)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 2)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 3)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 4)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 5)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 6)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 7)));

//        }

//        [TestMethod]
//        public void DosReinasTest()
//        {
//            var analizador = new AnalizadorTablero();
//            analizador.AgregarReina(0, 0).AgregarReina(7, 7);

//            List<PosicionTablero> posicionesProhibidas = analizador.ObtenerPosicionesProhibidas();

//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 0, 1)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(1, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(2, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(3, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(4, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(5, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(6, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(7, 0)));

//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 1)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 2)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 3)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 4)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 5)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 6)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(0, 7)));

//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(7, 0)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(7, 1)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(7, 2)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(7, 3)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(7, 4)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(7, 5)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(7, 6)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(7, 7, 2)));

//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(1, 7)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(2, 7)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(3, 7)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(4, 7)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(5, 7)));
//            Assert.IsTrue(posicionesProhibidas.Contains(new PosicionTablero(6, 7)));
//        }

//        [TestMethod]
//        public void CantidadReinasVivasCon2ReinasTest()
//        {
//            var analizador = new AnalizadorTablero();
//            analizador.AgregarReina(0, 0).AgregarReina(7, 7);

//            List<PosicionTablero> reinasVivas = analizador.ObtenerReinasVivas();

//            Assert.AreEqual(2, reinasVivas.Count);
//        }
        
//        [TestMethod]
//        public void CantidadReinasVivasCon3ReinasTest()
//        {
//            var analizador = new AnalizadorTablero();
//            analizador.AgregarReina(0, 0).AgregarReina(7, 7).AgregarReina(0, 7);

//            List<PosicionTablero> reinasVivas = analizador.ObtenerReinasVivas();

//            Assert.AreEqual(0, reinasVivas.Count);
//        }

//    }
//}
