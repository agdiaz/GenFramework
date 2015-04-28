using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.OchoReinas.LogicaNegocio
{
    public class Posicion
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<int> Reina { get; set; }

        public Posicion(int x, int y)
        {
            X = x;
            Y = y;
            Reina = new List<int>();
        }
        public Posicion(int x, int y, int reina)
        {
            X = x;
            Y = y;
            Reina = new List<int>() { reina };
        }

        public void AgregarReina(int numero)
        {
            if (!Reina.Contains(numero))
            {
                Reina.Add(numero);
            }
        }
    }
}
