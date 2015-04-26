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
    public class IndividuoBase : IIndividuo
    {
        public ICromosoma Cromosoma { get; protected set; }
        public Type Genotipo { get; protected set; }
        public Guid IdentificacionUnica { get; protected set; }

        public IndividuoBase(int cantidadGenes)
        {
            this.Cromosoma = new Cromosoma(cantidadGenes);
            this.Genotipo = typeof(IndividuoBase);
            this.IdentificacionUnica = Guid.NewGuid();
        }

        public IIndividuo GenerarDescendencia(IIndividuo individuo)
        {
            var descendiente = new IndividuoBase(individuo.Cromosoma.CantidadGenes);
            descendiente.Genotipo = individuo.Genotipo;

            return descendiente;
        }

        public override string ToString()
        {
            return this.Cromosoma.ToString();
        }
    }
}
