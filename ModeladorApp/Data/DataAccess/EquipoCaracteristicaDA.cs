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
    }
}
