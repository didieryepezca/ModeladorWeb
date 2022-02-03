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
    }
}
