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
            this._intervaloTimer = 100;
            this._backgroundWorker = new BackgroundWorker();
            this._backgroundWorker.DoWork += _backgroundWorker_DoWork;
            this._backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            context = SynchronizationContext.Current;
            if (context == null)
            {
                context = new SynchronizationContext();
            };
        }

        
        #endregion

        #region Eventos de los controles
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            this.btnEjecutar.Enabled = false;
            this._backgroundWorker.RunWorkerAsync();
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var poblacionInicial = this.GenerarPoblacion();

            var funcionFitness = new FuncionFitness.FuncionSalto();
            analisis = new OperadorAnalisisPoblacion(new ParametrosAnalisisPoblacion() { Funcion = funcionFitness });

            IAlgoritmoGenetico algoritmo = new AlgoritmoGenetico(poblacionInicial,
                new OperadorSeleccionPorTorneo(new ParametrosSeleccion() { CantidadIndividuosASeleccionar = (int)nudSeleccionar.Value, FuncionFitness = funcionFitness }),
                new OperadorCruzamientoSimple(new ParametrosCruzamiento() { IndiceCorte = 1 }),
                new OperadorMutacionConstante(new ParametrosMutacion() { IndiceMutacion = 5, ProbabilidadMutarPoblacion = 50}),
                new OperadorCorteSimple(new ParametrosCorte() { FuncionFitness = funcionFitness, UmbralCorte = (int)nudAltura.Value, LimiteIteraciones = (int)nudLimiteVueltas.Value }));

            IParametros parametros = new Parametros()
            {
                IntervaloPorVuelta = _intervaloTimer,
            };

            algoritmo.IteracionTerminada += algoritmo_IteracionTerminada;
            
            var poblacionFinal = algoritmo.Ejecutar(parametros);
            this.AnalizarPoblacion(poblacionFinal);
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Fin de la ejecución");
            this.btnEjecutar.Enabled = true;
        }
        
        private IPoblacion GenerarPoblacion()
        {
            var poblacionInicial = new Poblacion();
            poblacionInicial.CantidadIndividuos = (int)nudPoblacionInicial.Value;

            var generadorRandom = new Random();
            for (int indiceIndividuos = 0; indiceIndividuos < (int)nudPoblacionInicial.Value; indiceIndividuos++)
            {

                var alto = generadorRandom.Next((int)nudAlturaMin.Value, (int)nudAlturaMax.Value);
                var largo = generadorRandom.Next((int)nudLargoMin.Value, (int)nudLargoMax.Value);
                var peso = generadorRandom.Next((int)nudPesoMinimo.Value, (int)nudPesoMaximo.Value);

                var individuo = new IndividuoColumna(alto, largo, peso);
                poblacionInicial.PoblacionActual.Add(individuo);
            }
            


            return poblacionInicial;
        }

        private void nudTiempo_ValueChanged(object sender, EventArgs e)
        {
            this._intervaloTimer = Convert.ToInt32(nudTiempo.Value) * 1000;
        }
        #endregion

        #region Eventos del AlgoritmoGenetico
        private void algoritmo_IteracionTerminada(object sender, PoblacionEventArgs e)
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
                this.txtGlobalMejorIndividuoId.Text = analisis.MejorIndividuoGlobal.IdentificacionUnica.ToString();
                this.txtGlobalMejorIndividuoGen.Text = analisis.MejorIndividuoGlobal.ToString();


                this.txtGlobalPeorIndividuo.Text = analisis.PeorFitnessGlobal.ToString();
                this.txtGlobalPeorIndividuoId.Text = analisis.PeorIndividuoGlobal.IdentificacionUnica.ToString();
                this.txtGlobalPeorIndividuoGen.Text = analisis.PeorIndividuoGlobal.ToString();


                this.txtVueltaMejorIndividuo.Text = analisis.MejorFitnessVuelta.ToString();
                this.txtVueltaMejorIndividuoId.Text = analisis.MejorIndividuoVuelta.IdentificacionUnica.ToString();
                this.txtVueltaMejorIndividuoGen.Text = analisis.MejorIndividuoVuelta.ToString();

                this.txtVueltaPeorIndividuo.Text = analisis.PeorFitnessVuelta.ToString();
                this.txtVueltaPeorIndividuoId.Text = analisis.PeorIndividuoVuelta.IdentificacionUnica.ToString();
                this.txtVueltaPeorIndividuoGen.Text = analisis.PeorIndividuoVuelta.ToString();


            }), null);
        }

        #endregion
    }
}
