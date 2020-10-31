using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.MisModelos;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            var elResultado = OrdersDataStore.Current.OrdersList;
            return  Ok(elResultado);
        }

        internal Orders BuscarOrden (int orderId)
        {
            var laOrden = OrdersDataStore.Current.OrdersList.FirstOrDefault(o => o.Id == orderId);
            return laOrden;
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            // verifique si la orden existe
            var laOrden = BuscarOrden(id);
            if (laOrden == null)
                return NotFound();
            return Ok(laOrden);
        }
    }
}
