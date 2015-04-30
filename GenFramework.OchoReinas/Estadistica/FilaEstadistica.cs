using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.OchoReinas.Estadistica
{
    public class FilaEstadistica
    {
        public int NumeroGeneracion { get; set; }
        public decimal FitnessGlobalMinimo { get; set; }
        public decimal FitnessGlobalMaximo { get; set; }
        public decimal FitnessLocalMinimo { get; set; }
        public decimal FitnessLocalMaximo { get; set; }
        public decimal PorcentajeGlobalExito { get; set; }
    }
}
