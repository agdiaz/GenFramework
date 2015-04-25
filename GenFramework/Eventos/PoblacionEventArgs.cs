using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Eventos
{
    public class PoblacionEventArgs : EventArgs
    {
        public PoblacionEventArgs(IPoblacion poblacion)
        {
            this.PoblacionResultante = poblacion;
        }

        public IPoblacion PoblacionResultante { get; set; }
    }
}
