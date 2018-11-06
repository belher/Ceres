

namespace Ceres.Dominio.Models
{
    using Ceres.Comunes.Models;
    using System;
    using System.Data.Entity;

    public class DataContext:DbContext
    {
        public DataContext():base("Data source=DESKTOP-9AOLF9L\\SQLNAVARRO; Initial catalog=ceres;user=SA;Password=Belher123!")
        {

        
        }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Marca_comercial> Marca_comercial { get; set; }

    }
}
