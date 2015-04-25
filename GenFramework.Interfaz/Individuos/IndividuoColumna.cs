using GenFramework.Implementacion.Poblacion;
using GenFramework.Interfaz.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaz.Individuos
{
    public class IndividuoColumna : Individuo
    {
        public IndividuoColumna()
            :this(0, 0, 1)
        {
            
        }

        public IndividuoColumna(int alto, int largo, int peso)
            : base(3)
        {
            base.Cromosoma.Genes.SetValue(new GenAlto(alto), 0);
            base.Cromosoma.Genes.SetValue(new GenLargo(largo), 1);
            base.Cromosoma.Genes.SetValue(new GenPeso(peso), 2);
        }
    }
}
