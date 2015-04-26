using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaces.Parametros
{
    public interface IParametrosCorte
    {
        IFuncionFitness FuncionFitness { get; }
        decimal UmbralCorte { get; }
        int LimiteIteraciones { get; }
    }
}
