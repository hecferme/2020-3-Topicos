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
        private readonly NorthWindContext _context = new NorthWindContext();

        public Products(NorthWindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public NorthWind.BaseDatos.Models.Products ObtenerProductoPorId(int id)
        {
            NorthWind.BaseDatos.Models.Products elResultado;
            elResultado = _context.Products.Include(p => p.Category).Include(p=> p.Supplier).Where(p => p.ProductId == id).FirstOrDefault();
            return elResultado;
        }
    }
}
