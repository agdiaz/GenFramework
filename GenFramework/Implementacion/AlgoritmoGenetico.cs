using GenFramework.Eventos;
using GenFramework.Interfaces;
using GenFramework.Interfaces.OperadorCorte;
using GenFramework.Interfaces.OperadorCruzamiento;
using GenFramework.Interfaces.OperadorMutacion;
using GenFramework.Interfaces.OperadorSeleccion;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Poblacion;
using System;
using System.Threading;

namespace GenFramework.Implementacion
{
    public class AlgoritmoGenetico : IAlgoritmoGenetico
    {
        #region Eventos
        public event IteracionTerminadaEventHandler IteracionTerminada;
        #endregion

        #region Atributos
        private IOperadorSeleccion _operadorSeleccion;
        private IOperadorCruzamiento _operadorCruzamiento;
        private IOperadorMutacion _operadorMutacion;
        private IOperadorCorte _operadorCorte;
        private IPoblacion _poblacion;
        #endregion

        #region Constructor
        public AlgoritmoGenetico(IPoblacion poblacionInicial,
            IOperadorSeleccion _operadorSeleccion, 
            IOperadorCruzamiento _operadorCruzamiento, 
            IOperadorMutacion _operadorMutacion, 
            IOperadorCorte _operadorCorte)
        {
            this._poblacion = poblacionInicial;
            this._operadorSeleccion = _operadorSeleccion;
            this._operadorCruzamiento = _operadorCruzamiento;
            this._operadorMutacion = _operadorMutacion;
            this._operadorCorte = _operadorCorte;
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

                IteracionTerminada(this, new PoblacionEventArgs(_poblacion));


                // Esperar para la siguiente vuelta
                Thread.Sleep(parametros.IntervaloPorVuelta);

            } while (!this._operadorCorte.CortarEjecucion(this._poblacion));
            
            return this._poblacion;
        }
        #endregion
    }
}
