

namespace Ceres.Dominio.Models
{
    using Ceres.Comunes.Models;
    using System;
    using System.Data.Entity;

    public class DataContext:DbContext
    {
        public DataContext():base("Data Source=DESKTOP-JB7KFJ7\\SQLEXPRESS; initial catalog=ceres; integrated security=true;")
        {

         
        }

        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Grupo_Familia> GrupoFamilia { get; set; }
        public DbSet<Familia>Familia { get; set; }
        //public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Familia>().HasRequired(x => x.Grupo_Familia).WithMany().HasForeignKey(x => x.Grupo_Familia);
            base.OnModelCreating(modelBuilder);
        }
    }
}
