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
