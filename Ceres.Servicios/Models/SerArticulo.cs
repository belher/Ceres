
namespace Ceres.Servicios.Models
{
  
    using System.Collections.Generic;
    using Dominio.Models;
    using System.Linq;
    using Ceres.Comunes.Models;

    public class SerArticulo 
    {
        private DataContext conexion = new DataContext();

        public List<Articulo> ListaArticulo
        {
            get 
            {
                return conexion.Articulo.OrderBy(a => a.Nombre).ToList();               
            }
        }

        public void Guardar(Articulo Articulo)
        {
            Utilerias utileria = new Utilerias();


                Articulo.CveArticulo = utileria.InsertarCaracteres(utileria.Valor(conexion.Articulo.Max(a => a.CveArticulo)) + 1, 6, '0', xLado.Izquierda);
                Articulo.Estatus = "A";
                conexion.Articulo.Add(Articulo);
        
            conexion.SaveChanges();

        }

        public void Modificar(Articulo Articulo)
        {
            Utilerias utileria = new Utilerias();

            var update = conexion.Articulo.Where(a => a.CveArticulo == Articulo.CveArticulo).First();

            update.Nombre = Articulo.Nombre;
            update.Estatus = Articulo.Estatus;

            conexion.SaveChanges();

        }
    }
}
