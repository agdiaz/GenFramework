using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.Genetica
{
    public class GenBase : IGen
    {
        public string Nombre { get; protected set; }
        public decimal Valor {get; protected set;}

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Nombre, this.Valor.ToString());
        }


        public void Mutar(int indiceMutacion)
        {
            var maximoMutable = Convert.ToInt32(Math.Floor(Valor * indiceMutacion / 100));

            if (new Random().Next(0, 10) >= 5)
            { 
                Valor = Valor + new Random().Next(0, maximoMutable);
            }
            else
            {
                Valor = Valor - new Random().Next(0, maximoMutable);
            }

            if (Valor <= 0)
                Valor = 1;
        }

        public object Clone()
        {
            return new GenBase()
            {
                Nombre = this.Nombre,
                Valor = this.Valor,
            };
        }
    }
}
