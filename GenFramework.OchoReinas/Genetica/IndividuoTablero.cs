using GenFramework.Implementacion.Poblacion;
using GenFramework.OchoReinas.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.OchoReinas.Genetica
{
    public class IndividuoTablero : IndividuoBase
    {
        private int cantidadReinas;
        private List<Posicion> posicionesUsadas;

        public IndividuoTablero()
            :base(8)
        {
            this.posicionesUsadas = new List<Posicion>();
            this.Genotipo = typeof(IndividuoTablero);
            this.cantidadReinas = 0;
        }

        public bool AgregarReina(int x, int y)
        {
            if (!posicionesUsadas.Any(p => p.X == x && p.Y == y))
            { 
                this.Cromosoma.Genes.SetValue(new GenReina(x, y, cantidadReinas), cantidadReinas);
                posicionesUsadas.Add(new Posicion(x, y));
                cantidadReinas++;
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
