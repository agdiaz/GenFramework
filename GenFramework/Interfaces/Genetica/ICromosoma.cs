﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaces.Genetica
{
    public interface ICromosoma
    {
        int CantidadGenes { get; }
        Array Genes { get; }
    }
}
