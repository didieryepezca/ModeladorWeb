using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Microsoft.EntityFrameworkCore;

using ModeladorApp.Models.Entities;

namespace ModeladorApp.Data.DataAccess
{
    public class PermisosDA
    {
        public IEnumerable<TB_PERMISOS> getPermisosWithProyectos(string tipo = "", string currentUser = "")
        {
            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_PERMISOS> query = db.TB_PERMISOS.Include(p => p.TB_PROYECTO);

                if (tipo == "CREADOS")
                {
                    //if (!string.IsNullOrWhiteSpace(usuarioCreacion))
                    //{
                        query = query.Where(item => item.UsuarioCreacionId == currentUser);
                    //}
                }
                else {

                    query = query.Where(item => item.UsuarioConcedidoId == currentUser);
                }
                
                return query.ToList();
            }
        }


        public IEnumerable<TB_PERMISOS> getPermisosByIdProyecto(int proyectoId)
        {
            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_PERMISOS> query = db.TB_PERMISOS;
              
                if (proyectoId > 0)
                {
                    query = query.Where(item => item.ProyectoID == proyectoId);

                }               
                return query.ToList();
            }
        }


        public int InsertPermiso(TB_PERMISOS permiso)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(permiso);
                result = db.SaveChanges();
            }
            return result;
        }

    }
}
