using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.Interfaces
{
    public interface IAlgoritmoGenetico
    {
        IPoblacion Ejecutar(IParametros parametros);
    }
}
