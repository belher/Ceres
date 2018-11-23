
namespace Ceres.Servicios.Models
{
    using System.Collections.Generic;
    using Dominio.Models;
    using System.Linq;
    using Ceres.Comunes.Models;
    public class serGrupoFamilia
    {

        private DataContext conexion = new DataContext();

        public List<Grupo_Familia> Listado
        {
            get
            {
                 return conexion.GrupoFamilia.OrderBy(a => a.Descripcion).ToList();
            }
        }

        public void Guardar(Grupo_Familia grupo_Familia)
        {
            Utilerias utileria = new Utilerias();
            grupo_Familia .Codigo = utileria.InsertarCaracteres(utileria.Valor(conexion.GrupoFamilia .Max(a => a.Codigo)) + 1, 6, '0', xLado.Izquierda);
            grupo_Familia.Estatus = "A";
            conexion.GrupoFamilia.Add(grupo_Familia);
            conexion.SaveChanges();
        }

        public void Modificar(Grupo_Familia grupo_Familia)
        {
            Utilerias utileria = new Utilerias();

            var update = conexion.GrupoFamilia.Where(a => a.Codigo == grupo_Familia.Codigo).First();

            update.Descripcion  = grupo_Familia.Descripcion ;
            update.Estatus = grupo_Familia.Estatus;

            conexion.SaveChanges();

        }
    }
}
