using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.OchoReinas.LogicaNegocio
{
    public class Reina
    {
        public int NumeroReina { get; set; }
        public Posicion Posicion { get; set; }

        public Reina(int x, int y, int reina)
        {
            this.Posicion = new Posicion(x, y);
            this.NumeroReina = reina;
        }

        public override string ToString()
        {
            return string.Format("Reina {0} ({1},{2})", NumeroReina, Posicion.X, Posicion.Y);
        }


    }
}
