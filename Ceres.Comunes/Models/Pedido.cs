namespace Ceres.Comunes.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Pedido
    {
        [Key]
        public string Folio_pedido { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name ="Folio")]
        public string Consecutivo { get; set; }

        [Required]
        [StringLength(6)]
        public string cve_usuario_solicita { get; set; }

        [Required]
        [StringLength(1)]
        public string Estatus { get; set; }
    }


    public class Pedido_detalle
    {
        [Key]
        public string Folio_pedido { get; set; }
        public int Orden { get; set; }
        public string Cve_articulo { get; set; }
        public Double Paridad { get; set; }
        public DateTime Fecha_requerido { get; set; }
        public string Stock { get; set; }
        public Double Cantidad { get; set; }
        public Double Precio_promedio { get; set; }
        public string Justificacion { get; set; }
        public string Autorizado { get; set; }
        public string Surtido { get; set; }
        public string Estatus { get; set; }
        public string Importado { get; set; }
        public string Bloqueado { get; set; }

        
    }


}
