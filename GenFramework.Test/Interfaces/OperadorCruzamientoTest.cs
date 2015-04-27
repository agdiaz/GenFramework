using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenFramework.Interfaces;
using System.Collections.Generic;
using Rhino.Mocks;
using GenFramework.Implementacion.Parametros;
using GenFramework.Implementacion.OperadorCruzamiento;
using GenFramework.Interfaces.OperadorCruzamiento;
using GenFramework.Interfaces.Parametros;
using GenFramework.Implementacion;
using GenFramework.Interfaces.Poblacion;
using GenFramework.Implementacion.Poblacion;
using GenFramework.Interfaces.Genetica;
using GenFramework.Implementacion.Genetica;

namespace GenFramework.Test.Interfaces
{
    [TestClass]
    public class OperadorCruzamientoTest
    {
        private IPoblacion _poblacion;
        private IList<IIndividuo> _individuos;
        private IIndividuo _individuo1;
        private IIndividuo _individuo2;
        private IIndividuo _individuo3;
        private IIndividuo _individuo4;

        private IParametrosCruzamiento _parametrosCruzamientoSimple;
        private IIndividuo _individuo1h;
        private IIndividuo _individuo2h;
        private IIndividuo _individuo3h;
        private IIndividuo _individuo4h;

        [TestInitialize]
        public void TestInitialize()
        {
            this.CargarPoblacionInicial();

            _parametrosCruzamientoSimple = MockRepository.GenerateMock<IParametrosCruzamiento>();
            _parametrosCruzamientoSimple.Expect(e => e.IndiceCorte).Return(1);
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
            
            this._individuo1h = MockRepository.GenerateMock<IIndividuo>();
            this._individuo1h.Expect(e => e.Cromosoma).Return(new Cromosoma(Array.CreateInstance(typeof(IGen), 3))).Repeat.Any();
            this._individuo1 = MockRepository.GenerateMock<IIndividuo>();
            this._individuo1.Expect(e => e.Cromosoma).Return(new Cromosoma(genes1)).Repeat.Any();
            this._individuo1.Expect(e => e.GenerarDescendencia(_individuo1)).Return(_individuo1h);

            var genes2 = Array.CreateInstance(typeof(IGen), 3);
            var genBasico2A = MockRepository.GenerateMock<IGen>();
            var genBasico2B = MockRepository.GenerateMock<IGen>();
            var genBasico2C = MockRepository.GenerateMock<IGen>();
            genes2.SetValue(genBasico2A, 0);
            genes2.SetValue(genBasico2A, 1);
            genes2.SetValue(genBasico2A, 2);
            this._individuo2h = MockRepository.GenerateMock<IIndividuo>();
            this._individuo2h.Expect(e => e.Cromosoma).Return(new Cromosoma(Array.CreateInstance(typeof(IGen), 3))).Repeat.Any();
            this._individuo2 = MockRepository.GenerateMock<IIndividuo>();
            this._individuo2.Expect(e => e.Cromosoma).Return(new Cromosoma(genes2)).Repeat.Any(); 
            this._individuo2.Expect(e => e.GenerarDescendencia(_individuo2)).Return(_individuo2h);


            var genes3 = Array.CreateInstance(typeof(IGen), 3);
            var genBasico3A = MockRepository.GenerateMock<IGen>();
            var genBasico3B = MockRepository.GenerateMock<IGen>();
            var genBasico3C = MockRepository.GenerateMock<IGen>();
            genes3.SetValue(genBasico3A, 0);
            genes3.SetValue(genBasico3A, 1);
            genes3.SetValue(genBasico3A, 2);
            this._individuo3h = MockRepository.GenerateMock<IIndividuo>();
            this._individuo3h.Expect(e => e.Cromosoma).Return(new Cromosoma(Array.CreateInstance(typeof(IGen), 3))).Repeat.Any();
            this._individuo3 = MockRepository.GenerateMock<IIndividuo>();
            this._individuo3.Expect(e => e.Cromosoma).Return(new Cromosoma(genes3)).Repeat.Any();
            this._individuo3.Expect(e => e.GenerarDescendencia(_individuo3)).Return(_individuo3h);

            var genes4 = Array.CreateInstance(typeof(IGen), 3);
            var genBasico4A = MockRepository.GenerateMock<IGen>();
            var genBasico4B = MockRepository.GenerateMock<IGen>();
            var genBasico4C = MockRepository.GenerateMock<IGen>();
            genes4.SetValue(genBasico1A, 0);
            genes4.SetValue(genBasico1A, 1);
            genes4.SetValue(genBasico1A, 2);
            this._individuo4h = MockRepository.GenerateMock<IIndividuo>();
            this._individuo4h.Expect(e => e.Cromosoma).Return(new Cromosoma(Array.CreateInstance(typeof(IGen), 3))).Repeat.Any();
            this._individuo4 = MockRepository.GenerateMock<IIndividuo>();
            this._individuo4.Expect(e => e.Cromosoma).Return(new Cromosoma(genes4)).Repeat.Any();
            this._individuo4.Expect(e => e.GenerarDescendencia(_individuo4)).Return(_individuo4h);



            this._individuos = new List<IIndividuo>() { this._individuo1, this._individuo2, this._individuo3, this._individuo4 };
            this._poblacion = new Poblacion(_individuos);
            this._poblacion.CantidadIndividuos = 4;
        }


        [TestMethod]
        public void CruzamientoSimpleTest()
        {
            IOperadorCruzamiento operador = new OperadorCruzamientoSimple(_parametrosCruzamientoSimple);

            var poblacionFinal = operador.Cruzar(this._poblacion);

            Assert.AreEqual(_individuos.Count, poblacionFinal.PoblacionActual.Count);
        }
    }
}
