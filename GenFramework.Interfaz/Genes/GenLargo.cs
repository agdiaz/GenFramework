using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaz.Genetica
{
    public class GenLargo : IGen
    {
        public int Largo { get; set; }
        public IComparable Valor { get { return Largo; } }

        public GenLargo(int largo)
        {
            this.Largo = largo;
        }
    }
}
