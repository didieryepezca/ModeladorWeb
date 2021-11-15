using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using ModeladorApp.Models.Entities;

namespace ModeladorApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
            Database.SetCommandTimeout(0); //30 minutos de ejecucion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=localhost;" +
                    "Database=ModeladorWeb;" +
                    "Trusted_Connection=True;" +
                    "MultipleActiveResultSets=True;" +
                    "Connection Timeout=36000");
        }
    }
}
