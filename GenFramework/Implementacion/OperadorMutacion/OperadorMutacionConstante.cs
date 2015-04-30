using GenFramework.Interfaces.OperadorMutacion;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Genetica;

namespace GenFramework.Implementacion.OperadorMutacion
{
    public class OperadorMutacionConstante : IOperadorMutacion
    {
        private IParametrosMutacion _parametrosMutacion;
        private Random _generador;

        public OperadorMutacionConstante(IParametrosMutacion parametrosMutacion)
        {
            this._parametrosMutacion = parametrosMutacion;
            _generador = new Random();
        }

        public IPoblacion Mutar(IPoblacion poblacionCruzada)
        {
            var probabilidad = _generador.Next(0, 100);
            
            if (probabilidad  >= _parametrosMutacion.ProbabilidadMutarPoblacion)
            {
                var individuo = poblacionCruzada.ObtenerIndividuo();
                this.MutarIndividuo(individuo);
            }

            return poblacionCruzada;
        }

        private void MutarIndividuo(IIndividuo individuo)
        {
            var indiceGen = new Random((int)DateTime.Now.Ticks).Next(0, individuo.Cromosoma.CantidadGenes -1);

            var genMutado = individuo.Cromosoma.Genes.GetValue(indiceGen) as IGen;
            genMutado.Mutar(_parametrosMutacion.IndiceMutacion);
        }
    }
}
