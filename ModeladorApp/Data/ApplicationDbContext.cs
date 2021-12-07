using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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


            //optionBuilder.UseSqlServer("Server = tcp:server-modeladorbd.database.windows.net,1433;" +
            //       "Initial Catalog = ModeladorBD;" +
            //       "Persist Security Info = False;" +
            //       "User ID = server-modeladorbd;" +
            //       "Password = x$EE9ZAR;" +
            //       "MultipleActiveResultSets = False;" +
            //       "Encrypt = True;" +
            //       "Trusted_Connection=False;" +
            //       "TrustServerCertificate = False;" +
            //       "Connection Timeout = 30;");
        }

        //Tabla de Usuarios
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<TB_PROYECTO> TB_PROYECTO { get; set; }
        public virtual DbSet<TB_PERMISOS> TB_PERMISOS { get; set; }
        public virtual DbSet<TB_NIVEL> TB_NIVEL { get; set; }
        public virtual DbSet<TB_NIVEL_INFO> TB_NIVEL_INFO { get; set; }
        public virtual DbSet<TB_NIVEL_COLUMN_TITLES> TB_NIVEL_COLUMN_TITLES { get; set; }        
        public virtual DbSet<TB_TREE> TB_TREE { get; set; }

    }
}
