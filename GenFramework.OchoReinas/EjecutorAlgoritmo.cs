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
using GenFramework.OchoReinas.Genetica;
using GenFramework.OchoReinas.LogicaNegocio;
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

namespace GenFramework.OchoReinas
{
    public partial class EjecutorAlgoritmo : Form
    {
        private Random _generadorAleatorio;
        private IOperadorAnalisisPoblacion analisis;
        private BackgroundWorker _backgroundWorker;
        private SynchronizationContext context;

        public EjecutorAlgoritmo()
        {
            this._generadorAleatorio = new Random();
            this._backgroundWorker = new BackgroundWorker();
            this._backgroundWorker.DoWork += _backgroundWorker_DoWork;
            this._backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            this.context = SynchronizationContext.Current;
            if (context == null)
            {
                context = new SynchronizationContext();
            };

            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            _backgroundWorker.RunWorkerAsync();
            this.btnIniciar.Enabled = false;
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var poblacionInicial = new Poblacion(this.GenerarPoblacionInicial());
            poblacionInicial.CantidadIndividuos = (int)nudCantidadPoblacion.Value;
            var funcionFitness = new Fitness.TableroFitness();

            this.analisis = new OperadorAnalisisPoblacion(new ParametrosAnalisisPoblacion() { Funcion = funcionFitness });
            

            var analisis = new OperadorAnalisisPoblacion(new ParametrosAnalisisPoblacion() { Funcion = funcionFitness });

            IAlgoritmoGenetico algoritmo = new AlgoritmoGenetico(poblacionInicial,
                new OperadorSeleccionRanking(new ParametrosSeleccion() { CantidadIndividuosASeleccionar = (int)nudCantidadSeleccionada.Value, FuncionFitness = funcionFitness }),
                new OperadorCruzamientoSimple(new ParametrosCruzamiento() { IndiceCorte = (int)nudCruzar.Value }),
                new OperadorMutacionConstante(new ParametrosMutacion() { IndiceMutacion = 1, ProbabilidadMutarPoblacion = 50 }),
                new OperadorCorteSimple(new ParametrosCorte() { FuncionFitness = funcionFitness, UmbralCorte = 8, LimiteIteraciones = (int)nudLimiteVueltas.Value }));

            IParametros parametros = new Parametros()
            {
                IntervaloPorVuelta = 1,
            };

            algoritmo.IteracionTerminada += algoritmo_IteracionTerminada;

            var poblacionFinal = algoritmo.Ejecutar(parametros);
            this.AnalizarPoblacion(poblacionFinal);
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Fin de la ejecución");
            this.btnIniciar.Enabled = true;
        }

        private List<IIndividuo> GenerarPoblacionInicial()
        {
            var individuos = new List<IIndividuo>();
            for (int i = 0; i < (int)nudCantidadPoblacion.Value; i++)
            {
                var individuo = new IndividuoTablero();

                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 7), _generadorAleatorio.Next(0, 7)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 7), _generadorAleatorio.Next(0, 7)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 7), _generadorAleatorio.Next(0, 7)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 7), _generadorAleatorio.Next(0, 7)) == false) ;

                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 7), _generadorAleatorio.Next(0, 7)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 7), _generadorAleatorio.Next(0, 7)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 7), _generadorAleatorio.Next(0, 7)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 7), _generadorAleatorio.Next(0, 7)) == false) ;
                
                individuos.Add(individuo);
            }
            return individuos;
        }

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
                this.txtMejor.Text = analisis.MejorFitnessGlobal.ToString();
                this.txtPeor.Text = analisis.PeorFitnessGlobal.ToString();
                this.txtGeneracion.Text = poblacionResultante.NumeroGeneracion.ToString();

                var reinasMejor = analisis.MejorIndividuoGlobal.Cromosoma.Genes;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        var controlReina = tlpTableroMejor.GetControlFromPosition(i, j);

                        controlReina.BackColor = Color.White; ;
                        controlReina.Text = string.Empty ;
                    }
                }

                foreach (GenReina genReina in reinasMejor)
                {
                    var reina = genReina.Valor as Reina;
                    var controlReina = tlpTableroMejor.GetControlFromPosition(reina.Posicion.X, reina.Posicion.Y);

                    if (controlReina.BackColor == Color.White)
                    { 
                        controlReina.BackColor = Color.Red;
                    }
                    else
                    {
                        controlReina.BackColor = Color.Orange;
                    }
                }

                //this.txtNumeroGeneracion.Text = poblacionResultante.NumeroGeneracion.ToString();

                //this.txtGlobalMejorIndividuo.Text = analisis.MejorFitnessGlobal.ToString();
                //this.txtGlobalMejorIndividuoId.Text = analisis.MejorIndividuoGlobal.IdentificacionUnica.ToString();
                //this.txtGlobalMejorIndividuoGen.Text = analisis.MejorIndividuoGlobal.ToString();


                //this.txtGlobalPeorIndividuo.Text = analisis.PeorFitnessGlobal.ToString();
                //this.txtGlobalPeorIndividuoId.Text = analisis.PeorIndividuoGlobal.IdentificacionUnica.ToString();
                //this.txtGlobalPeorIndividuoGen.Text = analisis.PeorIndividuoGlobal.ToString();


                //this.txtVueltaMejorIndividuo.Text = analisis.MejorFitnessVuelta.ToString();
                //this.txtVueltaMejorIndividuoId.Text = analisis.MejorIndividuoVuelta.IdentificacionUnica.ToString();
                //this.txtVueltaMejorIndividuoGen.Text = analisis.MejorIndividuoVuelta.ToString();

                //this.txtVueltaPeorIndividuo.Text = analisis.PeorFitnessVuelta.ToString();
                //this.txtVueltaPeorIndividuoId.Text = analisis.PeorIndividuoVuelta.IdentificacionUnica.ToString();
                //this.txtVueltaPeorIndividuoGen.Text = analisis.PeorIndividuoVuelta.ToString();


            }), null);
        }

        #endregion
    }
}
