using GenFramework.Interfaces;
using GenFramework.Interfaces.Genetica;
using GenFramework.Interfaces.OperadorSeleccion;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.Implementacion.OperadorSeleccion
{
    public class OperadorSeleccionPorTorneo : IOperadorSeleccion
    {
        private IParametrosSeleccion _parametrosSeleccionPorTorneo;

        public OperadorSeleccionPorTorneo(IParametrosSeleccion _parametrosSeleccionPorTorneo)
        {
            this._parametrosSeleccionPorTorneo = _parametrosSeleccionPorTorneo;
        }

        public IPoblacion Seleccionar(IPoblacion poblacionInicial)
        {
            var poblacionSeleccionada = new Poblacion.Poblacion(poblacionInicial.NumeroGeneracion, new List<IIndividuo>(poblacionInicial.PoblacionActual.Count));
            poblacionSeleccionada.CantidadIndividuos = poblacionInicial.CantidadIndividuos;

            for (int cantidadIndividuos = 0; cantidadIndividuos < _parametrosSeleccionPorTorneo.CantidadIndividuosASeleccionar; cantidadIndividuos+=2)
            {
                IIndividuo individuo1 = poblacionInicial.ObtenerIndividuo();
                IIndividuo individuo2 = poblacionInicial.ObtenerIndividuo();

                IIndividuo individuoGanador = this.ObtenerGanador(individuo1, individuo2);
                poblacionSeleccionada.PoblacionActual.Add(individuoGanador);
            }

            return poblacionSeleccionada;
        }

        private IIndividuo ObtenerGanador(IIndividuo individuo1, IIndividuo individuo2)
        {
            IFuncionFitness funcionFitness = _parametrosSeleccionPorTorneo.FuncionFitness;

            var fitness1 = funcionFitness.Evaluar(individuo1);
            var fitness2 = funcionFitness.Evaluar(individuo2);

            if (fitness1 >= fitness2)
            {
                return individuo1;
            }
            else
            {
                return individuo2;
            }

        }

    }
}
