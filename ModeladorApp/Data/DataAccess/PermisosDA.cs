using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ModeladorApp.Models.Entities;

namespace ModeladorApp.Data.DataAccess
{
    public class PermisosDA
    {
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

        public IEnumerable<TB_PERMISOS> checkDuplicatePermiso(int pId, string userConcedidoId, string permiso)
        {
            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_PERMISOS> query = db.TB_PERMISOS;

                if (pId > 0)
                {
                    query = query.Where(item => item.ProyectoID == pId);
                }
                if (!string.IsNullOrWhiteSpace(userConcedidoId))
                {
                    query = query.Where(item => item.UsuarioConcedidoId == userConcedidoId);
                }
                if (!string.IsNullOrWhiteSpace(permiso))
                {
                    query = query.Where(item => item.Permiso == permiso);
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
