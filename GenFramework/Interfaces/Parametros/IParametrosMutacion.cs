using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.Interfaces.Parametros
{
    public interface IParametrosMutacion
    {
        int ProbabilidadMutarPoblacion { get; set; }

        int IndiceMutacion { get; set; }
    }
}
