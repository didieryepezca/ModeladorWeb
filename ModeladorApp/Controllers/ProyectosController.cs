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
            ViewBag.currentUser = userId;


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
            else
            {
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

            ViewBag.pyId = proyectoId;
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


        public int FunUpdateProyecto(int vIdPy, string vNombre, string vDescripcion)
        {
            var result = "0";
            var cDa = new ProyectoDA();

            try
            {
                var modelcount = cDa.UpdateProyecto(vIdPy, vNombre, vDescripcion);

                return modelcount;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public int funCreateProject(string nombre, string descripcion)
        {
            var result = "0";
            var user = userManager.GetUserAsync(User);           

            var da = new ProyectoDA();
            var pda = new PermisosDA();
            var nda = new NivelDA();

            try {

                //Proyecto
                TB_PROYECTO py = new TB_PROYECTO();
                py.NombreProyecto = nombre;
                py.DescripcionProyecto = descripcion;
                py.FechaCreado = DateTime.Now;
                py.FechaUltimaEdicion = DateTime.Now;
                py.PropietarioID = user.Result.Id;
                py.PropietarioName = user.Result.UsuarioNombreCompleto;

                var pyCount = da.InsertPy(py);                

                //Permisos.
                TB_PERMISOS permiso = new TB_PERMISOS();

                permiso.ProyectoID = py.ProyectoID;
                permiso.UsuarioCreacionId = user.Result.Id;
                permiso.UsuarioCreacionName = user.Result.UsuarioNombreCompleto;
                permiso.Permiso = "EDITOR";
                permiso.UsuarioConcedidoId = user.Result.Id;
                permiso.UsuarioConcedidoName = user.Result.UsuarioNombreCompleto;
                permiso.FechaPermisoCreado = DateTime.Now;

                var perCount = pda.InsertPermiso(permiso);

                //Inicialización del respectivo Árbol
                TB_TREE newTree = new TB_TREE();

                newTree.title = nombre;
                newTree.lazy = true;
                newTree.parentId = 0;
                newTree.proyectoId = py.ProyectoID;
                newTree.fechaCreacion = DateTime.Now;

                var nCount = nda.InserNewLevel(newTree);

                int totalInserts = pyCount + perCount + nCount;

                return totalInserts;
            }
            catch(Exception e)
            {
                result = e.Message;
                return 0;
            }
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
