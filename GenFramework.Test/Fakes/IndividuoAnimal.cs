using GenFramework.Implementacion.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Test.Fakes
{
    public class IndividuoAnimal : IndividuoBase
    {
        public IndividuoAnimal()
            :base(16)
        {
            this.Genotipo = typeof(IndividuoAnimal);
        }
    }
}
