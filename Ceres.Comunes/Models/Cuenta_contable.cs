namespace Ceres.Comunes.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Cuenta_contable
    {
        [Key]
        public string Cve_cuenta_contable { get; set; }
        [Required]
        public string Nombre_cuenta { get; set; }
        public string Nivel1 { get; set; }
        public string Nivel2 { get; set; }
        public string Nivel3 { get; set; }
        public string Nivel4 { get; set; }
        public string Nivel5 { get; set; }
        public string Naturaleza { get; set; }
        public string Codigo_agrupador { get; set; }
        public string Grupo_tipo_cuenta { get; set; }
        public string Tipo_cuenta { get; set; }
        public string Clasificacion { get; set; }
        public string Clasificacion2 { get; set; }
        public string Afectable { get; set; }
        public string Estatus { get; set; }
        public string Tipo_movimiento { get; set; }

    }
}
