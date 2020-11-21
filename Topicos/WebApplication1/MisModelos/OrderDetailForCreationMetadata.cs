using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.MisValidaciones;

namespace WebApplication1.MisModelos
{
    public class OrderDetailForCreationMetadata
    {
        [Required (ErrorMessage = "Debe digitar un id de artículo.")]
        [Range(1, 100000000)]
        public object IdArticulo { get; set; }
        [Range(0.1,10000)]
        public object ProductPrice { get; set; }
        [Required]
        [Range(1, 100)]
        [ParImpar (false)]
        public object Quantity { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public string MiHilera { get; set; }
    }
}
