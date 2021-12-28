using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModeladorApp.Models.Entities;

namespace ModeladorApp.Data.DataAccess
{
    public class TreeStylesDA
    {
        public IEnumerable<TB_TREE_STYLE> GetAllStylesFromLevel(int lvlID, string campo)
        {
            var ana = new List<TB_TREE_STYLE>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_TREE_STYLE> query = db.TB_TREE_STYLE;

                query = query.Where(item => item.NivelID == lvlID);

                if (!string.IsNullOrWhiteSpace(campo))
                {
                    query = query.Where(item => item.campo == campo);
                }

                return query.ToList();
            }
        }        

        public int InsertNivelStyle(TB_TREE_STYLE style)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(style);
                result = db.SaveChanges();
            }
            return result;
        }


        public int deleteNivelStyle(int styleID)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                var sty = db.TB_TREE_STYLE.Where(item => item.StyleID == styleID).SingleOrDefault();
                db.TB_TREE_STYLE.Remove(sty);
                result = db.SaveChanges();
            }
            return result;
        }



    }
}
