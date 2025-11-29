using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gestion_tienda.Models
{
    public class VentaCreateViewModel
    {
        [Required]
        public int ClienteId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public List<VentaItemViewModel> Items { get; set; } = new List<VentaItemViewModel>();
    }
}
