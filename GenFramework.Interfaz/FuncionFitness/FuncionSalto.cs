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
        public int Evaluar(IIndividuo columna)
        {
            if (columna.Genotipo != typeof(IndividuoColumna))
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

        private int ObtenerAlturaSalto(int peso, int alturaParado, int alturaFlexionado)
        {
            var fuerza = 1000;

            var altura = (fuerza / peso) * ((int)(alturaParado / 0.1) - (int)(alturaFlexionado / 0.1));

            return altura;
        }
    }
}
