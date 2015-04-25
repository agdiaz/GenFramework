using GenFramework.Interfaces;
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
using System.Threading.Tasks;

namespace GenFramework.Implementacion
{
    public class AlgoritmoGenetico : IAlgoritmoGenetico
    {
        private IOperadorSeleccion _operadorSeleccion;
        private IOperadorCruzamiento _operadorCruzamiento;
        private IOperadorMutacion _operadorMutacion;
        private IOperadorCorte _operadorCorte;
        private IPoblacion _poblacion;

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

        #region IAlgoritmoGenetico
        public IPoblacion Ejecutar(IParametros parametros)
        {
            do
            {
                this._poblacion = this._operadorSeleccion.Seleccionar(this._poblacion);
                this._poblacion = this._operadorCruzamiento.Cruzar(this._poblacion);
                this._poblacion = this._operadorMutacion.Mutar(this._poblacion);
    
            } while (!this._operadorCorte.CortarEjecucion(this._poblacion));
            
            return this._poblacion;
        }
        #endregion
    }
}
