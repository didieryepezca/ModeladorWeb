using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Microsoft.EntityFrameworkCore;
using ModeladorApp.Models.Entities;

namespace ModeladorApp.Data.DataAccess
{
    public class EquipoDA
    {
        public int InsertEquipo(TB_EQUIPO equipo)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(equipo);
                result = db.SaveChanges();
            }
            return result;
        }


        public IEnumerable<TB_EQUIPO> GetAllEquipos()
        {
            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_EQUIPO> query = db.TB_EQUIPO.OrderBy(f => f.FECHA_REGISTRO);                
                return query.ToList();
            }
        }

        public int UpdateEquipo(int id, string nombre, decimal ncr)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                var eq = db.TB_EQUIPO.Where(item => item.ID_EQUIPO == id).FirstOrDefault();
                eq.NOMBRE_EQUIPO = nombre;
                eq.NCR_EQUIPO = ncr;                

                result = db.SaveChanges();
            }
            return result;
        }


        public int deleteEquipo(int idEquipo)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                var e = db.TB_EQUIPO.Where(item => item.ID_EQUIPO == idEquipo).SingleOrDefault();
                db.TB_EQUIPO.Remove(e);
                result = db.SaveChanges();
            }
            return result;
        }


        public TB_EQUIPO getEquipo(int idEquipo)
        {
            var result = new TB_EQUIPO();
            {
                using (var db = new ApplicationDbContext())
                {
                    result = db.TB_EQUIPO.Where(item => item.ID_EQUIPO == idEquipo).FirstOrDefault();
                }
            }
            return result;
        }


    }
}
