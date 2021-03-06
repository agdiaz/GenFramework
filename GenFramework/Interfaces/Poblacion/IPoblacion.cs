﻿using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Interfaces.Poblacion
{
    public interface IPoblacion
    {
        IList<IIndividuo> PoblacionActual { get; }
        int NumeroGeneracion { get; set; }
        int CantidadIndividuos { get; set; }

        IIndividuo ObtenerIndividuo();
    }
}
