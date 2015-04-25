using GenFramework.Interfaces.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.Parametros
{
    public class ParametrosSeleccion : IParametrosSeleccion
    {
        public int CantidadIndividuosASeleccionar { get; set; }
        public Interfaces.Genetica.IFuncionFitness FuncionFitness {get; set;}
    }
}
