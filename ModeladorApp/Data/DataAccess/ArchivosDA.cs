using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Microsoft.EntityFrameworkCore;
using ModeladorApp.Models.Entities;


namespace ModeladorApp.Data.DataAccess
{
    public class ArchivosDA
    {
        public int InsertArchivo(TB_ARCHIVOS archivo)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(archivo);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
