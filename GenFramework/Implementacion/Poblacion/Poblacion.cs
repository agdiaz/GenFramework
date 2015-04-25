using GenFramework.Interfaces;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.Implementacion.Poblacion
{
    public class Poblacion : IPoblacion
    {
        public IList<IIndividuo> PoblacionActual { get; private set; }
        public int NumeroGeneracion { get; set; }

        public Poblacion() : this(0, new List<IIndividuo>()) { }

        public Poblacion(IList<IIndividuo> individuos) :this(0, individuos) { }

        public Poblacion(int numeroGeneracion, IList<IIndividuo> individuos)
        {
            this.NumeroGeneracion = numeroGeneracion;
            this.PoblacionActual = individuos;
        }

        public IIndividuo ObtenerIndividuo()
        {
            var indiceRandom = new Random().Next(0, PoblacionActual.Count - 1);
            return PoblacionActual[indiceRandom];
        }
    }
}
