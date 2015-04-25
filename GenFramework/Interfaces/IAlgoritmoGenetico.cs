using GenFramework.Eventos;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.Interfaces
{
    public delegate void IteracionTerminadaEventHandler(IAlgoritmoGenetico sender, PoblacionEventArgs e);

    public interface IAlgoritmoGenetico
    {
        IPoblacion Ejecutar(IParametros parametros);
        event IteracionTerminadaEventHandler IteracionTerminada;
    }
}
