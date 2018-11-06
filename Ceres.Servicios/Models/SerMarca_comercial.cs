using System;
using System.Collections.Generic;
using System.Text;

namespace Ceres.Servicios.Models
{
    using System.Collections.Generic;
    using Dominio.Models;
    using System.Linq;
    using Ceres.Comunes.Models;
    class SerMarca_comercial
    {
        private DataContext conexion = new DataContext();

        public List<Marca_comercial> ListaMarca_comercial
        {
            get
            {
                if (conexion.Marca_comercial.Count() > 0)
                {
                    return conexion.Marca_comercial.OrderBy(a => a.Descripcion).ToList();
                }
                return null;

            }
        }

        public void Guardar(Marca_comercial Marca_comercial)
        {
            Utilerias utileria = new Utilerias();


            Marca_comercial.Cve_marca_comercial = utileria.InsertarCaracteres(utileria.Valor(conexion.Marca_comercial.Max(a => a.Cve_marca_comercial)) + 1, 6, '0', xLado.Izquierda);
            Marca_comercial.Estatus = "A";
            conexion.Marca_comercial.Add(Marca_comercial);
            conexion.SaveChanges();

        }

        public void Modificar(Marca_comercial Marca_comercial)
        {
            Utilerias utileria = new Utilerias();

            var update = conexion.Marca_comercial.Where(a => a.Cve_marca_comercial == Marca_comercial.Cve_marca_comercial).First();

            update.Descripcion= Marca_comercial.Descripcion;
            update.Estatus = Marca_comercial.Estatus;

            conexion.SaveChanges();

        }
    }
}
