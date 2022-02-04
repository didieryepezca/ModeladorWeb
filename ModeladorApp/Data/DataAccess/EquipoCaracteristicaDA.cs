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


        public int UpdateEquipoCaracteristica(int id, string nombre, decimal ncr)
        {
            var result = 0;

            using (var db = new ApplicationDbContext())
            {
                var eq = db.TB_EQUIPO_CARACTERISTICA.Where(item => item.ID_EQUIPO_C == id).FirstOrDefault();
                eq.NOMBRE_CARACTERISTICA = nombre;
                eq.NCR_CARACTERISTICA = ncr;

                result = db.SaveChanges();
            }
            return result;
        }


    }
}
