﻿using GenFramework.Interfaces;
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
    public class OperadorCruzamientoMascara : IOperadorCruzamiento
    {
        private IParametrosCruzamiento _parametrosCruzamiento;

        public OperadorCruzamientoMascara(IParametrosCruzamiento _parametrosCruzamientoSimple)
        {
            this._parametrosCruzamiento = _parametrosCruzamientoSimple;
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
            IIndividuo hijo2 = individuo1.GenerarDescendencia(individuo1);

            for (int indiceGen = 0; indiceGen <= _parametrosCruzamiento.Mascara.Length - 1; indiceGen++)
            {
                if (_parametrosCruzamiento.Mascara[indiceGen] == 'P')
                { 
                    var genPadre = individuo1.Cromosoma.Genes.GetValue(indiceGen) as IGen;
                    hijo1.Cromosoma.Genes.SetValue(genPadre.Clonar(), indiceGen);

                    var genMadre = individuo1.Cromosoma.Genes.GetValue(indiceGen) as IGen;
                    hijo2.Cromosoma.Genes.SetValue(genMadre.Clonar(), indiceGen);

                }
                else
                {
                    var genMadre = individuo1.Cromosoma.Genes.GetValue(indiceGen) as IGen;
                    hijo1.Cromosoma.Genes.SetValue(genMadre.Clonar(), indiceGen);
                    
                    var genPadre = individuo1.Cromosoma.Genes.GetValue(indiceGen) as IGen;
                    hijo2.Cromosoma.Genes.SetValue(genPadre.Clonar(), indiceGen);
                }
                
            }

            return new Tuple<IIndividuo, IIndividuo>(hijo1, hijo2);
        }
        #endregion
    }
}
