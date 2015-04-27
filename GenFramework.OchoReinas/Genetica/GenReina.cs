using GenFramework.Implementacion.Genetica;
using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.OchoReinas.Genetica
{
    public class GenReina : GenBase
    {
        public GenReina(int posicionX, int posicionY)
        {
            this.Valor = new PosicionTablero(posicionX, posicionY);
            this.Nombre = "GenReina";
        }

        public override void Mutar(int indiceMutacion)
        {
        }

        public override IGen Clonar()
        {
            var posicion = this.Valor as PosicionTablero;
            return new GenReina(posicion.PosicionX, posicion.PosicionY);
        }
    }
}
