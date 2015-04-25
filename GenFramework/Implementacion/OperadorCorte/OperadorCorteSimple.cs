using GenFramework.Interfaces.OperadorCorte;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.OperadorCorte
{
    public class OperadorCorteSimple : IOperadorCorte
    {
        private IParametrosCorte _parametrosCorte;

        public OperadorCorteSimple(IParametrosCorte parametrosCorte)
        {
            this._parametrosCorte = parametrosCorte;
        }
        
        public bool CortarEjecucion(IPoblacion poblacionMutada)
        {
            bool cortar = false;

            for (int indiceIndividuo = 0; 
                !cortar && 
                poblacionMutada.NumeroGeneracion <= _parametrosCorte.LimiteIteraciones && 
                indiceIndividuo < poblacionMutada.PoblacionActual.Count; 
                indiceIndividuo++)
            {
                var individuo = poblacionMutada.PoblacionActual[indiceIndividuo];

                var valorFitness = _parametrosCorte.FuncionFitness.Evaluar(individuo);

                cortar = valorFitness >= _parametrosCorte.UmbralCorte;
            }

            return cortar;
        }
    }
}
