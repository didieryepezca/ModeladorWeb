using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using ModeladorApp.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ModeladorApp.Data.DataAccess
{
    public class UsuariosDA
    {
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            var result = new List<ApplicationUser>();

            using (var db = new ApplicationDbContext())
            {
                result = db.ApplicationUser.ToList();

                return result;
            }
        }

        public ApplicationUser GetUserById(string IdAspnetUser)
        {
            var result = new ApplicationUser();
            {
                using (var db = new ApplicationDbContext())
                {
                    result = db.ApplicationUser.Where(item => item.Id == IdAspnetUser).FirstOrDefault();
                }
            }
            return result;
        }
    }
}
