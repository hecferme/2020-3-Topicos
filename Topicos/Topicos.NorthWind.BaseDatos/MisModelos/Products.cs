using System;
using System.Collections.Generic;
using System.Text;

namespace Topicos.NorthWind.BaseDatos.Models
{
    public partial class Products
    {
        public short? UnidadesDesabastecidas { get 
            { 
                short? elResultado = 0;
                if (UnitsInStock < ReorderLevel)
                    elResultado = (short?)(UnitsInStock - ReorderLevel);
                return elResultado;
            }
            set
            { } 
        }

        public string SupplierName {
            get 
            {
                string elResultado = string.Empty;
                if (Supplier != null)
                {
                    elResultado = Supplier.CompanyName;
                }
                return elResultado;
            } 
            set
            { }
        }
    }
}
