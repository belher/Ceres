
namespace Ceres.Servicios.Models
{
    using System.Collections.Generic;
    using Dominio.Models;
    using System.Linq;
    using Ceres.Comunes.Models;
    public class serGrupoFamilia
    {

        private DataContext conexion = new DataContext();

        public List<Grupo_Familia> ListaGrupoFamilia
        {
            get
            {
                if (conexion.Articulo.Count() > 0)
                {
                    return conexion.GrupoFamilia.OrderBy(a => a.Descripcion).ToList();
                }
                return null;

            }
        }

        public void Guardar(Grupo_Familia grupo_Familia)
        {
            Utilerias utileria = new Utilerias();
            grupo_Familia .cve_Grupo_Familia = utileria.InsertarCaracteres(utileria.Valor(conexion.GrupoFamilia .Max(a => a.cve_Grupo_Familia )) + 1, 6, '0', xLado.Izquierda);
            grupo_Familia.Estatus = "A";
            conexion.GrupoFamilia.Add(grupo_Familia);
            conexion.SaveChanges();
        }

        public void Modificar(Grupo_Familia grupo_Familia)
        {
            Utilerias utileria = new Utilerias();

            var update = conexion.GrupoFamilia.Where(a => a.cve_Grupo_Familia == grupo_Familia.cve_Grupo_Familia ).First();

            update.Descripcion  = grupo_Familia.Descripcion ;
            update.Estatus = grupo_Familia.Estatus;

            conexion.SaveChanges();

        }
    }
}
