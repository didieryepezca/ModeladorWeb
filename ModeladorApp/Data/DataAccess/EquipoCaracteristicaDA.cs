using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Microsoft.EntityFrameworkCore;
using ModeladorApp.Models.Entities;

namespace ModeladorApp.Data.DataAccess
{
    public class EquipoCaracteristicaDA
    {
        public int InsertEquipoCaracteristica(TB_EQUIPO_CARACTERISTICA equipo_car)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(equipo_car);
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<TB_EQUIPO_CARACTERISTICA> GetEquipoCaracteristicas(int idEquipo)
        {
            var ana = new List<TB_EQUIPO_CARACTERISTICA>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<TB_EQUIPO_CARACTERISTICA> query = db.TB_EQUIPO_CARACTERISTICA;

                if (idEquipo > 0)
                {
                    query = query.Where(item => item.ID_EQUIPO == idEquipo);
                }
                query = query.OrderBy(p => p.ID_EQUIPO_C);

                return query.ToList();
            }
        }


        public int UpdateEquipoCaracteristica(int id, string nombre, decimal ncr, decimal cant,string und, decimal desc1, decimal subtotal1, decimal mrc,
                                                decimal desc2, decimal subtotal2)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                var eq = db.TB_EQUIPO_CARACTERISTICA.Where(item => item.ID_EQUIPO_C == id).FirstOrDefault();
                eq.NOMBRE_CARACTERISTICA = nombre;
                eq.NRC_CARACTERISTICA = ncr;
                eq.CANT_CARACTERISTICA = cant;
                eq.UND_CARACTERISTICA = und;
                eq.DESC1_CARACTERISTICA = desc1;
                eq.SUB_TOTAL1 = subtotal1;
                eq.MRC_CARACTERISTICA = mrc;
                eq.DESC2_CARACTERISTICA = desc2;
                eq.SUB_TOTAL2 = subtotal2;

                result = db.SaveChanges();
            }
            return result;
        }



        public int deleteCaracteristica(int idc)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                var c = db.TB_EQUIPO_CARACTERISTICA.Where(item => item.ID_EQUIPO_C == idc).SingleOrDefault();
                db.TB_EQUIPO_CARACTERISTICA.Remove(c);
                result = db.SaveChanges();
            }
            return result;
        }


    }
}
