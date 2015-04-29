using GenFramework.Interfaces.OperadorSeleccion;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.OperadorSeleccion
{
    public class OperadorSeleccionRanking : IOperadorSeleccion
    {
        private IParametrosSeleccion _parametrosSeleccionPorTorneo;

        public OperadorSeleccionRanking(IParametrosSeleccion _parametrosSeleccionPorTorneo)
        {
            this._parametrosSeleccionPorTorneo = _parametrosSeleccionPorTorneo;
        }

        public IPoblacion Seleccionar(IPoblacion poblacionInicial)
        {
            var poblacionSeleccionada = new Poblacion.Poblacion(poblacionInicial.NumeroGeneracion, new List<IIndividuo>(poblacionInicial.PoblacionActual.Count));
            poblacionSeleccionada.CantidadIndividuos = poblacionInicial.CantidadIndividuos;

            var mejores = poblacionInicial.PoblacionActual.OrderByDescending(p => _parametrosSeleccionPorTorneo.FuncionFitness.Evaluar(p)).Take(_parametrosSeleccionPorTorneo.CantidadIndividuosASeleccionar).ToList();

            foreach (var mejor in mejores)
            {
                poblacionSeleccionada.PoblacionActual.Add(mejor);
            }

            return poblacionSeleccionada;
        }
    }
}
