

namespace Ceres.Servicios.Models
{
    using System.Collections.Generic;
    using Dominio.Models;
    using System.Linq;
    using Ceres.Comunes.Models;
    public class serFamilia
    {
        private DataContext conexion = new DataContext();

        public List<Familia> Listado
        {
            get
            {
                return conexion.Familia.Include("cat_Grupo_Familia").OrderBy(a => a.Descripcion).ToList();
            }
        }

        public void Guardar(Familia modelo)
        {
            Utilerias utileria = new Utilerias();
            modelo.Codigo = utileria.InsertarCaracteres(utileria.Valor(conexion.Familia.Max(a => a.Codigo)) + 1, 6, '0', xLado.Izquierda);
            modelo.Estatus = "A";
            conexion.Familia.Add(modelo);
            conexion.SaveChanges();
        }

        public void Modificar(Familia modelo)
        {
            Utilerias utileria = new Utilerias();

            var update = conexion.Familia.Where(a => a.Codigo == modelo.Codigo).First();

            update.Descripcion = modelo.Descripcion;
            update.Grupo_Familia=modelo.Grupo_Familia;
            update.Estatus = modelo.Estatus;

            conexion.SaveChanges();

        }
    }

}

