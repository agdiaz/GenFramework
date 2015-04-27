using GenFramework.Interfaces.Genetica;
using GenFramework.Interfaces.Poblacion;
using GenFramework.OchoReinas.Genetica;
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
            
            var reina1 = cromosoma.Genes.GetValue(0) as GenReina;
            var reina2 = cromosoma.Genes.GetValue(1) as GenReina;
            var reina3 = cromosoma.Genes.GetValue(2) as GenReina;
            var reina4 = cromosoma.Genes.GetValue(3) as GenReina;
            var reina5 = cromosoma.Genes.GetValue(4) as GenReina;
            var reina6 = cromosoma.Genes.GetValue(5) as GenReina;
            var reina7 = cromosoma.Genes.GetValue(6) as GenReina;
            var reina8 = cromosoma.Genes.GetValue(7) as GenReina;

            AnalizadorTablero analizador = new AnalizadorTablero(
                (PosicionTablero)reina1.Valor, (PosicionTablero)reina2.Valor, (PosicionTablero)reina3.Valor, (PosicionTablero)reina4.Valor,
                (PosicionTablero)reina5.Valor, (PosicionTablero)reina6.Valor, (PosicionTablero)reina7.Valor, (PosicionTablero)reina8.Valor);

            return reinaVivas;
        }
    }
}
