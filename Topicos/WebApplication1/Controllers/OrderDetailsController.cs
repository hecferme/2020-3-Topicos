using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.MisModelos;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;
using Topicos.NorthWind.BaseDatos.Models;

namespace WebApplication1.Controllers
{
    [Route("api/order/{id}/detalles")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly NorthWindContext _context;

        public OrderDetailsController(NorthWindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

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
            if (!ModelState.IsValid)
                return (BadRequest(od));
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


        private IActionResult BorrarDetalle(Orders laOrden, OrderDetail elDetalle)
        {
            var indice = laOrden.LosDetalles.ToList().FindIndex(d => d.IdArticulo == elDetalle.IdArticulo);
            laOrden.LosDetalles.RemoveAt(indice);
            return NoContent();
        }

        private IActionResult ActualizarDetalleParcialmente(Orders laOrden, OrderDetail elDetalle, 
            JsonPatchDocument<OrderDetailsForUpdate> patchDoc)
        {
            var elDetalleAParchar = new OrderDetailsForUpdate()
            {
                IdArticulo = elDetalle.IdArticulo,
                ProductPrice = elDetalle.ProductPrice,
                Quantity = elDetalle .Quantity
            };
            patchDoc.ApplyTo(elDetalleAParchar, ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (! TryValidateModel(elDetalleAParchar))
            {
                return BadRequest(ModelState);
            }
            // convierta el objeto parchado a uno que pueda asignar en una línea
            var elDetalleParaActualizar = new OrderDetail()
            {
                IdArticulo = elDetalleAParchar.IdArticulo,
                ProductPrice = elDetalleAParchar.ProductPrice,
                Quantity = elDetalleAParchar.Quantity
            };

            var indice = laOrden.LosDetalles.ToList().FindIndex(d => d.IdArticulo == elDetalle.IdArticulo);
            laOrden.LosDetalles[indice] = elDetalleParaActualizar;
            return NoContent(); 
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

        [HttpPatch("{productId}")]
        public IActionResult PartiallyUpdateOrderDetail (int id, int productId, 
            [FromBody] JsonPatchDocument<OrderDetailsForUpdate> patchedOrderDetail)
        {
            var laOrden = BuscarOrden(id);
            if (laOrden == null)
                return NotFound();
            var elDetalle = laOrden.LosDetalles.FirstOrDefault(d => d.IdArticulo == productId);
            if (elDetalle == null)
                return NotFound();
            return  ActualizarDetalleParcialmente(laOrden, elDetalle, 
                patchedOrderDetail);

        }

        [HttpDelete("{productid}")]
        public IActionResult DeleteOrderDetail (int id, int productId)
        {
            var laOrden = BuscarOrden(id);
            if (laOrden == null)
                return NotFound();
            var elDetalle = laOrden.LosDetalles.FirstOrDefault(d => d.IdArticulo == productId);
            if (elDetalle == null)
                return NotFound();
            return BorrarDetalle(laOrden, elDetalle);

        }

    }
}
