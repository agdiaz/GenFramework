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
        public int NumeroReina { get; set; }

        public PosicionTablero(int posicionX, int posicionY)
        {
            this.PosicionX = posicionX;
            this.PosicionY = posicionY;
            this.NumeroReina = -1;
        }

        public PosicionTablero(int posicionX, int posicionY, int numeroReina)
        {
            this.PosicionX = posicionX;
            this.PosicionY = posicionY;
            this.NumeroReina = numeroReina;
        }

        public List<PosicionTablero> PosicionesProhibidas()
        {
            var posicionProhibidas = new List<PosicionTablero>();

            for (int indiceHorizontal = 0; indiceHorizontal < 8; indiceHorizontal++)
            {
                for (int indiceVertical = 0; indiceVertical < 8; indiceVertical++)
                {
                    if ((indiceHorizontal == this.PosicionX) || (indiceVertical == this.PosicionY))
                    {
                        var prohibida = new PosicionTablero(indiceHorizontal, indiceVertical);
                        if (this.PosicionX == prohibida.PosicionX && this.PosicionY == prohibida.PosicionY)
                        {
                            prohibida.NumeroReina = this.NumeroReina;
                        }

                        posicionProhibidas.Add(prohibida);
                    }
                }
            }

            return posicionProhibidas;
        }

        public override bool Equals(object obj)
        {
            var otraPosicion = obj as PosicionTablero;
            if (otraPosicion == null)
            {
                return false;
            }
            else
            {
                return (this.PosicionX == otraPosicion.PosicionX 
                    && this.PosicionY == otraPosicion.PosicionY
                    && this.NumeroReina == otraPosicion.NumeroReina);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}({1},{2})", 
                (NumeroReina > 0) ? string.Format("Reina #{0} ", NumeroReina) : "Libre ",
                this.PosicionX, 
                this.PosicionY);
        }
    }
}
