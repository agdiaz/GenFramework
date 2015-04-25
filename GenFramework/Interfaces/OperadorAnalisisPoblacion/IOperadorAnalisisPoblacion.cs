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
        IIndividuo ObtenerMejorGlobal {get; }
        IIndividuo ObtenerPeorGlobal {get; }
        IIndividuo ObtenerMejorVuelta {get; }
        IIndividuo ObtenerPeorVuelta {get; }

        void Analizar(IPoblacion poblacion);
    }
}
