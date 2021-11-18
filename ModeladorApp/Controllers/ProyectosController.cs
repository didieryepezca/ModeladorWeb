using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModeladorApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using ModeladorApp.Models.Entities;
using ModeladorApp.Data.DataAccess;

namespace ModeladorApp.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<HomeController> _logger;

        public ProyectosController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            this.userManager = userManager;
            _logger = logger;
        }

        [Authorize]
        public IActionResult VerProyectos(string nombre, string tipoProyecto, string accion = "")
        {
            var user = userManager.GetUserAsync(User);
            var userId = user.Result.Id;

            var da = new ProyectoDA();

            string vAccion = "";

            if (!String.IsNullOrWhiteSpace(accion))
            {
                vAccion = accion;
            }

            var proyectos = da.GetAllProyectosWithPermisos(nombre, tipoProyecto, userId, vAccion);

            if (tipoProyecto == "ALL")
            {
                ViewBag.tipo = "Todos";
            }
            else if (tipoProyecto == "VIEWER")
            {
                ViewBag.tipo = "que puedo Ver";
            }
            else {
                ViewBag.tipo = "que puedo Editar";
            }

            return View(proyectos);
        }


        [Authorize]
        public IActionResult OverviewProyecto(int proyectoId) 
        {
            var user = userManager.GetUserAsync(User);
            var userId = user.Result.Id;


            var dapy = new ProyectoDA();
            var da = new PermisosDA();

            var proyecto = dapy.getProyecto(proyectoId);

            ViewBag.currentUser = userId;

            ViewBag.propietarioID = proyecto.PropietarioID;
            ViewBag.nombre = proyecto.NombreProyecto;
            ViewBag.descripcion = proyecto.DescripcionProyecto;
            ViewBag.fechacreacion = proyecto.FechaCreado;
            ViewBag.fechaedicion = proyecto.FechaUltimaEdicion;
            ViewBag.propietario = proyecto.PropietarioName;

            var daUsers = new UsuariosDA();
            var usuarios = daUsers.GetAllUsers();
            ViewBag.users = usuarios;

            var overview = da.getPermisosByIdProyecto(proyectoId);

            return View(overview);
        }




    }
}
