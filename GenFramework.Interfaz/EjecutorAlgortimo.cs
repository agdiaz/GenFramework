using GenFramework.Eventos;
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
using GenFramework.Interfaces.Poblacion;
using GenFramework.Interfaz.Individuos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenFramework.Interfaz
{
    public partial class EjecutorAlgortimo : Form
    {
        private int _intervaloTimer;
        private IOperadorAnalisisPoblacion analisis;
        private BackgroundWorker _backgroundWorker;
        private SynchronizationContext context;

        #region Constructor
        public EjecutorAlgortimo()
        {
            InitializeComponent();
            this._intervaloTimer = Convert.ToInt32(nudTiempo.Value) * 1000;
            this._backgroundWorker = new BackgroundWorker();
            this._backgroundWorker.DoWork += _backgroundWorker_DoWork;
            this._backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            context = SynchronizationContext.Current;
            if (context == null)
            {
                context = new SynchronizationContext();
            };
        }

        void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Fin de la ejecución");
        }
        #endregion

        #region Eventos de los controles
        

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            this._backgroundWorker.RunWorkerAsync();
        }

        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var poblacionInicial = this.GenerarPoblacion();

            var funcionFitness = new FuncionFitness.FuncionSalto();
            analisis = new OperadorAnalisisPoblacion(new ParametrosAnalisisPoblacion() { Funcion = funcionFitness });

            IAlgoritmoGenetico algoritmo = new AlgoritmoGenetico(poblacionInicial,
                new OperadorSeleccionPorTorneo(new ParametrosSeleccion() { CantidadIndividuosASeleccionar = poblacionInicial.PoblacionActual.Count, FuncionFitness = funcionFitness }),
                new OperadorCruzamientoSimple(new ParametrosCruzamiento() { IndiceCorte = 2 }),
                new OperadorMutacionConstante(),
                new OperadorCorteSimple(new ParametrosCorte() { FuncionFitness = funcionFitness, UmbralCorte = 3, LimiteIteraciones = (int)nudLimiteVueltas.Value }));

            IParametros parametros = new Parametros()
            {
                IntervaloPorVuelta = _intervaloTimer,
            };

            algoritmo.IteracionTerminada += algoritmo_IteracionTerminada;
            
            var poblacionFinal = algoritmo.Ejecutar(parametros);
            this.AnalizarPoblacion(poblacionFinal);
        }

        private IPoblacion GenerarPoblacion()
        {
            var columna1 = new IndividuoColumna(20, 30, 100);
            var columna2 = new IndividuoColumna(100, 2, 20);
            var columna3 = new IndividuoColumna(15, 54, 15);
            var columna4 = new IndividuoColumna(150, 10, 400);
            var columna5 = new IndividuoColumna(250, 98, 124);
            var columna6 = new IndividuoColumna(200, 9, 564);
            var columna7 = new IndividuoColumna(15, 9, 424);
            var columna8 = new IndividuoColumna(10, 9, 124);
            var columna9 = new IndividuoColumna(65, 9, 4);
            var columna10 = new IndividuoColumna(100, 10, 40);

            var poblacionInicial = new Poblacion();
            poblacionInicial.PoblacionActual.Add(columna1);
            poblacionInicial.PoblacionActual.Add(columna2);
            poblacionInicial.PoblacionActual.Add(columna3);
            poblacionInicial.PoblacionActual.Add(columna4);
            poblacionInicial.PoblacionActual.Add(columna5);
            poblacionInicial.PoblacionActual.Add(columna6);
            poblacionInicial.PoblacionActual.Add(columna7);
            poblacionInicial.PoblacionActual.Add(columna8);
            poblacionInicial.PoblacionActual.Add(columna9);
            poblacionInicial.PoblacionActual.Add(columna10);

            return poblacionInicial;
        }

        void algoritmo_IteracionTerminada(object sender, PoblacionEventArgs e)
        {
            AnalizarPoblacion(e.PoblacionResultante);
        }

        private void AnalizarPoblacion(IPoblacion poblacionResultante)
        {
            analisis.Analizar(poblacionResultante);
            context.Send(new SendOrPostCallback((s) =>
            {
                this.txtNumeroGeneracion.Text = poblacionResultante.NumeroGeneracion.ToString();

                this.txtGlobalMejorIndividuo.Text = analisis.MejorFitnessGlobal.ToString();
                this.txtGlobalPeorIndividuo.Text = analisis.PeorFitnessGlobal.ToString();

                this.txtVueltaMejorIndividuo.Text = analisis.MejorFitnessVuelta.ToString();
                this.txtVueltaPeorIndividuo.Text = analisis.PeorFitnessVuelta.ToString();

            }), null);
        }

        private void nudTiempo_ValueChanged(object sender, EventArgs e)
        {
            this._intervaloTimer = Convert.ToInt32(nudTiempo.Value) * 1000;
        }
        #endregion
    }
}
