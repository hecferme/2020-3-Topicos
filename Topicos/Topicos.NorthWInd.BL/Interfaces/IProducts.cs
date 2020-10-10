using System;
using System.Collections.Generic;
using System.Text;
using Topicos.NorthWind.BaseDatos.Models;

namespace Topicos.NorthWInd.BL.Interfaces
{
    public interface IProducts
    {
        Products ObtenerProductosPorId(int id);

        ICollection<Products> ObtenerProductosPorNombreAproximado(string nombreProducto);

        ICollection<Products> ObtenerProductosPorRangoDePrecio(decimal? precioMinimo, decimal? precioMaximo);

    }
}
