using GenFramework.Implementacion.Genetica;
using GenFramework.Interfaces.Genetica;
using GenFramework.OchoReinas.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.OchoReinas.Genetica
{
    public class GenReina : GenBase
    {
        private Reina reina;

        public GenReina(int posicionX, int posicionY, int numeroReina)
        {
            this.reina = new Reina(posicionX, posicionY, numeroReina); ;
            this.Valor = reina;
            this.Nombre = "GenReina";
        }

        public override void Mutar(int indiceMutacion)
        {
        }

        public override IGen Clonar()
        {
            var posicion = this.Valor as Reina;
            return new GenReina(reina.Posicion.X, reina.Posicion.Y, reina.NumeroReina);
        }
    }
}
