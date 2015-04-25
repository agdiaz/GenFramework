using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.Interfaces.Genetica
{
    public interface IFuncionFitness
    {
        int Evaluar(IIndividuo individuo1);
    }
}
