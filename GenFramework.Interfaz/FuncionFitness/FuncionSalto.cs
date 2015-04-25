using GenFramework.Interfaces.Genetica;
using GenFramework.Interfaces.Poblacion;
using GenFramework.Interfaz.Individuos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaz.FuncionFitness
{
    public class FuncionSalto : IFuncionFitness
    {
        public int Evaluar(IIndividuo individuo1)
        {
            var columna = individuo1 as IndividuoColumna;
            if (columna == null)
            {
                return 0;
            }
            else
            {
                var alto = (int)((IGen)columna.Cromosoma.Genes.GetValue(0)).Valor;
                var largo = (int)((IGen)columna.Cromosoma.Genes.GetValue(1)).Valor;
                var peso = (int)((IGen)columna.Cromosoma.Genes.GetValue(2)).Valor;

                return (alto + largo) * 1 / peso;
            }
        }
    }
}
