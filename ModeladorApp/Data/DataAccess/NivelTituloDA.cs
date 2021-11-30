using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModeladorApp.Models.Entities;

namespace ModeladorApp.Data.DataAccess
{
    public class NivelTituloDA
    {
        public IEnumerable<TB_NIVEL_COLUMN_TITLES> GetNivelTitulosByIdProyecto(int idProyecto)
        {
            var ana = new List<TB_NIVEL_COLUMN_TITLES>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_NIVEL_COLUMN_TITLES> query = db.TB_NIVEL_COLUMN_TITLES;

                if (idProyecto > 0)
                {
                    query = query.Where(item => item.proyectoID == idProyecto);
                }

                return query.ToList();
            }
        }

        public int InsertColumnTitle(TB_NIVEL_COLUMN_TITLES title)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(title);
                result = db.SaveChanges();
            }
            return result;
        }

        public int UpdateColumnTitle(int titleID, string titulo)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                var info = db.TB_NIVEL_COLUMN_TITLES.Where(item => item.TituloID == titleID).FirstOrDefault();
                info.titulo = titulo;              

                result = db.SaveChanges();
            }
            return result;
        }


    }
}
