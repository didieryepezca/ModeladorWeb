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
    public class PermisosController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<HomeController> _logger;

        public PermisosController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            this.userManager = userManager;
            _logger = logger;
        }


        [Authorize]
        public IActionResult VerPermisos(string tipoPermiso)
        {
            var user = userManager.GetUserAsync(User);
            var userId = user.Result.Id;

            ViewBag.usuario = userId;

            var daProy = new ProyectoDA();
            var proyUser = daProy.GetProyectosUsuario(userId);
            ViewBag.proyectos = proyUser;

            var daUsers = new UsuariosDA();
            var usuarios = daUsers.GetAllUsers();
            ViewBag.users = usuarios;

            var daPer = new PermisosDA();
            var permisos = daPer.getPermisosWithProyectos(tipoPermiso, userId);

            ViewBag.permiso = tipoPermiso;

            return View(permisos);
        }



        public int FunInsertPermiso(int py, string user, string per)
        {
            var result = "0";

            var userLogged = userManager.GetUserAsync(User);
            var userLoggedId = userLogged.Result.Id;
            var userLoggedName = userLogged.Result.UsuarioNombreCompleto;

            var daUser = new UsuariosDA();                       
            
            var da = new PermisosDA();          
            
            try
            {
                var usuConcedido = daUser.GetUserById(user);
                var usuConcName = usuConcedido.UsuarioNombreCompleto;

                TB_PERMISOS permiso = new TB_PERMISOS();

                permiso.ProyectoID = py;
                permiso.UsuarioCreacionId = userLoggedId;
                permiso.UsuarioCreacionName = userLoggedName;
                permiso.Permiso = per;
                permiso.UsuarioConcedidoId = user;
                permiso.UsuarioConcedidoName = usuConcName;
                permiso.FechaPermisoCreado = DateTime.Now;

                var modelcount = da.InsertPermiso(permiso);

                return modelcount;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }


    }
}
