using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.Genetica
{
    public abstract class GenBase : IGen
    {
        public string Nombre { get; protected set; }
        public object Valor {get; protected set;}

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Nombre, this.Valor.ToString());
        }


        public abstract void Mutar(int indiceMutacion);

        protected GenBase()
        {

        }

        public abstract IGen Clonar();
    }
}
