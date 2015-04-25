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
        public int Peso { get; set; }
        public IComparable Valor { get { return Peso; } }

        public GenPeso(int peso)
        {
            this.Peso = peso;
        }
    }
}
