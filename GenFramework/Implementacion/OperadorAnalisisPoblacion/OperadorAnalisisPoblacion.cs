using GenFramework.Interfaces.OperadorAnalisisPoblacion;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.OperadorAnalisisPoblacion
{
    public class OperadorAnalisisPoblacion : IOperadorAnalisisPoblacion
    {

        #region Constructor
        private IParametrosAnalisisPoblacion _parametrosAnalisisPoblacion;

        public IIndividuo MejorIndividuoGlobal {get; private set;}
        public IIndividuo PeorIndividuoGlobal {get; private set;}
        public IIndividuo MejorIndividuoVuelta {get; private set;}
        public IIndividuo PeorIndividuoVuelta { get; private set; }

        public decimal MejorReinasGlobal { get; private set; }
        public decimal PeorReinasGlobal { get; private set; }
        public decimal MejorFitnessGlobal { get; private set; }
        public decimal PeorFitnessGlobal { get; private set; }
        public decimal MejorFitnessVuelta { get; private set; }
        public decimal PeorFitnessVuelta { get; private set; }

        public OperadorAnalisisPoblacion(IParametrosAnalisisPoblacion parametrosAnalisisPoblacion)
        {
            this._parametrosAnalisisPoblacion = parametrosAnalisisPoblacion;
        }
        #endregion

        public void Analizar(IPoblacion poblacion)
        {
            this.MejorIndividuoVuelta = null;
            this.PeorIndividuoVuelta = null;
            this.MejorFitnessVuelta = Int32.MinValue;
            this.PeorFitnessVuelta = Int32.MinValue;

            foreach (IIndividuo individuo in poblacion.PoblacionActual)
            {
                var fitness = this._parametrosAnalisisPoblacion.Funcion.Evaluar(individuo);

                // Mayores
                if (MejorIndividuoGlobal == null || fitness > MejorFitnessGlobal)
                {
                    this.MejorIndividuoGlobal = individuo;
                    this.MejorFitnessGlobal = fitness;
                    this.MejorReinasGlobal = this._parametrosAnalisisPoblacion.FuncionReinas.Evaluar(individuo); ;
                }
                if (MejorIndividuoVuelta == null || fitness > MejorFitnessVuelta)
                {
                    this.MejorIndividuoVuelta = individuo;
                    this.MejorFitnessVuelta = fitness;
                    this.MejorReinasGlobal = this._parametrosAnalisisPoblacion.FuncionReinas.Evaluar(individuo); ;
                }

                // Menores
                if (PeorIndividuoGlobal == null || fitness < PeorFitnessGlobal)
                {
                    this.PeorIndividuoGlobal = individuo;
                    this.PeorFitnessGlobal = fitness;
                    this.PeorReinasGlobal = this._parametrosAnalisisPoblacion.FuncionReinas.Evaluar(individuo); ;
                }
                if (PeorIndividuoVuelta == null || fitness < PeorFitnessVuelta)
                {
                    this.PeorIndividuoVuelta = individuo;
                    this.PeorFitnessVuelta = fitness;
                    this.PeorReinasGlobal = this._parametrosAnalisisPoblacion.FuncionReinas.Evaluar(individuo); ;
                }

            }
        }
    }
}
