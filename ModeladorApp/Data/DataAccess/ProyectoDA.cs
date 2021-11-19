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
        public object GetAllProyectosWithPermisos(string nombre, string tipoProyecto, string userId, string accion = "")
        {
            using (var db = new ApplicationDbContext())
            {                
                var query = new List<TB_PROYECTO>();

                if (string.IsNullOrWhiteSpace(accion))
                {
                    query = (from proy in db.TB_PROYECTO join permiso in db.TB_PERMISOS
                               on proy.ProyectoID equals permiso.ProyectoID

                             //Agrupar proyectos repetidos por el join con los permisos...
                             into permisos
                             from p in permisos.DefaultIfEmpty()                             

                             select new TB_PROYECTO
                             {
                                 ProyectoID = proy.ProyectoID,
                                 NombreProyecto = proy.NombreProyecto,
                                 DescripcionProyecto = proy.DescripcionProyecto,
                                 FechaCreado = proy.FechaCreado,
                                 FechaUltimaEdicion = proy.FechaUltimaEdicion,
                                 PropietarioID = proy.PropietarioID,
                                 PropietarioName = proy.PropietarioName,

                                 TB_PERMISOS = db.TB_PERMISOS.Where(p => p.ProyectoID == proy.ProyectoID).ToList()

                             }).ToList();                    
                }

                if (tipoProyecto == "ALL")
                {
                    query = (from proy in db.TB_PROYECTO
                             join permiso in db.TB_PERMISOS
                                on proy.ProyectoID equals permiso.ProyectoID

                             //Agrupar proyectos repetidos por el join con los permisos...
                             into permisos
                             from p in permisos.DefaultIfEmpty()                            

                             select new TB_PROYECTO
                             {
                                 ProyectoID = proy.ProyectoID,
                                 NombreProyecto = proy.NombreProyecto,
                                 DescripcionProyecto = proy.DescripcionProyecto,
                                 FechaCreado = proy.FechaCreado,
                                 FechaUltimaEdicion = proy.FechaUltimaEdicion,
                                 PropietarioID = proy.PropietarioID,
                                 PropietarioName = proy.PropietarioName,
                                 TB_PERMISOS = db.TB_PERMISOS.Where(p => p.ProyectoID == proy.ProyectoID).ToList()

                             }).ToList();

                }
                else if (tipoProyecto == "VIEWER") {                   

                    query = (from proy in db.TB_PROYECTO join permiso in db.TB_PERMISOS
                               on proy.ProyectoID equals permiso.ProyectoID                             

                             where permiso.UsuarioConcedidoId == userId
                             && permiso.Permiso == "VIEWER"                             

                             select new TB_PROYECTO
                             {
                                 ProyectoID = proy.ProyectoID,
                                 NombreProyecto = proy.NombreProyecto,
                                 DescripcionProyecto = proy.DescripcionProyecto,
                                 FechaCreado = proy.FechaCreado,
                                 FechaUltimaEdicion = proy.FechaUltimaEdicion,
                                 PropietarioID = proy.PropietarioID,
                                 PropietarioName = proy.PropietarioName,
                                 TB_PERMISOS = db.TB_PERMISOS.Where(p => p.ProyectoID == proy.ProyectoID).ToList()

                             }).ToList();

                } else if (tipoProyecto == "EDITOR")  {                   

                    query = (from proy in db.TB_PROYECTO
                             join permiso in db.TB_PERMISOS
                             on proy.ProyectoID equals permiso.ProyectoID
                            
                             where permiso.UsuarioCreacionId == userId
                             && permiso.Permiso == "EDITOR"

                             select new TB_PROYECTO
                             {
                                 ProyectoID = proy.ProyectoID,
                                 NombreProyecto = proy.NombreProyecto,
                                 DescripcionProyecto = proy.DescripcionProyecto,
                                 FechaCreado = proy.FechaCreado,
                                 FechaUltimaEdicion = proy.FechaUltimaEdicion,
                                 PropietarioID = proy.PropietarioID,
                                 PropietarioName = proy.PropietarioName,
                                 TB_PERMISOS = db.TB_PERMISOS.Where(p => p.ProyectoID == proy.ProyectoID).ToList()

                             }).ToList();
                }          

                return query;
            }
        }

        public TB_PROYECTO getProyecto(int pyId)
        {
            var result = new TB_PROYECTO();
            {
                using (var db = new ApplicationDbContext())
                {
                    result = db.TB_PROYECTO.Where(item => item.ProyectoID == pyId).FirstOrDefault();
                }
            }
            return result;
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

        public int UpdateProyecto(int vIdPy, string vNombre, string vDescripcion)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                var py = db.TB_PROYECTO.Where(item => item.ProyectoID == vIdPy).FirstOrDefault();
                py.NombreProyecto = vNombre;
                py.DescripcionProyecto = vDescripcion;
                py.FechaUltimaEdicion = DateTime.Now;              

                result = db.SaveChanges();
            }
            return result;
        }



    }
}
