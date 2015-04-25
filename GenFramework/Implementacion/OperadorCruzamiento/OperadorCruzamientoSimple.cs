using GenFramework.Interfaces;
using GenFramework.Interfaces.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenFramework.Implementacion;
using GenFramework.Interfaces.OperadorCruzamiento;
using GenFramework.Interfaces.Poblacion;
using GenFramework.Implementacion.Poblacion;

namespace GenFramework.Implementacion.OperadorCruzamiento
{
    public class OperadorCruzamientoSimple : IOperadorCruzamiento
    {
        private IParametrosCruzamiento _parametrosCruzamientoSimple;

        public OperadorCruzamientoSimple(IParametrosCruzamiento _parametrosCruzamientoSimple)
        {
            this._parametrosCruzamientoSimple = _parametrosCruzamientoSimple;
        }
        #region IOperadorCruzamiento
        public IPoblacion Cruzar(IPoblacion poblacionSeleccionada)
        {
            var individuos = new List<IIndividuo>();
            var poblacionFinal = new Poblacion.Poblacion(individuos);

            for (int cantidadIndividuos = 0; cantidadIndividuos < (int)poblacionSeleccionada.PoblacionActual.Count / 2; cantidadIndividuos++)
            {
                var individuo1 = poblacionSeleccionada.ObtenerIndividuo();
                var individuo2 = poblacionSeleccionada.ObtenerIndividuo();

                Tuple<IIndividuo, IIndividuo> hijos = this.CruzarIndividuos(individuo1, individuo2);

                poblacionFinal.PoblacionActual.Add(hijos.Item1);
                poblacionFinal.PoblacionActual.Add(hijos.Item2);
            
            }
            
            return poblacionFinal;
        }

        private Tuple<IIndividuo, IIndividuo> CruzarIndividuos(IIndividuo individuo1, IIndividuo individuo2)
        {
            IIndividuo hijo1 = new GenFramework.Implementacion.Poblacion.Individuo(individuo1.Cromosoma.CantidadGenes);
            IIndividuo hijo2 = new GenFramework.Implementacion.Poblacion.Individuo(individuo1.Cromosoma.CantidadGenes);

            for (int indiceGenPadre = 0; indiceGenPadre <= _parametrosCruzamientoSimple.IndiceCorte; indiceGenPadre++)
            {
                hijo1.Cromosoma.Genes.SetValue(individuo1.Cromosoma.Genes.GetValue(indiceGenPadre), indiceGenPadre);
                hijo2.Cromosoma.Genes.SetValue(individuo2.Cromosoma.Genes.GetValue(indiceGenPadre), indiceGenPadre);
            }

            for (int indiceGenPadre = _parametrosCruzamientoSimple.IndiceCorte + 1; indiceGenPadre < hijo1.Cromosoma.CantidadGenes; indiceGenPadre++)
            {
                hijo1.Cromosoma.Genes.SetValue(individuo2.Cromosoma.Genes.GetValue(indiceGenPadre), indiceGenPadre);
                hijo2.Cromosoma.Genes.SetValue(individuo1.Cromosoma.Genes.GetValue(indiceGenPadre), indiceGenPadre);
            }

            return new Tuple<IIndividuo, IIndividuo>(hijo1, hijo2);
        }
        #endregion
    }
}
