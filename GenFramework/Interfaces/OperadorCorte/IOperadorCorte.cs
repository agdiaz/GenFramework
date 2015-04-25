using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.Interfaces.OperadorCorte
{
    public interface IOperadorCorte
    {
        bool CortarEjecucion(IPoblacion poblacionMutada);
    }
}
