using System;
using System.Collections.Generic;
using System.Text;
using Topicos.NorthWind.BaseDatos.Models;

namespace Topicos.NorthWInd.BL.Acciones
{
    internal class Products
    {
        private readonly NorthWindContext _context;

        public Products(NorthWindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public NorthWind.BaseDatos.Models.Products ObtenerProductoPorId(int id)
        {
            NorthWind.BaseDatos.Models.Products elResultado;
            var elRepositorio = new Repositorio.Products(_context);
            elResultado = elRepositorio.ObtenerProductoPorId(id);
            return elResultado;
        }
    }
}
