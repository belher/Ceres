﻿namespace Ceres.Comunes.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table ("Cat_Marca_Comercial")]
  public class Marca_comercial
    {
        [Key]
        public string Cve_marca_comercial { get; set; }

        [StringLength(30)]
        [Required]
        public string Descripcion { get; set; }

        [StringLength(1)]
        public string Estatus { get; set; }
        [StringLength(1)]
        private string Importado { get; set; }

    }
}