using ProductInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.API
{
    public class ProductsDataStore
    {

        public static ProductsDataStore Current { get; } = new ProductsDataStore();
        public List<Product> ProductsList { get; set; }

        public ProductsDataStore()
        {
            ProductsList = new List<Product>()
            {
                new Product()
                {
                    Id = 10, Name = "Milk", Description = "1 Gallon Cow Milk",
                    ListOfCategories= new List  <Category> ()
                    {
                        new Category { Id = 10, Name="Lactics", 
                            Description = "The process of converting carbohydrates to alcohol or organic acids using microorganisms—yeasts or bacteria—under anaerobic conditions." },
                        new Category { Id = 80, Name="Groceries",
                            Description = "General range of food products, which may be fresh or packaged." }                    
                    }
                },
                new Product()
                {
                    Id = 20, Name = "Coffee", Description = "250 grams whole grain",
                    ListOfCategories= new List  <Category> ()
                    {
                        new Category { Id = 30, Name="Grains",
                            Description = "Small, hard, dry seed, with or without an attached hull or fruit layer, harvested for human or animal consumption." },
                        new Category { Id = 80, Name="Groceries",
                            Description = "General range of food products, which may be fresh or packaged." },
                         new Category { Id = 50, Name="Beverages",
                            Description = "Liquid intended for human consumption. In addition to their basic function of satisfying thirst, Beverages play important roles in human culture." }
                    }
                }
            };
        }
    }
}
