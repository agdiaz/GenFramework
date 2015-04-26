using GenFramework.Implementacion.Genetica;
using GenFramework.Interfaces.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaz.Genetica
{
    public class GenLargo : GenBase
    {
        public GenLargo(decimal largo)
        {
            this.Valor = largo;
            this.Nombre = "Largo";
        }
    }
}
