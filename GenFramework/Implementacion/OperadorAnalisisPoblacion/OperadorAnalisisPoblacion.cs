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
        public IIndividuo ObtenerMejorGlobal {get; set;}
        public IIndividuo ObtenerPeorGlobal {get; set;}
        public IIndividuo ObtenerMejorVuelta {get; set;}
        public IIndividuo ObtenerPeorVuelta { get; set; }

        public OperadorAnalisisPoblacion(IParametrosAnalisisPoblacion parametrosAnalisisPoblacion)
        {
            this._parametrosAnalisisPoblacion = parametrosAnalisisPoblacion;
        }
        #endregion

        public void Analizar(IPoblacion poblacion)
        {
            this.ObtenerMejorVuelta = null;
            this.ObtenerPeorVuelta = null;

            foreach (IIndividuo individuo in poblacion.PoblacionActual)
            {
                var fitness = this._parametrosAnalisisPoblacion.Funcion.Evaluar(individuo);

                // Mayores
                if (ObtenerMejorGlobal == null || fitness > this._parametrosAnalisisPoblacion.Funcion.Evaluar(ObtenerMejorGlobal))
                {
                    this.ObtenerMejorGlobal = individuo;
                }
                if (ObtenerMejorVuelta == null || fitness > this._parametrosAnalisisPoblacion.Funcion.Evaluar(ObtenerMejorVuelta))
                {
                    this.ObtenerMejorVuelta = individuo;
                }

                // Menores
                if (ObtenerPeorGlobal == null || fitness < this._parametrosAnalisisPoblacion.Funcion.Evaluar(ObtenerPeorGlobal))
                {
                    this.ObtenerPeorGlobal = individuo;
                }
                if (ObtenerPeorVuelta == null || fitness < this._parametrosAnalisisPoblacion.Funcion.Evaluar(ObtenerPeorVuelta))
                {
                    this.ObtenerPeorVuelta = individuo;
                }

            }
        }
    }
}
