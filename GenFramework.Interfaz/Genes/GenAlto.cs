using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaz.Genetica
{
    public class GenAlto : IGen
    {
        public decimal Alto { get; set; }
        public IComparable Valor { get { return Alto; } }

        public GenAlto(decimal alto)
        {
            this.Alto = alto;
        }
    }
}
