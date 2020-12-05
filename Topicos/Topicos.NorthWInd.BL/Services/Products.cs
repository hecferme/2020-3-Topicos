using System;
using System.Collections.Generic;
using System.Text;
using Topicos.NorthWInd.BL.Interfaces;
using Topicos.NorthWind.BaseDatos.Models;

namespace Topicos.NorthWInd.BL.Services
{
    public class Products : IProducts
    {
        private readonly NorthWindContext _context;

        public Products(NorthWindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public NorthWind.BaseDatos.Models.Products ObtenerProductoPorId(int id)
        {
            NorthWind.BaseDatos.Models.Products elResultado;
            var laAccion = new Acciones.Products(_context);
            elResultado = laAccion.ObtenerProductoPorId(id);
            return elResultado;
        }

        public ICollection<NorthWind.BaseDatos.Models.Products> ObtenerProductosPorNombreAproximado(string nombreProducto)
        {
            throw new NotImplementedException();
        }

        public ICollection<NorthWind.BaseDatos.Models.Products> ObtenerProductosPorRangoDePrecio(decimal? precioMinimo, decimal? precioMaximo)
        {
            throw new NotImplementedException();
        }
    }
}
