using GenFramework.Interfaces.Genetica;
using GenFramework.Interfaces.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.Parametros
{
    public class ParametrosCorte : IParametrosCorte 
    {
        public IFuncionFitness FuncionFitness { get; set; }
        public int UmbralCorte {get; set;}
    }
}
