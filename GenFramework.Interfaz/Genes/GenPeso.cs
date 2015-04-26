using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaz.Genetica
{
    public class GenPeso : IGen
    {
        public decimal Peso { get; set; }
        public IComparable Valor { get { return Peso; } }

        public GenPeso(decimal peso)
        {
            this.Peso = peso;
        }
    }
}
