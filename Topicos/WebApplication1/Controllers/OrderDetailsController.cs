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
        [Route("{productId}")]
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


    }
}
