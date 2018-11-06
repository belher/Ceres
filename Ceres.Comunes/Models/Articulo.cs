
namespace Ceres.Comunes.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Articulo
    {
        [Key]
        public String CveArticulo { get; set; }
        public String Nombre { get; set; }
        public String Estatus { get; set; }

    }
}
