using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.MisModelos;

namespace WebApplication1.Controllers
{
    [Route("api/order/{id}/detalles")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {

        internal Orders BuscarOrden(int orderId)
        {
            var elController = new OrderController();
            var laOrden = elController.BuscarOrden(orderId);
            return laOrden;
        }
        internal OrderDetail BuscarDetalle(Orders laOrden, int productId)
        {

            var elDetalle = laOrden.LosDetalles.FirstOrDefault(d => d.IdArticulo == productId);
            return elDetalle;
        }

        [HttpGet]
        public IActionResult GetDetails(int id)
        {
            var laOrden = BuscarOrden(id);
            if (laOrden == null)
                return NotFound();
            return Ok(laOrden.LosDetalles);
        }

        [HttpGet]
        [Route("{productId}", Name = "GetDetalle")]
        public IActionResult GetDetalle (int id, int productId)
        {
            var laOrden = BuscarOrden(id);
            if (laOrden == null)
                return NotFound();
            var elDetalle = BuscarDetalle(laOrden, productId);
            if (elDetalle == null)
                return NotFound();
            return Ok(elDetalle);
        }

        private OrderDetail AgregarDetalle (Orders laOrden, OrderDetailForCreation od)
        {
            var elElemento = new OrderDetail()
            {
                IdArticulo = od.IdArticulo,
                ProductPrice = od.ProductPrice,
                Quantity = od.Quantity
            };
            laOrden.LosDetalles.Add(elElemento);
            return elElemento;
        }

        [HttpPost]
         public IActionResult Insert (int id, [FromBody] OrderDetailForCreation od)
        {
            var laOrden = BuscarOrden(id);
            if (laOrden == null)
                return NotFound();
            var elElemento = AgregarDetalle(laOrden, od);
            return CreatedAtRoute("GetDetalle",
                new
                {
                    productId = od.IdArticulo,
                    id = id
                },
                elElemento
           );
        }

        private OrderDetail ActualizarDetalle (Orders laOrden, OrderDetail elDetalle, OrderDetailsForUpdate odu)
        {
            var elDetalleActualizado = new OrderDetail()
            {
                IdArticulo = elDetalle.IdArticulo,
                ProductPrice = odu.ProductPrice,
                Quantity = odu.Quantity
            };
            var indice = laOrden.LosDetalles.ToList().FindIndex(d => d.IdArticulo == elDetalle.IdArticulo);
            laOrden.LosDetalles [indice] = elDetalleActualizado;
            return elDetalleActualizado;
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateOrderDetail (int id, int productId, [FromBody] OrderDetailsForUpdate odu)
        {
            var laOrden = BuscarOrden(id);
            if (laOrden == null)
                return NotFound();
            var elDetalle = laOrden.LosDetalles.FirstOrDefault(d => d.IdArticulo == productId);
            if (elDetalle == null)
                return NotFound();
            var elDetalleActualizado = ActualizarDetalle(laOrden, elDetalle, odu);

            return NoContent();
            
        }
    }
}
