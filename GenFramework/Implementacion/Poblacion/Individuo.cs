using GenFramework.Implementacion.Genetica;
using GenFramework.Interfaces.Genetica;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.Poblacion
{
    public class Individuo : IIndividuo
    {
        public ICromosoma Cromosoma { get; set; }
        public Type Genotipo { get; set; }
        public Individuo(int cantidadGenes)
        {
            this.Cromosoma = new Cromosoma(cantidadGenes);
            this.Genotipo = typeof(Individuo);
        }

        public IIndividuo GenerarDescendencia(IIndividuo individuo)
        {
            var descendiente = new Individuo(individuo.Cromosoma.CantidadGenes);
            descendiente.Genotipo = individuo.Genotipo;

            return descendiente;
        }
    }
}
