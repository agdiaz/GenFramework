using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.Interfaces.OperadorCruzamiento
{
    public interface IOperadorCruzamiento
    {
        IPoblacion Cruzar(IPoblacion poblacionSeleccionada);
    }
}
