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

        public int UpdateEquipo(int id, string nombre, decimal ncr, decimal cant, string und, decimal desc1, decimal subtotal1, decimal mrc,
                                                decimal desc2, decimal subtotal2)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                var eq = db.TB_EQUIPO.Where(item => item.ID_EQUIPO == id).FirstOrDefault();
                eq.NOMBRE_EQUIPO = nombre;
                eq.NRC_EQUIPO = ncr;
                eq.CANT_EQUIPO = cant;
                eq.UND_EQUIPO = und;
                eq.DESC1_EQUIPO = desc1;
                eq.SUB_TOTAL1_EQ = subtotal1;
                eq.MRC_EQUIPO = mrc;
                eq.DESC2_EQUIPO = desc2;
                eq.SUB_TOTAL2_EQ = subtotal2;

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
