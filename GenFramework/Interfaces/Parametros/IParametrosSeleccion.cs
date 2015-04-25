using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaces.Parametros
{
    public interface IParametrosSeleccion
    {
        int CantidadIndividuosASeleccionar { get; set; }

        IFuncionFitness FuncionFitness { get; set; }
    }
}
