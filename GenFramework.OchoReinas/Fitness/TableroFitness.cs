using GenFramework.Interfaces.Genetica;
using GenFramework.Interfaces.Poblacion;
using GenFramework.OchoReinas.Genetica;
using GenFramework.OchoReinas.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.OchoReinas.Fitness
{
    public class TableroFitness : IFuncionFitness
    {
        public decimal Evaluar(IIndividuo individuo)
        {
            if (individuo.Genotipo == typeof(IndividuoTablero))
            {
                return this.AnalizarReinas(individuo.Cromosoma);
            }
            else
            {
                return 0;
            }
        }

        private decimal AnalizarReinas(ICromosoma cromosoma)
        {
            decimal reinaVivas = 0;

            Tablero tablero = new Tablero();
            for (int indiceReina = 0; indiceReina < cromosoma.Genes.Length; indiceReina++)
            {
                var genReina = cromosoma.Genes.GetValue(indiceReina) as GenReina;
                var reina = genReina.Valor as Reina;
                
                tablero.AgregarReina(reina);
            }


            reinaVivas = tablero.CalcularReinasVivas().Count;

            return reinaVivas;
        }
    }
}
