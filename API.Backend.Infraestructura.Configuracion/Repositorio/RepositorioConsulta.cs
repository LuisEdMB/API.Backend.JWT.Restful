using API.Backend.Dominio.Interfaz;
using API.Backend.Infraestructura.Configuracion.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace API.Backend.Infraestructura.Configuracion.Repositorio
{
    public class RepositorioConsulta : IRepositorioConsulta
    {
        ContextoConsulta contexto;
        public RepositorioConsulta(ContextoConsulta aoContexto)
        {
            contexto = aoContexto;
        }

        public T ObtenerPorCodigo<T>(params object[] keys) where T : class
        {
            return contexto.Set<T>().Find(keys);
        }

        public ICollection<T> ObtenerPorExpresionLimite<T>(Expression<Func<T, bool>> valor = null) where T : class
        {
            if(valor == null)
                return contexto.Set<T>().ToList();
            return contexto.Set<T>().Where(valor).ToList();
        }
    }
}
