using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenFramework.Interfaces;
using GenFramework.Implementacion;
using Rhino.Mocks;
using System.Collections.Generic;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.OperadorSeleccion;
using GenFramework.Interfaces.OperadorMutacion;
using GenFramework.Interfaces.OperadorCorte;
using GenFramework.Interfaces.OperadorCruzamiento;
using GenFramework.Interfaces.Poblacion;

namespace GenFramework.Test
{
    [TestClass]
    public class AlgoritmoGeneticoTest
    {
        private IAlgoritmoGenetico _algoritmoGenetico;
        private IOperadorSeleccion _operadorSeleccion;
        private IOperadorCruzamiento _operadorCruzamiento;
        private IOperadorMutacion _operadorMutacion;
        private IOperadorCorte _operadorCorte;
        private IPoblacion _poblacionInicial;
        private List<IIndividuo> _individuos;

        [TestInitialize]
        public void TestInitialize()
        {
            this._operadorSeleccion = MockRepository.GenerateMock<IOperadorSeleccion>();
            this._operadorCruzamiento = MockRepository.GenerateMock<IOperadorCruzamiento>();
            this._operadorMutacion = MockRepository.GenerateMock<IOperadorMutacion>();
            this._operadorCorte = MockRepository.GenerateMock<IOperadorCorte>();
            this._individuos = new List<IIndividuo>();
            this._poblacionInicial = MockRepository.GenerateMock<IPoblacion>();
            this._poblacionInicial.Expect(e => e.PoblacionActual).Return(this._individuos).Repeat.Any();

            this._algoritmoGenetico = new AlgoritmoGenetico(_poblacionInicial,
                _operadorSeleccion, 
                _operadorCruzamiento, 
                _operadorMutacion, 
                _operadorCorte);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _poblacionInicial.VerifyAllExpectations();
            _operadorSeleccion.VerifyAllExpectations();
            _operadorCruzamiento.VerifyAllExpectations();
            _operadorMutacion.VerifyAllExpectations();
            _operadorCorte.VerifyAllExpectations();
        }

        [TestMethod]
        public void AlgoritmoGeneticoInstanciaTest()
        {
            //Expectations:
            _operadorSeleccion.Expect(e => e.Seleccionar(_poblacionInicial))
                .Repeat.Once()
                .Return(_poblacionInicial);
            _operadorCruzamiento.Expect(e => e.Cruzar(_poblacionInicial))
                .Repeat.Once()
                .Return(_poblacionInicial);
            _operadorMutacion.Expect(e => e.Mutar(_poblacionInicial))
                .Repeat.Once()
                .Return(_poblacionInicial);
            _operadorCorte.Expect(e => e.CortarEjecucion(_poblacionInicial))
                .Repeat.Once()
                .Return(true);

            var parametros = MockRepository.GenerateMock<IParametros>();
            var poblacionFinal = this._algoritmoGenetico.Ejecutar(parametros);

            Assert.AreEqual(_poblacionInicial.PoblacionActual, poblacionFinal.PoblacionActual);
        }
    }
}
