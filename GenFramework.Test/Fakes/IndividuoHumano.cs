using GenFramework.Implementacion.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Test.Fakes
{
    public class IndividuoHumano : Individuo
    {
        public IndividuoHumano()
            :base(64)
        {
            this.Genotipo = typeof(IndividuoHumano);
        }
    }
}
