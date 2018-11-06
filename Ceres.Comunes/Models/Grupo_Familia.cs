namespace Ceres.Comunes.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Cat_Grupo_Familia")]
   public  class Grupo_Familia
    {
        [Key]
        [StringLength(6)]
        public string cve_Grupo_Familia { get; set; }
        [Required]
        [StringLength(60)]
        public string Descripcion { get; set; }
        [StringLength(1)]
        [UIHint("Estatus")]
        public string Estatus { get; set; }
        private string Importado { get; set; }
    }
}
