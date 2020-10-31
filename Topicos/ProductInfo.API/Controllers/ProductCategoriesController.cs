using Microsoft.AspNetCore.Mvc;
using ProductInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.API.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/categories")]
    public class ProductCategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategories (int productId)
        {
            var product = ProductsDataStore.Current.ProductsList.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ListOfCategories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int productId, int id)
        {
            var product = ProductsDataStore.Current.ProductsList.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }
            var category = product.ListOfCategories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory (int productId, [FromBody] Category theCategory)
        {
            var product = ProductsDataStore.Current.ProductsList.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            var maxProductId = ProductsDataStore.Current.ProductsList.SelectMany(p => p.ListOfCategories).Max(c => c.Id);

            var finalCategory = new Category()
            {
                Id = ++maxProductId,
                Name = theCategory.Name,
                Description = theCategory.Description
            };

            return Ok();
        }

    }
}
