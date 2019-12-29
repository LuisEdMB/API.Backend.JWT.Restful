using API.Backend.Dominio.Interfaz;
using API.Backend.Infraestructura.Configuracion.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace API.Backend.Infraestructura.Configuracion.Repositorio
{
    public class RepositorioOperacion : IRepositorioOperacion
    {
        ContextoOperacion contexto;
        public RepositorioOperacion(ContextoOperacion aoContexto)
        {
            contexto = aoContexto;
        }

        public void Agregar<T>(T entidad) where T : class
        {
            contexto.Entry(entidad).State = EntityState.Added;
        }

        public void GuardarCambios()
        {
            contexto.SaveChanges();
        }

        public void Modificar<T>(T entidad) where T : class
        {
            contexto.Entry(entidad).State = EntityState.Modified;
        }

        public T ObtenerPorCodigo<T>(params object[] keys) where T : class
        {
            return contexto.Set<T>().Find(keys);
        }

        public ICollection<T> ObtenerPorExpresionLimite<T>(Expression<Func<T, bool>> valor = null) where T : class
        {
            if (valor == null)
                return contexto.Set<T>().ToList();
            return contexto.Set<T>().Where(valor).ToList();
        }
    }
}
