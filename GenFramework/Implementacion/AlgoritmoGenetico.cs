using GenFramework.Eventos;
using GenFramework.Interfaces;
using GenFramework.Interfaces.OperadorAnalisisPoblacion;
using GenFramework.Interfaces.OperadorCorte;
using GenFramework.Interfaces.OperadorCruzamiento;
using GenFramework.Interfaces.OperadorMutacion;
using GenFramework.Interfaces.OperadorSeleccion;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenFramework.Implementacion
{
    public class AlgoritmoGenetico : IAlgoritmoGenetico
    {
        public event IteracionTerminadaEventHandler IteracionTerminada;

        #region Atributos
        private IOperadorSeleccion _operadorSeleccion;
        private IOperadorCruzamiento _operadorCruzamiento;
        private IOperadorMutacion _operadorMutacion;
        private IOperadorCorte _operadorCorte;
        private IOperadorAnalisisPoblacion _operadorAnalisisPoblacion;
        private IPoblacion _poblacion;
        #endregion

        #region Constructor
        public AlgoritmoGenetico(IPoblacion poblacionInicial,
            IOperadorSeleccion _operadorSeleccion, 
            IOperadorCruzamiento _operadorCruzamiento, 
            IOperadorMutacion _operadorMutacion, 
            IOperadorCorte _operadorCorte,
            IOperadorAnalisisPoblacion operadorAnalisisPoblacion)
        {
            this._poblacion = poblacionInicial;
            this._operadorSeleccion = _operadorSeleccion;
            this._operadorCruzamiento = _operadorCruzamiento;
            this._operadorMutacion = _operadorMutacion;
            this._operadorCorte = _operadorCorte;
            this._operadorAnalisisPoblacion = operadorAnalisisPoblacion;
        }
        #endregion

        #region IAlgoritmoGenetico
        public IPoblacion Ejecutar(IParametros parametros)
        {
            do
            {
                // Una nueva generación se procesa:
                this._poblacion.NumeroGeneracion++;

                this._poblacion = this._operadorSeleccion.Seleccionar(this._poblacion);
                this._poblacion = this._operadorCruzamiento.Cruzar(this._poblacion);
                this._poblacion = this._operadorMutacion.Mutar(this._poblacion);

                // Esperar para la siguiente vuelta
                //this._operadorAnalisisPoblacion.Analizar(this._poblacion);
                IteracionTerminada(this, new PoblacionEventArgs(_poblacion));

                Thread.Sleep(parametros.IntervaloPorVuelta);

            } while (!this._operadorCorte.CortarEjecucion(this._poblacion));
            
            return this._poblacion;
        }
        #endregion
    }
}
