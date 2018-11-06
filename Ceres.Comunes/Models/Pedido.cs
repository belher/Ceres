



namespace Ceres.Comunes.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Pedido
    {
        [Key]
        public string FolioPedido { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(4)]
        public string Consecutivo { get; set; }


        [Required]
        [StringLength(1)]
        public string Estatus { get; set; }
    }


    public class PedidoDetalle
    {

    }


}
