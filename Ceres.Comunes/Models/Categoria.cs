


namespace Ceres.Comunes.Models
{

    using System.ComponentModel.DataAnnotations;
    public class Categoria
    {
        [Key]
        public string cveCategoria { get; set; }

        public string Nombre { get; set; }

        public string Estatus { get; set; }


    }

}
