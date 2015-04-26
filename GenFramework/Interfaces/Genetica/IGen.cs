using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaces.Genetica
{
    public interface IGen : ICloneable
    {
        string Nombre { get; }
        decimal Valor { get; }

        void Mutar(int indiceMutacion);
    }
}
