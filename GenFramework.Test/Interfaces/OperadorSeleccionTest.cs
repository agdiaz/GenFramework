using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GenFramework.Interfaces;
using Rhino.Mocks;
using GenFramework.Implementacion.OperadorSeleccion;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.OperadorSeleccion;
using GenFramework.Implementacion;
using GenFramework.Interfaces.Poblacion;
using GenFramework.Implementacion.Poblacion;
using GenFramework.Interfaces.Genetica;
using GenFramework.Implementacion.Genetica;

namespace GenFramework.Test.Interfaces
{
    [TestClass]
    public class OperadorSeleccionTest
    {
        private IList<IIndividuo> _individuos;
        private IIndividuo _individuo1;
        private IIndividuo _individuo2;
        private IIndividuo _individuo3;
        private IIndividuo _individuo4;

        private IParametrosSeleccion _parametrosSeleccionPorTorneo;
        private IFuncionFitness _funcionFitness;
        private Poblacion _poblacion;

        [TestInitialize]
        public void TestInitialize()
        {
            this.CargarPoblacionInicial();

            _funcionFitness = MockRepository.GenerateMock<IFuncionFitness>();
            _parametrosSeleccionPorTorneo = MockRepository.GenerateMock<IParametrosSeleccion>();
            _parametrosSeleccionPorTorneo.Expect(e => e.CantidadIndividuosASeleccionar).Return(2);
            _parametrosSeleccionPorTorneo.Expect(e => e.FuncionFitness).Return(_funcionFitness);
        }

        private void CargarPoblacionInicial()
        {
            var genes1 = Array.CreateInstance(typeof(IGen), 3);
            var genBasico1A = MockRepository.GenerateMock<IGen>();
            var genBasico1B = MockRepository.GenerateMock<IGen>();
            var genBasico1C = MockRepository.GenerateMock<IGen>();
            genes1.SetValue(genBasico1A, 0);
            genes1.SetValue(genBasico1A, 1);
            genes1.SetValue(genBasico1A, 2);
            this._individuo1 = MockRepository.GenerateMock<IIndividuo>();
            this._individuo1.Expect(e => e.Cromosoma).Return(new Cromosoma(genes1)).Repeat.Any();

            var genes2 = Array.CreateInstance(typeof(IGen), 3);
            var genBasico2A = MockRepository.GenerateMock<IGen>();
            var genBasico2B = MockRepository.GenerateMock<IGen>();
            var genBasico2C = MockRepository.GenerateMock<IGen>();
            genes2.SetValue(genBasico2A, 0);
            genes2.SetValue(genBasico2A, 1);
            genes2.SetValue(genBasico2A, 2);
            this._individuo2 = MockRepository.GenerateMock<IIndividuo>();
            this._individuo2.Expect(e => e.Cromosoma).Return(new Cromosoma(genes2)).Repeat.Any();

            var genes3 = Array.CreateInstance(typeof(IGen), 3);
            var genBasico3A = MockRepository.GenerateMock<IGen>();
            var genBasico3B = MockRepository.GenerateMock<IGen>();
            var genBasico3C = MockRepository.GenerateMock<IGen>();
            genes3.SetValue(genBasico3A, 0);
            genes3.SetValue(genBasico3A, 1);
            genes3.SetValue(genBasico3A, 2);
            this._individuo3 = MockRepository.GenerateMock<IIndividuo>();
            this._individuo3.Expect(e => e.Cromosoma).Return(new Cromosoma(genes3)).Repeat.Any();

            var genes4 = Array.CreateInstance(typeof(IGen), 3);
            var genBasico4A = MockRepository.GenerateMock<IGen>();
            var genBasico4B = MockRepository.GenerateMock<IGen>();
            var genBasico4C = MockRepository.GenerateMock<IGen>();
            genes4.SetValue(genBasico1A, 0);
            genes4.SetValue(genBasico1A, 1);
            genes4.SetValue(genBasico1A, 2);
            this._individuo4 = MockRepository.GenerateMock<IIndividuo>();
            this._individuo4.Expect(e => e.Cromosoma).Return(new Cromosoma(genes4)).Repeat.Any();


            this._individuos = new List<IIndividuo>() { this._individuo1, this._individuo2, this._individuo3, this._individuo4 };
            this._poblacion = new Poblacion(_individuos);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _individuo1.VerifyAllExpectations();
            _individuo2.VerifyAllExpectations();
            _individuo3.VerifyAllExpectations();
            _individuo4.VerifyAllExpectations();

            _funcionFitness.VerifyAllExpectations();
        }

        [TestMethod]
        public void SeleccionPorTorneoTest()
        {
            _funcionFitness.Expect(e => e.Evaluar(_individuo1)).Return(4).Repeat.Any();
            _funcionFitness.Expect(e => e.Evaluar(_individuo2)).Return(1).Repeat.Any();
            _funcionFitness.Expect(e => e.Evaluar(_individuo3)).Return(7).Repeat.Any();
            _funcionFitness.Expect(e => e.Evaluar(_individuo4)).Return(8).Repeat.Any();

            IOperadorSeleccion operador = new OperadorSeleccionPorTorneo(_parametrosSeleccionPorTorneo);

            var poblacionFinal = operador.Seleccionar(this._poblacion);

            Assert.AreEqual(2, _parametrosSeleccionPorTorneo.CantidadIndividuosASeleccionar);
        }


    }
}
