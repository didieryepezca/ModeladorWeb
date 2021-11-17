using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Microsoft.EntityFrameworkCore;

using ModeladorApp.Models.Entities;

namespace ModeladorApp.Data.DataAccess
{
    public class ProyectoDA
    {
        public IEnumerable<TB_PROYECTO> GetAllProyectosWithPermisos()
        {
            var ana = new List<TB_PROYECTO>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_PROYECTO> query = db.TB_PROYECTO.Include(c => c.TB_PERMISOS);               
                

                return query.ToList();
            }
        }

        public object GetAllProyectosWithPermisos_2(string nombre, string usuario)
        {
            var ana = new List<TB_PROYECTO>();

            using (var db = new ApplicationDbContext())
            {                
                    var query = (from proy in db.TB_PROYECTO
                                 join permiso in db.TB_PERMISOS
                                 on proy.ProyectoID equals permiso.ProyectoID

                                 where proy.NombreProyecto == nombre 
                                 && permiso.UsuarioCreacionId == usuario
                                 && permiso.Permiso == "ADMIN"


                                 select new TB_PROYECTO
                                 {
                                 ProyectoID = proy.ProyectoID,
                                 NombreProyecto = proy.NombreProyecto,
                                 DescripcionProyecto = proy.DescripcionProyecto,
                                 FechaCreado = proy.FechaCreado,
                                 FechaUltimaEdicion = proy.FechaUltimaEdicion,
                                 PropietarioID = proy.PropietarioID,
                                 PropietarioName = proy.PropietarioName,
                                 
                                 }).ToList();                   

                return query;
            }
        }




        public IEnumerable<TB_PROYECTO> GetProyectosUsuario(string propiertarioId = "")
        {
            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_PROYECTO> query = db.TB_PROYECTO;               

                if (!string.IsNullOrWhiteSpace(propiertarioId))
                {
                    query = query.Where(item => item.PropietarioID == propiertarioId);
                }
                return query.ToList();
            }
        }
    }
}
