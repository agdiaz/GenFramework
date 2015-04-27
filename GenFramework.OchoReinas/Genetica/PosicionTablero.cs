using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.OchoReinas.Genetica
{
    public class PosicionTablero
    {
        public int PosicionX { get; set; }
        public int PosicionY { get; set; }

        public PosicionTablero(int posicionX, int posicionY)
        {
            this.PosicionX = posicionX;
            this.PosicionY = posicionY;
        }
    }
}
