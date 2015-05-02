using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFramework.OchoReinas.LogicaNegocio
{
    public class Tablero
    {
        public Posicion[][] posiciones;
        public List<Reina> reinas;

        public Tablero()
        {
            this.posiciones = new Posicion[8][];
            this.reinas = new List<Reina>();

            for (int i = 0; i < 8; i++)
            {
                posiciones[i] = new Posicion[8];
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    posiciones[i][j] = new Posicion(i, j);
                }
            }
        }

        public Tablero AgregarReina(int x, int y, int reina)
        {
            return this.AgregarReina(new Reina(x, y, reina));
        }

        public Tablero AgregarReina(Reina reina)
        {
            reinas.Add(reina);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (reina.Posicion.X == i || reina.Posicion.Y == j)
                    {
                        this.posiciones[i][j].AgregarReina(reina.NumeroReina);
                    }
                    else if (Math.Abs(reina.Posicion.X - i) == Math.Abs(reina.Posicion.Y - j))
                    {
                        this.posiciones[i][j].AgregarReina(reina.NumeroReina);
                    }
                    //else if (Math.Abs(reina.Posicion.X + i) == Math.Abs(reina.Posicion.Y + j))
                    //{
                    //    this.posiciones[i][j].AgregarReina(reina.NumeroReina);
                    //}
                }
            }

            return this;
        }

        public List<Reina> CalcularReinasVivas()
        {
            var reinasVivas = new List<Reina>();
            foreach (var reina in reinas)
            {
                if (posiciones[reina.Posicion.X][reina.Posicion.Y].Reina.Count == 1 &&
                    posiciones[reina.Posicion.X][reina.Posicion.Y].Reina[0] == reina.NumeroReina)
                {
                    reinasVivas.Add(reina);
                }
            }
            
            return reinasVivas;
        }

        public int CantPosicionesVacias()
        {
            var casillerosVacios = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!this.posiciones[i][j].Reina.Any()) 
                        casillerosVacios++;
                    
                }
            }

            return casillerosVacios;
        }

        public int CantCasillerosAmenazados()
        {
            var casillerosAmenazados = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (this.posiciones[i][j].Reina.Any())
                        casillerosAmenazados++;
                }
            }
            return casillerosAmenazados;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                string fila = string.Empty;
                for (int j = 0; j < 8; j++)
                {
                    fila += string.Format("{0}\t", posiciones[i][j].ToString());
                }
                sb.AppendLine(fila);
            }

            return sb.ToString();
        }
    }
}
