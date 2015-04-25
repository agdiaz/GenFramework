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
        public Poblacion() : this(new List<IIndividuo>()){ }

        public Poblacion(IList<IIndividuo> individuos)
        {
            this.PoblacionActual = individuos;
        }

        public IList<IIndividuo> PoblacionActual { get; private set; }

        public IIndividuo ObtenerIndividuo()
        {
            var indiceRandom = new Random().Next(0, PoblacionActual.Count - 1);
            return PoblacionActual[indiceRandom];
        }
    }
}
