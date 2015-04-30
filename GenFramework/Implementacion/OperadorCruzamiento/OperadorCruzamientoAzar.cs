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
using GenFramework.Interfaces.Genetica;

namespace GenFramework.Implementacion.OperadorCruzamiento
{
    public class OperadorCruzamientoAzar : IOperadorCruzamiento
    {
        private IParametrosCruzamiento _parametrosCruzamientoSimple;
        private Random _generador;

        public OperadorCruzamientoAzar(IParametrosCruzamiento _parametrosCruzamientoSimple)
        {
            this._generador = new Random();
            this._parametrosCruzamientoSimple = _parametrosCruzamientoSimple;
        }

        #region IOperadorCruzamiento
        public IPoblacion Cruzar(IPoblacion poblacionSeleccionada)
        {
            var individuos = new List<IIndividuo>(poblacionSeleccionada.PoblacionActual.Count);
            var poblacionFinal = new Poblacion.Poblacion(poblacionSeleccionada.NumeroGeneracion, individuos);
            poblacionFinal.CantidadIndividuos = poblacionSeleccionada.CantidadIndividuos;

            for (int cantidadIndividuos = 0; cantidadIndividuos < poblacionSeleccionada.CantidadIndividuos; cantidadIndividuos+=2)
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
            IIndividuo hijo1 = individuo1.GenerarDescendencia(individuo1);
            

            for (int indiceGen = 0; indiceGen < individuo1.Cromosoma.CantidadGenes; indiceGen++)
            {
                if (_generador.Next(0, 100) >= 50)
                {
                    var genPadre = individuo1.Cromosoma.Genes.GetValue(indiceGen) as IGen;
                    hijo1.Cromosoma.Genes.SetValue(genPadre.Clonar(), indiceGen);
                }
                else
                {
                    var genMadre = individuo2.Cromosoma.Genes.GetValue(indiceGen) as IGen;
                    hijo1.Cromosoma.Genes.SetValue(genMadre.Clonar(), indiceGen);
                }
            }

            IIndividuo hijo2 = individuo1.GenerarDescendencia(individuo1);
            for (int indiceGen = 0; indiceGen < individuo1.Cromosoma.CantidadGenes; indiceGen++)
            {
                if (_generador.Next(0, 100) >= 50)
                {
                    var genPadre = individuo1.Cromosoma.Genes.GetValue(indiceGen) as IGen;
                    hijo2.Cromosoma.Genes.SetValue(genPadre.Clonar(), indiceGen);
                }
                else
                {
                    var genMadre = individuo2.Cromosoma.Genes.GetValue(indiceGen) as IGen;
                    hijo2.Cromosoma.Genes.SetValue(genMadre.Clonar(), indiceGen);
                }
            }

            return new Tuple<IIndividuo, IIndividuo>(hijo1, hijo2);
        }
        #endregion
    }
}
