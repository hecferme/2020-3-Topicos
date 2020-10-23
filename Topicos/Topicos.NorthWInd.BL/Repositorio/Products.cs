using System;
using System.Collections.Generic;
using System.Text;
using Topicos.NorthWind.BaseDatos.Models;

namespace Topicos.NorthWInd.BL.Repositorio
{
    internal class Products
    {
        private readonly NorthWindContext _contexto = new NorthWindContext();

        public NorthWind.BaseDatos.Models.Products ObtenerProductosPorId(int id)
        {
            NorthWind.BaseDatos.Models.Products elResultado;
            elResultado = _contexto.Products.Find(id);
            return elResultado;
        }
    }
}
