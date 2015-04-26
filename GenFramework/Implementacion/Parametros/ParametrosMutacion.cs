using GenFramework.Interfaces.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.Parametros
{
    public class ParametrosMutacion : IParametrosMutacion
    {
        public int ProbabilidadMutarPoblacion { get; set; }
        public int IndiceMutacion {get; set;}
    }
}
