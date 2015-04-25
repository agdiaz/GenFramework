﻿using GenFramework.Eventos;
using GenFramework.Implementacion;
using GenFramework.Implementacion.OperadorAnalisisPoblacion;
using GenFramework.Implementacion.OperadorCorte;
using GenFramework.Implementacion.OperadorCruzamiento;
using GenFramework.Implementacion.OperadorMutacion;
using GenFramework.Implementacion.OperadorSeleccion;
using GenFramework.Implementacion.Parametros;
using GenFramework.Implementacion.Poblacion;
using GenFramework.Interfaces;
using GenFramework.Interfaces.OperadorAnalisisPoblacion;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaz.Individuos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenFramework.Interfaz
{
    public partial class EjecutorAlgortimo : Form
    {
        private int _intervaloTimer;
        private IOperadorAnalisisPoblacion analisis;

        #region Constructor
        public EjecutorAlgortimo()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos de los controles
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            var columna1 = new IndividuoColumna(20, 30, 100);
            var columna2 = new IndividuoColumna(100, 2, 20);
            var columna3 = new IndividuoColumna(15, 54, 15);
            var columna4 = new IndividuoColumna(23, 9, 4);

            var poblacionInicial = new Poblacion();
            poblacionInicial.PoblacionActual.Add(columna1);
            poblacionInicial.PoblacionActual.Add(columna1);
            poblacionInicial.PoblacionActual.Add(columna1);
            poblacionInicial.PoblacionActual.Add(columna1);

            var funcionFitness = new FuncionFitness.FuncionSalto();
            analisis = new OperadorAnalisisPoblacion(new ParametrosAnalisisPoblacion() { Funcion = funcionFitness });

            IAlgoritmoGenetico algoritmo = new AlgoritmoGenetico(poblacionInicial,
                new OperadorSeleccionPorTorneo(new ParametrosSeleccion() { CantidadIndividuosASeleccionar = 2, FuncionFitness = funcionFitness }),
                new OperadorCruzamientoSimple(new ParametrosCruzamiento() { IndiceCorte = 2 }),
                new OperadorMutacionConstante(),
                new OperadorCorteSimple(new ParametrosCorte() { FuncionFitness = funcionFitness, UmbralCorte = 3, LimiteIteraciones = (int)nudLimiteVueltas.Value }),
                analisis);

            IParametros parametros = new Parametros()
            {
                IntervaloPorVuelta = _intervaloTimer,
            };

            algoritmo.IteracionTerminada += algoritmo_IteracionTerminada;
            algoritmo.Ejecutar(parametros);
        }

        void algoritmo_IteracionTerminada(object sender, PoblacionEventArgs e)
        {
            analisis.Analizar(e.PoblacionResultante);
            this.txtGlobalMejorIndividuo.Text = analisis.ObtenerMejorGlobal.ToString();
        }
       

        private void nudTiempo_ValueChanged(object sender, EventArgs e)
        {
            this._intervaloTimer = Convert.ToInt32(nudTiempo.Value) * 1000;
        }
        #endregion
    }
}
