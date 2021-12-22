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
        public IActionResult VerProyectos(string nombre, string tipoProyecto, string accion = "", string nullpys = "")
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

            if (nullpys == "emptyProjects") {
                ViewBag.empty = "Debes crear al menos un proyecto para acceder";
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
            var nti = new NivelTituloDA();

            try
            {
                System.Threading.Thread.Sleep(3500);
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
                newTree.descripcion = "Reescribir aquí la descripción del proyecto.";
                newTree.lazy = true;
                newTree.parentId = 0;
                newTree.proyectoId = py.ProyectoID;
                newTree.fechaCreacion = DateTime.Now;

                var nCount = nda.InserNewLevel(newTree);

                int countTitulos = 0;

                //for (int t = 1; t <= 50; t++) { //Crear 50 titulos para 50 columnas
                for (int t = 1; t <= 10; t++)
                {

                    TB_NIVEL_COLUMN_TITLES ct = new TB_NIVEL_COLUMN_TITLES();

                    ct.proyectoID = py.ProyectoID;
                    ct.titulo = "Titulo " + t;

                    countTitulos = nti.InsertColumnTitle(ct);
                    countTitulos = countTitulos + t;
                }
                int totalInserts = pyCount + perCount + nCount + countTitulos;

                return totalInserts;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public int funDeleteProject(int proyectoId)
        {
            var result = "0";
            var tda = new NivelDA();
            var pda = new PermisosDA();
            var pyda = new ProyectoDA();
            var tida = new NivelTituloDA();
            var infoda = new NivelInfoDA();

            try
            {
                System.Threading.Thread.Sleep(3000);
                //---------------------------------Eliminamos niveles del arbol del proyecto.
                var nivelesToDelete = tda.getLevelsToDeleteFromProject(proyectoId).ToList();
                for (int n = 0; n < nivelesToDelete.Count; n++)
                {
                    try
                    {
                        tda.DeleteLevel(nivelesToDelete[n].id);
                    }
                    catch (Exception dn)
                    {
                        result = dn.Message;
                        return 0;
                    }
                    //---------------------------- Eliminamos la información de la grilla.
                    var infoToDelete = infoda.GetNivelInfo(nivelesToDelete[n].id).ToList();
                    for (int i = 0; i < infoToDelete.Count; n++) {
                        try
                        {
                            infoda.deleteInfo(infoToDelete[i].InfoID);
                        }
                        catch (Exception dn)
                        {
                            result = dn.Message;
                            return 0;
                        }
                    }
                }
                //---------------------------------Eliminamos los titulos del arbol del proyecto.
                var titulosFromGrilla = tida.GetNivelTitulosByIdProyecto(proyectoId).ToList();

                for (int i = 0; i < titulosFromGrilla.Count; i++) {
                    try
                    {
                        tida.deleteTitulo(titulosFromGrilla[i].TituloID);
                    }
                    catch (Exception dn)
                    {
                        result = dn.Message;
                        return 0;
                    }
                }
                //---------------------------------Eliminamos permisos del proyecto.
                var permisos = pda.getPermisosByIdProyecto(proyectoId).ToList();

                for (int i = 0; i < permisos.Count; i++)
                {
                    try
                    {
                        pda.DeletePermiso(permisos[i].PermisoID);
                    }
                    catch (Exception dp)
                    {
                        result = dp.Message;
                        return 0;
                    }
                }
                //---------------------------------Eliminamos el proyecto mismo.
                try
                {
                    pyda.deleteProyecto(proyectoId);
                }
                catch (Exception py)
                {
                    result = py.Message;
                    return 0;
                }
                return 1;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }
        public int funCloneProject(int proyectoId, string nombre, string descripcion)
        {
            var result = "0";
            var user = userManager.GetUserAsync(User);

            var da = new ProyectoDA();
            var pda = new PermisosDA();
            var nda = new NivelDA();
            var tida = new NivelTituloDA();

            try
            {
                System.Threading.Thread.Sleep(2500);

                var count = 0;

                TB_PROYECTO py = new TB_PROYECTO();
                py.NombreProyecto = nombre + "_Clonado";
                py.DescripcionProyecto = descripcion;
                py.FechaCreado = DateTime.Now;
                py.FechaUltimaEdicion = DateTime.Now;
                py.PropietarioID = user.Result.Id;
                py.PropietarioName = user.Result.UsuarioNombreCompleto;

                var pyCount = da.InsertPy(py);

                ////Permisos.
                TB_PERMISOS permiso = new TB_PERMISOS();

                permiso.ProyectoID = py.ProyectoID;
                permiso.UsuarioCreacionId = user.Result.Id;
                permiso.UsuarioCreacionName = user.Result.UsuarioNombreCompleto;
                permiso.Permiso = "EDITOR";
                permiso.UsuarioConcedidoId = user.Result.Id;
                permiso.UsuarioConcedidoName = user.Result.UsuarioNombreCompleto;
                permiso.FechaPermisoCreado = DateTime.Now;

                var perCount = pda.InsertPermiso(permiso);

                //------- Clonar Arbol
                List<TB_TREE> levelsFromProject = new List<TB_TREE>();
                levelsFromProject = nda.getLevelsToDeleteFromProject(proyectoId).ToList();

                var previousTempID = 0;
                var nextTempID = 0;

                for (int i = 0; i <= levelsFromProject.Count - 1; i++)
                {
                    List<TB_TREE> levelsAdded = new List<TB_TREE>();

                    if (levelsFromProject[i].parentId == 0)
                    {
                        //Nivel Root del arbol clonado                      
                        TB_TREE rootTree = new TB_TREE();

                        rootTree.title = levelsFromProject[i].title;
                        rootTree.descripcion = levelsFromProject[i].descripcion;
                        rootTree.lazy = levelsFromProject[i].lazy;
                        rootTree.parentId = 0;
                        rootTree.proyectoId = py.ProyectoID;
                        rootTree.fechaCreacion = DateTime.Now;

                        var countlvl = nda.InserNewLevel(rootTree);
                        previousTempID = rootTree.id;

                        count = count + countlvl;
                    }

                    levelsAdded = nda.getLevelsToDeleteFromProject(py.ProyectoID).ToList();
                    
                    var lastElementAdded = levelsAdded.Last();
                    var lastID = lastElementAdded.id;

                    //Sub niveles del arbol clonado    
                    var subniveles = levelsFromProject.Where(l => l.parentId == levelsFromProject[i].id).ToList();
                    if (subniveles.Count > 0)
                    {
                        for (int j = 0; j <= subniveles.Count - 1; j++)
                        {
                            TB_TREE cloneTree_step1 = new TB_TREE();

                            cloneTree_step1.title = subniveles[j].title;
                            cloneTree_step1.lazy = subniveles[j].lazy;
                            if (i == 0){
                                cloneTree_step1.parentId = previousTempID;
                            }else {                                
                                cloneTree_step1.parentId = lastID;
                            }
                            cloneTree_step1.proyectoId = py.ProyectoID;
                            cloneTree_step1.fechaCreacion = DateTime.Now;
                            var countlvl2 = nda.InserNewLevel(cloneTree_step1);

                            nextTempID = cloneTree_step1.id;

                            count = count + countlvl2;                            
                        }
                    }                    
                    else
                    {
                        var levelFound = levelsAdded.Where(l => l.title == levelsFromProject[i].title).FirstOrDefault();
                        if (levelFound != null)
                        {
                            continue;
                        }
                        else {
                            TB_TREE cloneTree_step2 = new TB_TREE();

                            cloneTree_step2.title = levelsFromProject[i].title;
                            cloneTree_step2.lazy = levelsFromProject[i].lazy;
                            cloneTree_step2.parentId = nextTempID;
                            cloneTree_step2.proyectoId = py.ProyectoID;
                            cloneTree_step2.fechaCreacion = DateTime.Now;

                            var countlvl3 = nda.InserNewLevel(cloneTree_step2);

                            previousTempID = cloneTree_step2.id;

                            count = count + countlvl3;
                        }
                    }                    
                }

                //------------------------- titulos
                var titulosFromGrilla = tida.GetNivelTitulosByIdProyecto(proyectoId).ToList();
                for (int i = 0; i < titulosFromGrilla.Count; i++)
                {
                    try
                    {
                        TB_NIVEL_COLUMN_TITLES ct = new TB_NIVEL_COLUMN_TITLES();

                        ct.proyectoID = py.ProyectoID;
                        ct.titulo = titulosFromGrilla[i].titulo;

                        tida.InsertColumnTitle(ct);
                    }
                    catch (Exception dn)
                    {
                        result = dn.Message;
                        return 0;
                    }
                }
                return count;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public string FunAgregarPermiso(int proyectoId, string userConcedido, string per)
        {
            var result = "0";

            var userLogged = userManager.GetUserAsync(User);
            var userLoggedId = userLogged.Result.Id;
            var userLoggedName = userLogged.Result.UsuarioNombreCompleto;

            var daUser = new UsuariosDA();
            var da = new PermisosDA();

            try
            {
                int duplicatePermiso = da.checkDuplicatePermiso(proyectoId, userConcedido, per).Count();

                if (duplicatePermiso >= 1)
                {
                    return "PERMISO EXISTENTE";
                }
                else
                {
                    var usuConcedido = daUser.GetUserById(userConcedido);
                    var usuConcName = usuConcedido.UsuarioNombreCompleto;

                    TB_PERMISOS permiso = new TB_PERMISOS();

                    permiso.ProyectoID = proyectoId;
                    permiso.UsuarioCreacionId = userLoggedId;
                    permiso.UsuarioCreacionName = userLoggedName;
                    permiso.Permiso = per;
                    permiso.UsuarioConcedidoId = userConcedido;
                    permiso.UsuarioConcedidoName = usuConcName;
                    permiso.FechaPermisoCreado = DateTime.Now;

                    var modelcount = da.InsertPermiso(permiso);

                    return "AGREGADO";
                }
            }
            catch (Exception e)
            {
                result = e.Message;
                return "ERROR";
            }
        }
    }
}
