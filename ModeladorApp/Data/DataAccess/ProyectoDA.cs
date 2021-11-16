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
        public IEnumerable<TB_PROYECTO> GetProyectos()
        {
            var ana = new List<TB_PROYECTO>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_PROYECTO> query = db.TB_PROYECTO;                

                query = query.Where(item => item.ParentProyID == 0);
                
                query = query.OrderBy(p => p.ProyID);

                return query.ToList();
            }
        }

        public IEnumerable<TB_PROYECTO> GetProyectoSubMenu(int pId)
        {
            var ana = new List<TB_PROYECTO>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_PROYECTO> query = db.TB_PROYECTO;

                if(pId > 0) {

                    query = query.Where(item => item.ParentProyID == pId);

                }                

                query = query.OrderBy(p => p.ProyID);

                return query.ToList();
            }
        }
    }
}
