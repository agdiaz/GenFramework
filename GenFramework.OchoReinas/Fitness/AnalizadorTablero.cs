using GenFramework.OchoReinas.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.OchoReinas.Fitness
{
    public class AnalizadorTablero
    {
        private List<PosicionTablero> _posicionReinas;

        public AnalizadorTablero()
        {
            this._posicionReinas = new List<PosicionTablero>(8);
        }

        public AnalizadorTablero AgregarReina(int x, int y)
        {
            var numeroReina = this._posicionReinas.Count + 1;
            this._posicionReinas.Add(new PosicionTablero(x, y, numeroReina));
            return this;
        }

        public AnalizadorTablero(Genetica.PosicionTablero posicionTablero1, Genetica.PosicionTablero posicionTablero2, Genetica.PosicionTablero posicionTablero3, Genetica.PosicionTablero posicionTablero4, Genetica.PosicionTablero posicionTablero5, Genetica.PosicionTablero posicionTablero6, Genetica.PosicionTablero posicionTablero7, Genetica.PosicionTablero posicionTablero8)
        {
            this._posicionReinas.Add(posicionTablero1);
            this._posicionReinas.Add(posicionTablero2);
            this._posicionReinas.Add(posicionTablero3);
            this._posicionReinas.Add(posicionTablero4);
            this._posicionReinas.Add(posicionTablero5);
            this._posicionReinas.Add(posicionTablero6);
            this._posicionReinas.Add(posicionTablero7);
            this._posicionReinas.Add(posicionTablero8);
        }

        public List<PosicionTablero> ObtenerPosicionesProhibidas()
        {
            var posicionesProhibidas = new List<PosicionTablero>();

            foreach (var reina in this._posicionReinas)
            {
                posicionesProhibidas.AddRange(reina.PosicionesProhibidas());
            }

            return posicionesProhibidas;
        }

        public List<PosicionTablero> ObtenerReinasVivas()
        {
            var reinasVivas = new List<PosicionTablero>();

            var posicionesProhibidas = this.ObtenerPosicionesProhibidas();

            foreach (var reina in this._posicionReinas)
            {
                var posicionesProhibidasSinContarReina = posicionesProhibidas.Where(p => p.NumeroReina != reina.NumeroReina);

                if (posicionesProhibidasSinContarReina.ToList().TrueForAll(p => p.PosicionX != reina.PosicionX && p.PosicionY != reina.PosicionY))
                {
                    reinasVivas.Add(reina);
                }
            }

            return reinasVivas;
        }
    }
}
