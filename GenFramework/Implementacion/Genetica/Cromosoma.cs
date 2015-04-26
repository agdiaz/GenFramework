using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.Genetica
{
    public class Cromosoma : ICromosoma
    {
        public int CantidadGenes { get; set; }
        public Array Genes { get; private set; }

        #region Constructor
        public Cromosoma(int cantidadGenes)
        {
            this.CantidadGenes = cantidadGenes;
            this.Genes = Array.CreateInstance(typeof(IGen), cantidadGenes);
        }
        public Cromosoma(Array genes)
        {
            this.Genes = genes;
            this.CantidadGenes = genes.Length;
        }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IGen gen in this.Genes)
            {
                sb.AppendFormat("{0}, ", gen.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
