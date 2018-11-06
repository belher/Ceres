

namespace Ceres.Comunes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    [Table("Cat_Cuenta_Contable")]
    public class CuentaContable
    {

      public string  cve_Cuenta_Contable { get; set; }
      public string Nombre_Cuenta { get; set; }
        public string Nivel1 { get; set; }
        public string Nivel2 { get; set; }
        public string Nivel3 { get; set; }
        public string Nivel4 { get; set; }
        public string Nivel5 { get; set; }
        public string Naturaleza { get; set; }
        public string Codigo_Agrupador { get; set; }
        public string Grupo_Tipo_Cuenta { get; set; }
        public string Tipo_cuenta { get; set; }
    public string Clasificacion { get; set; }
    public string Clasificacion2 { get; set; }
    public string Afectable { get; set; }
    public string Estatus { get; set; }
    public string Tipo_Movimiento { get; set; }
}
}
