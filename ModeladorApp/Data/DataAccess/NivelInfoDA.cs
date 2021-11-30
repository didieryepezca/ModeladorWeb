using System.Collections.Generic;
using System.Linq;
using System.Data;
using ModeladorApp.Models.Entities;
using System;

namespace ModeladorApp.Data.DataAccess
{
    public class NivelInfoDA
    {
        public int InsertNivelInfo(TB_NIVEL_INFO info)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(info);
                result = db.SaveChanges();
            }
            return result;
        }


        public int UpdateNivelInfo(int vInfoID, string usuario, string nvaInformacion)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                var info = db.TB_NIVEL_INFO.Where(item => item.InfoID == vInfoID).FirstOrDefault();
                info.Informacion = nvaInformacion;
                info.Usuario = usuario;
                info.FechaIngreso = DateTime.Now;

                result = db.SaveChanges();
            }
            return result;
        }



        public IEnumerable<TB_NIVEL_INFO> GetNivelInfo(int lvlID)
        {
            var ana = new List<TB_NIVEL_INFO>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_NIVEL_INFO> query = db.TB_NIVEL_INFO;

                if (lvlID > 0)
                {
                    query = query.Where(item => item.NivelID == lvlID);
                }

                return query.ToList();
            }
        }


        

    }
}
