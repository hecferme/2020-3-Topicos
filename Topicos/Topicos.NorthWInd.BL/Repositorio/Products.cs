using System;
using System.Collections.Generic;
using System.Text;
using Topicos.NorthWind.BaseDatos.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Topicos.NorthWInd.BL.Repositorio
{
    internal class Products
    {
        private readonly NorthWindContext _contexto = new NorthWindContext();

        public NorthWind.BaseDatos.Models.Products ObtenerProductosPorId(int id)
        {
            NorthWind.BaseDatos.Models.Products elResultado;
            elResultado = _contexto.Products.Include(p => p.Category).Include(p=> p.Supplier).Where(p => p.ProductId == id).FirstOrDefault();
            return elResultado;
        }
    }
}
