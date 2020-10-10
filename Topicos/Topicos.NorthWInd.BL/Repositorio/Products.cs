using System;
using System.Collections.Generic;
using System.Text;

namespace Topicos.NorthWInd.BL.Repositorio
{
    internal class Products
    {
        public NorthWind.BaseDatos.Models.Products ObtenerProductosPorId(int id)
        {
            NorthWind.BaseDatos.Models.Products elResultado;
            elResultado = new NorthWind.BaseDatos.Models.Products();
            return elResultado;
        }
    }
}
