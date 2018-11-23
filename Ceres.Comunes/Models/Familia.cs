namespace Ceres.Comunes.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Ceres.Comunes.Models;
    [Table("Cat_Familia")]
    public class Familia
    {

        [Key]
        [StringLength(6)]
        [Column(name:"cve_Familia")]
        public string Codigo { get; set;}
        [StringLength(60)]
        public string Descripcion { get; set; }
        public Grupo_Familia Grupo_Familia { get; set; }
        //[ForeignKey("cve_Grupo_Familia")]
        //public virtual List<Grupo_Familia>GrupoFamilia { get; set; }
        [UIHint("Estatus")]
        public string Estatus { get; set; }

        private string Importado { get; set; }
    }
}
