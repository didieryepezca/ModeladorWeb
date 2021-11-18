using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Microsoft.EntityFrameworkCore;

using ModeladorApp.Models.Entities;
namespace ModeladorApp.Data.DataAccess
{
    public class HomeDA
    {
        public IEnumerable<TB_PERMISOS> getProyectosWithPermisos(string currentUser = "")
        {
            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_PERMISOS> query = db.TB_PERMISOS.Include(p => p.TB_PROYECTO);
                
                if (!string.IsNullOrWhiteSpace(currentUser))
                {
                    query = query.Where(item => item.UsuarioCreacionId == currentUser || item.UsuarioConcedidoId == currentUser);
                }               

                return query.ToList();
            }
        }

    }
}
