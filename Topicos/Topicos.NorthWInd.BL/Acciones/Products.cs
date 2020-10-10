using System;
using System.Collections.Generic;
using System.Text;

namespace Topicos.NorthWInd.BL.Acciones
{
    internal class Products
    {
        public NorthWind.BaseDatos.Models.Products ObtenerProductosPorId(int id)
        {
            NorthWind.BaseDatos.Models.Products elResultado;
            var elRepositorio = new Repositorio.Products();
            elResultado = elRepositorio.ObtenerProductosPorId(id);
            return elResultado;
        }
    }
}
