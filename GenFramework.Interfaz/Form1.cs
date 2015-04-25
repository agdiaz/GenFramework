using GenFramework.Implementacion;
using GenFramework.Implementacion.OperadorCorte;
using GenFramework.Implementacion.OperadorCruzamiento;
using GenFramework.Implementacion.OperadorMutacion;
using GenFramework.Implementacion.OperadorSeleccion;
using GenFramework.Implementacion.Parametros;
using GenFramework.Implementacion.Poblacion;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

            var algoritmo = new AlgoritmoGenetico(poblacionInicial,
                new OperadorSeleccionPorTorneo(new ParametrosSeleccion() { CantidadIndividuosASeleccionar = 2, FuncionFitness = funcionFitness }),
                new OperadorCruzamientoSimple(new ParametrosCruzamiento() { IndiceCorte = 2 }),
                new OperadorMutacionConstante(),
                new OperadorCorteSimple(new ParametrosCorte() { FuncionFitness = funcionFitness, UmbralCorte = 3 }));


            algoritmo.Ejecutar(null);
        
        }
    }
}
