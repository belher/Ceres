

namespace Ceres.Dominio.Models
{
    using Ceres.Comunes.Models;
    using System;
    using System.Data.Entity;

    public class DataContext:DbContext
    {
        public DataContext():base()
        {

        
        }
        public DbSet<Articulo> Articulo { get; set; }

        //public DbSet<Categoria> Categoria { get; set; }
    }
}
