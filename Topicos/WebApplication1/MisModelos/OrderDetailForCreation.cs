﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.MisModelos
{
    [ModelMetadataType(typeof(OrderDetailForCreationMetadata))]
    public class OrderDetailForCreation
    {
        public int IdArticulo { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string MiHilera { get; set; }
    }
}
