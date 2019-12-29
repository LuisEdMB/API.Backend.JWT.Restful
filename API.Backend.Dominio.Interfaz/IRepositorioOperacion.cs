using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Backend.Dominio.Interfaz
{
    public interface IRepositorioOperacion
    {
        void Agregar<T>(T entidad) where T : class;
        void Modificar<T>(T entidad) where T: class;
        void GuardarCambios();
        ICollection<T> ObtenerPorExpresionLimite<T>(Expression<Func<T, bool>> valor = null) where T : class;
        T ObtenerPorCodigo<T>(params object[] keys) where T : class;
    }
}
