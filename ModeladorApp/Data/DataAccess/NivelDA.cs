using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Microsoft.EntityFrameworkCore;

using ModeladorApp.Models.Entities;


namespace ModeladorApp.Data.DataAccess
{
    public class NivelDA
    {
        public IEnumerable<TB_NIVEL> GetMaster()
        {
            var ana = new List<TB_NIVEL>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_NIVEL> query = db.TB_NIVEL;

                query = query.Where(item => item.ParentNivelID == 0);

                query = query.OrderBy(p => p.NivelID);

                return query.ToList();
            }
        }

        public IEnumerable<TB_NIVEL> GetSubNiveles(int pId)
        {
            var ana = new List<TB_NIVEL>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_NIVEL> query = db.TB_NIVEL;

                if (pId > 0)
                {
                    query = query.Where(item => item.ParentNivelID == pId);
                }

                query = query.OrderBy(p => p.NivelID);

                return query.ToList();
            }
        }
    }
}
