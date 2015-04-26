using GenFramework.Implementacion.Genetica;
using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaz.Genetica
{
    public class GenPeso : GenBase
    {
        public GenPeso(decimal peso)
        {
            this.Valor = peso;
            this.Nombre = "Peso";
        }
    }
}
