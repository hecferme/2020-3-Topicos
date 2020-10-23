using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Topicos.Calentamiento
{
    public class Job
    {
        public void Do()
        {
            Console.WriteLine("Hello World!");
            var lasHerramientas = new Topicos.Utilitarios.Message();
            var elMensaje = lasHerramientas.Say("Hello World!");
            Console.WriteLine(elMensaje);
            lasHerramientas.MyProperty = 89123;
            elMensaje = lasHerramientas.elMensaje;
            Console.WriteLine(elMensaje);
        }

        public void DoQuery ()
        {
            var terminar = false;
            while (! terminar)
            {
                MostrarMenu();
                var laOpcion = CapturarOpcion();
                terminar = InvocarAccionCorrespondiente(laOpcion);
            }
        }

        private bool InvocarAccionCorrespondiente(string laOpcion)
        {
            var terminarPrograma = (laOpcion == "0");
            RealiceInvocacion(laOpcion);
            return terminarPrograma;
        }

        private void RealiceInvocacion(string laOpcion)
        {
            switch (laOpcion)
            {
                case "1":  ConsultaPorIdDeProducto();
                    break;
                default:
                    break;
            };
        }

        private void ConsultaPorIdDeProducto()
        {
            var idDeProducto = CaptureIdDeProducto();
            if (idDeProducto != null)
            { 
                var elServicio = new Topicos.NorthWInd.BL.Services.Products();
                int elIdDeProductoNoNullable = (int)idDeProducto;
                var elProductoEncontrado = elServicio.ObtenerProductosPorId(elIdDeProductoNoNullable);
                if (elProductoEncontrado == null)
                {
                    //Console.WriteLine(string.Format ("El Id de Producto {0} no existe.", elIdDeProductoNoNullable.ToString()));
                    Console.WriteLine($"El Id de Producto {elIdDeProductoNoNullable.ToString()} no existe.");
                }
                else
                {
                    ImprimirDetallesDeProducto(elProductoEncontrado);
                }
            }
        }

        private void ImprimirDetallesDeProducto(NorthWind.BaseDatos.Models.Products elProductoEncontrado)
        {
            Console.WriteLine($"Detalles del producto {elProductoEncontrado.ProductId.ToString()}.");
            Console.WriteLine($"Nombre: {elProductoEncontrado.ProductName}, Precio {elProductoEncontrado.UnitPrice.ToString()}.");
        }

        private int? CaptureIdDeProducto()
        {
            Console.WriteLine("Digite el Id de Producto deseado: ");
            var elProductoString = System.Console.ReadLine();
            int elIdDeProducto = 0;
            int? elIdDeProductoNullable = null;
            if (! int.TryParse(elProductoString, out elIdDeProducto))
            {
                Console.WriteLine("El Id de Producto digitado es erróneo.");
            }
            else
            {
                elIdDeProductoNullable = (int?)elIdDeProducto;
            }
            return elIdDeProductoNullable;
        }

        private string CapturarOpcion()
        {
            var laOpcion = Console.ReadLine();
            return laOpcion;
        }

        private void MostrarMenu()
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("--------------");
            Console.WriteLine("1. Buscar Productos por Id.");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Digite su opción: ");
        }
    }
}
