using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaces.OperadorAnalisisPoblacion
{
    public interface IOperadorAnalisisPoblacion
    {
        IIndividuo MejorIndividuoGlobal {get; }
        IIndividuo PeorIndividuoGlobal {get; }
        IIndividuo MejorIndividuoVuelta {get; }
        IIndividuo PeorIndividuoVuelta {get; }

        decimal MejorFitnessGlobal { get; }
        decimal PeorFitnessGlobal { get; }
        decimal MejorFitnessVuelta { get; }
        decimal PeorFitnessVuelta { get; }

        void Analizar(IPoblacion poblacion);
    }
}
