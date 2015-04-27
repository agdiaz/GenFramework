using GenFramework.Implementacion.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.OchoReinas.Genetica
{
    public class IndividuoTablero : IndividuoBase
    {
        public IndividuoTablero()
            :base(8)
        {
            this.Genotipo = typeof(IndividuoTablero);
        }
    }
}
