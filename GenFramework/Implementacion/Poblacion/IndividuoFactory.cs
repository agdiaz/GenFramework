using GenFramework.Interfaces.Poblacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFramework.Implementacion.Poblacion
{
    public class IndividuoFactory : IIndividuoFactory
    {
        private IDictionary<Type, IIndividuo> _individuosRegistrados;

        public IndividuoFactory()
        {
            this._individuosRegistrados = new Dictionary<Type, IIndividuo>();
        }

        public void RegistrarIndividuo(IIndividuo individuo)
        {
            _individuosRegistrados.Add(individuo.Genotipo, individuo);
        }

        public IIndividuo Crear(Type genotipo)
        {
            if (_individuosRegistrados.ContainsKey(genotipo))
            {
                var individuo = _individuosRegistrados[genotipo];
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
