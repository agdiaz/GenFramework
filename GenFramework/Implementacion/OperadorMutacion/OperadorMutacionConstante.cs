using GenFramework.Interfaces.OperadorMutacion;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.OperadorMutacion
{
    public class OperadorMutacionConstante : IOperadorMutacion
    {
        public IPoblacion Mutar(IPoblacion poblacionCruzada)
        {
            return poblacionCruzada;
        }
    }
}
