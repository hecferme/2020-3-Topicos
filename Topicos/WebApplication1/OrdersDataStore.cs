using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.MisModelos;

namespace WebApplication1
{
    public class OrdersDataStore
    {
        public static OrdersDataStore Current { get; } = new OrdersDataStore();

        public List<Orders> OrdersList { get; set; }
        public OrdersDataStore()
        {
            OrdersList = new List<Orders>()
            {
                new Orders ()
                {
                    Id = 5,
                    OrderDate = DateTime.Now,
                    LosDetalles = new List<OrderDetail>()
                    {
                        new OrderDetail()
                        {
                            IdArticulo = 25,
                            ProductPrice = 19.4,
                            Quantity = 5
                        },
                        new OrderDetail()
                        {
                            IdArticulo = 15,
                            ProductPrice = 29.3,
                            Quantity = 9
                        }
                    }
                },
                new Orders ()
                {
                    Id = 25,
                    OrderDate = DateTime.Now.AddMinutes(-200),
                    LosDetalles = new List<OrderDetail>()
                    {
                        new OrderDetail()
                        {
                            IdArticulo = 25,
                            ProductPrice = 19.4,
                            Quantity = 15
                        },
                        new OrderDetail()
                        {
                            IdArticulo = 33,
                            ProductPrice = 66.6,
                            Quantity = 19
                        }
                    }

                }
            };
        }

    }
}
