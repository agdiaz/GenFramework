using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.Interfaces.Poblacion
{
    public interface IIndividuo 
    {
        ICromosoma Cromosoma { get; }
        Type Genotipo { get;}
        Guid IdentificacionUnica { get; }

        IIndividuo GenerarDescendencia(IIndividuo individuo);
    }
}
