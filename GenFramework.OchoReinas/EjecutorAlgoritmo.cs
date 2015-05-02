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
using GenFramework.Interfaces.Genetica;
using GenFramework.Interfaces.OperadorAnalisisPoblacion;
using GenFramework.Interfaces.OperadorCorte;
using GenFramework.Interfaces.OperadorCruzamiento;
using GenFramework.Interfaces.OperadorMutacion;
using GenFramework.Interfaces.OperadorSeleccion;
using GenFramework.Interfaces.Parametros;
using GenFramework.Interfaces.Poblacion;
using GenFramework.OchoReinas.Fitness;
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
        private List<Estadistica.FilaEstadistica> _estadisticas;

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
            IPoblacion poblacionInicial = null;
            poblacionInicial = new Poblacion(this.GenerarPoblacionInicial());
            poblacionInicial.CantidadIndividuos = (int)nudCantidadPoblacion.Value;

            IFuncionFitness funcionFitness = null;
            if (rdbFitnessCasillerosAmenazados.Checked)
                funcionFitness = new SumatoriaAmenazasFitness();
            if (rdbFitnessCasillerosLibres.Checked)
                funcionFitness = new CasillerosSinAmenzasFitness();
            if (rdbFitnessReinasVivas.Checked)
                funcionFitness = new TableroFitness();


            IOperadorSeleccion operadorSeleccion = null;
            var parametrosOperadorSeleccion = new ParametrosSeleccion() 
            { 
                CantidadIndividuosASeleccionar = (int)nudCantidadSeleccionada.Value, 
                FuncionFitness = funcionFitness 
            };
            if (rdbSeleccionTorneo.Checked)
                operadorSeleccion = new OperadorSeleccionPorTorneo(parametrosOperadorSeleccion);
            if (rdbSeleccionRanking.Checked)
                operadorSeleccion = new OperadorSeleccionRanking(parametrosOperadorSeleccion);
            
            IOperadorCruzamiento operadorCruzamiento = null;
            var parametrosOperadorCruzamiento = new ParametrosCruzamiento()
            {
                Mascara = txtMascara.Text,
            };
            if (rdbCruzarAzar.Checked)
                operadorCruzamiento = new OperadorCruzamientoAzar(parametrosOperadorCruzamiento);
            if (rdbMascara.Checked)
                operadorCruzamiento = new OperadorCruzamientoMascara(parametrosOperadorCruzamiento);

            IOperadorMutacion operadorMutacion = null;
            var parametrosMutacion = new ParametrosMutacion()
            {
                ProbabilidadMutarPoblacion = (int)nudProbabilidadMutacion.Value,
                IndiceMutacion = (int)nudIndiceMutacion.Value,
            };
            operadorMutacion = new OperadorMutacionConstante(parametrosMutacion);

            IOperadorCorte operadorCorte = null;
            var parametrosCorte = new ParametrosCorte()
            {
                FuncionFitness = funcionFitness,
                UmbralCorte = (int)nudUmbralCorte.Value,
                LimiteIteraciones = (int)nudLimiteVueltas.Value
            };
            operadorCorte = new OperadorCorteSimple(parametrosCorte);


            this.analisis = new OperadorAnalisisPoblacion(new ParametrosAnalisisPoblacion() { Funcion = funcionFitness, FuncionReinas = new TableroFitness()});
            
            IAlgoritmoGenetico algoritmo = new AlgoritmoGenetico(poblacionInicial, 
                operadorSeleccion,
                operadorCruzamiento,
                operadorMutacion,
                operadorCorte);

            IParametros parametros = new Parametros()
            {
                IntervaloPorVuelta = (int)nudIntervaloVuelta.Value,
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

                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 8), _generadorAleatorio.Next(0, 8)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 8), _generadorAleatorio.Next(0, 8)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 8), _generadorAleatorio.Next(0, 8)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 8), _generadorAleatorio.Next(0, 8)) == false) ;

                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 8), _generadorAleatorio.Next(0, 8)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 8), _generadorAleatorio.Next(0, 8)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 8), _generadorAleatorio.Next(0, 8)) == false) ;
                while (individuo.AgregarReina(_generadorAleatorio.Next(0, 8), _generadorAleatorio.Next(0, 8)) == false) ;
                
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

                this.txtMejorReinas.Text = analisis.MejorReinasGlobal.ToString();
                this.txtPeorReinas.Text = analisis.PeorReinasGlobal.ToString();

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

                var row = dgvEstadisticas.Rows.Add();
                dgvEstadisticas.Rows[row].Cells["NumeroGeneracion"].Value = poblacionResultante.NumeroGeneracion;
                dgvEstadisticas.Rows[row].Cells["FitnessGlobalMaximo"].Value = analisis.MejorFitnessGlobal;
                dgvEstadisticas.Rows[row].Cells["FitnessGlobalMinimo"].Value = analisis.PeorFitnessGlobal;
                dgvEstadisticas.Rows[row].Cells["FitnessLocalMaximo"].Value = analisis.MejorFitnessVuelta;
                dgvEstadisticas.Rows[row].Cells["FitnessLocalMinimo"].Value = analisis.PeorFitnessVuelta;
                dgvEstadisticas.Rows[row].Cells["PorcentajeGlobalExito"].Value = ((analisis.MejorFitnessGlobal * 100) / (decimal)nudUmbralCorte.Value);
                dgvEstadisticas.Rows[row].Cells["PorcentajeLocalExito"].Value = ((analisis.MejorFitnessVuelta * 100) / (decimal)nudUmbralCorte.Value);

            }), null);
        }

        #endregion

        private void EjecutorAlgoritmo_Load(object sender, EventArgs e)
        {
            //this._estadisticas = new List<Estadistica.FilaEstadistica>();
            //this.dataGridView1.DataSource = this._estadisticas;
            this.dgvEstadisticas.Columns.Add("NumeroGeneracion", "Nro. Generación");
            this.dgvEstadisticas.Columns.Add("FitnessGlobalMaximo", "Mejor global");
            this.dgvEstadisticas.Columns.Add("FitnessGlobalMinimo", "Peor global");
            this.dgvEstadisticas.Columns.Add("FitnessLocalMaximo", "Mejor local");
            this.dgvEstadisticas.Columns.Add("FitnessLocalMinimo", "Peor local");
            this.dgvEstadisticas.Columns.Add("PorcentajeGlobalExito", "Porc. éxito global");
            this.dgvEstadisticas.Columns.Add("PorcentajeLocalExito", "Porc. éxito local");

        }
    }
}
