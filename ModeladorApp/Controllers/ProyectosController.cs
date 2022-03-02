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

            if (nullpys == "emptyProjects")
            {
                ViewBag.empty = "ATENCION ! Debes tener CREADO o haber CLONADO al menos un proyecto para acceder al Modelador de Proyectos.";
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
                System.Threading.Thread.Sleep(10); //Demora de 10 milisegundos
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

            var count = 0;

            try
            {
                System.Threading.Thread.Sleep(10); // demora de 10 milisegundos
                //---------------------------------Eliminamos niveles del arbol del proyecto.
                var nivelesToDelete = tda.getLevelsToDeleteFromProject(proyectoId).ToList();
                for (int n = 0; n < nivelesToDelete.Count; n++)
                {
                    try
                    {
                        var countLevel = tda.DeleteLevel(nivelesToDelete[n].id);
                        count = count + countLevel;
                    }
                    catch (Exception dn)
                    {
                        result = dn.Message;
                        return 0;
                    }
                    //---------------------------- Eliminamos la información de la grilla.
                    var infoToDelete = infoda.GetNivelInfo(nivelesToDelete[n].id).ToList();
                    for (int i = 0; i < infoToDelete.Count; n++)
                    {
                        try
                        {
                            var countInfo = infoda.deleteInfo(infoToDelete[i].InfoID);
                            count = count + countInfo;
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

                for (int i = 0; i < titulosFromGrilla.Count; i++)
                {
                    try
                    {
                        var countTitle = tida.deleteTitulo(titulosFromGrilla[i].TituloID);
                        count = count + countTitle;
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
                        var countPermiso = pda.DeletePermiso(permisos[i].PermisoID);
                        count = count + countPermiso;
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
                    var countPy = pyda.deleteProyecto(proyectoId);
                    count = count + countPy;
                }
                catch (Exception py)
                {
                    result = py.Message;
                    return 0;
                }
                return count;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }
        public JsonResult funCloneProject(int proyectoId, string nombre, string descripcion)
        {            
            var user = userManager.GetUserAsync(User);

            var da = new ProyectoDA();
            var pda = new PermisosDA();
            var nda = new NivelDA();
            var ndas = new TreeStylesDA();
            var ndai = new NivelInfoDA();
            var tida = new NivelTituloDA();

            var count = 0;
            var result = "";

            try
            {
                System.Threading.Thread.Sleep(10); // demora de 10 milisegundos
                var jres = new { msg = "", registros = 0, total = 0 };                

                //--------------------------------- Proyecto.
                TB_PROYECTO py = new TB_PROYECTO();
                py.NombreProyecto = nombre + "_Clonado";
                py.DescripcionProyecto = descripcion;
                py.FechaCreado = DateTime.Now;
                py.FechaUltimaEdicion = DateTime.Now;
                py.PropietarioID = user.Result.Id;
                py.PropietarioName = user.Result.UsuarioNombreCompleto;

                var pyCount = da.InsertPy(py);                
                //--------------------------------- Permisos.
                TB_PERMISOS permiso = new TB_PERMISOS();

                permiso.ProyectoID = py.ProyectoID;
                permiso.UsuarioCreacionId = user.Result.Id;
                permiso.UsuarioCreacionName = user.Result.UsuarioNombreCompleto;
                permiso.Permiso = "EDITOR";
                permiso.UsuarioConcedidoId = user.Result.Id;
                permiso.UsuarioConcedidoName = user.Result.UsuarioNombreCompleto;
                permiso.FechaPermisoCreado = DateTime.Now;

                var perCount = pda.InsertPermiso(permiso);
                
                //--------------------------------------------- Clonar Arbol
                //var previousTempID = 0;
                //var nextTempID = 0;

                List<TB_TREE> levelsFromProject = new List<TB_TREE>();
                levelsFromProject = nda.getLevelsToDeleteFromProject(proyectoId).ToList();

                int treeTotalCount = levelsFromProject.Count;

                //----------------------------------------------------- Nivel Root.
                TB_TREE cloneRootTree = new TB_TREE();
                var rootTree = levelsFromProject.Where(l => l.parentId == 0).FirstOrDefault();

                cloneRootTree.title = rootTree.title;
                cloneRootTree.descripcion = rootTree.descripcion;
                cloneRootTree.lazy = rootTree.lazy;
                cloneRootTree.parentId = 0;
                cloneRootTree.proyectoId = py.ProyectoID;
                cloneRootTree.fechaCreacion = DateTime.Now;

                var countRootLvl = nda.InserNewLevel(cloneRootTree);
                count = count + countRootLvl;               

                //----------------------------------------------------- Estilos Nivel Root                
                var stylesRoot = ndas.GetAllStylesFromLevel(rootTree.id, "").ToList();
                if (stylesRoot.Count > 0)
                {
                    for (int s = 0; s <= stylesRoot.Count - 1; s++)
                    {
                        TB_TREE_STYLE sto = new TB_TREE_STYLE();

                        sto.NivelID = cloneRootTree.id;
                        sto.campo = stylesRoot[s].campo;
                        sto.style = stylesRoot[s].style;

                        var modelstyle = ndas.InsertNivelStyle(sto);
                        
                    }
                }
                //----------------------------------------------------- Informacion Nivel Root                
                var infoRoot = ndai.GetNivelInfo(rootTree.id).ToList();
                if (infoRoot.Count > 0)
                {
                    for (int i = 0; i <= infoRoot.Count - 1; i++)
                    {
                        TB_NIVEL_INFO rootInfo = new TB_NIVEL_INFO();

                        rootInfo.NivelID = cloneRootTree.id;
                        rootInfo.Informacion = infoRoot[i].Informacion;
                        rootInfo.Usuario = user.Result.UsuarioNombreCompleto;
                        rootInfo.FechaIngreso = DateTime.Now;

                        var modelInfo = ndai.InsertNivelInfo(rootInfo);                        
                    }
                }
                ////------------------------- Titulos Nivel Root
                //var titulosFromGrilla = tida.GetNivelTitulosByIdProyecto(proyectoId).ToList();
                //for (int i = 0; i < titulosFromGrilla.Count; i++)
                //{
                //    try
                //    {
                //        TB_NIVEL_COLUMN_TITLES ct = new TB_NIVEL_COLUMN_TITLES();

                //        ct.proyectoID = py.ProyectoID;
                //        ct.titulo = titulosFromGrilla[i].titulo;

                //        var titleCount = tida.InsertColumnTitle(ct);

                //        count = count + titleCount;
                //    }
                //    catch (Exception dn)
                //    {
                //        result = dn.Message;
                //        return 0;
                //    }
                //}
                //-------------------------------------- Niveles distintos al lvl Root.
                //------------ primer loop del primer nivel...
                List<TB_TREE> sublvls = new List<TB_TREE>();
                sublvls = nda.GetSubLvl(rootTree.id).ToList();

                if (sublvls.Count > 0)
                {
                    for (int a = 0; a <= sublvls.Count - 1; a++)
                    {
                        TB_TREE dupTree_step1 = new TB_TREE();

                        dupTree_step1.title = sublvls[a].title;
                        dupTree_step1.descripcion = sublvls[a].descripcion;
                        dupTree_step1.lazy = sublvls[a].lazy;
                        dupTree_step1.parentId = cloneRootTree.id;
                        dupTree_step1.proyectoId = py.ProyectoID;
                        dupTree_step1.fechaCreacion = DateTime.Now;

                        var countlvl = nda.InserNewLevel(dupTree_step1);
                        

                        //----------- duplicar estilos
                        var step1styles = ndas.GetAllStylesFromLevel(sublvls[a].id, "").ToList();
                        if (step1styles.Count > 0)
                        {
                            for (int s = 0; s <= step1styles.Count - 1; s++)
                            {
                                TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                sto.NivelID = dupTree_step1.id;
                                sto.campo = step1styles[s].campo;
                                sto.style = step1styles[s].style;

                                var modelstyle = ndas.InsertNivelStyle(sto);                                
                            }
                        }

                        //----------- duplicar info
                        var step1info = ndai.GetNivelInfo(sublvls[a].id).ToList();
                        if (step1info.Count > 0)
                        {
                            for (int i = 0; i <= step1info.Count - 1; i++)
                            {
                                TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                info.NivelID = dupTree_step1.id;
                                info.Informacion = step1info[i].Informacion;
                                info.Usuario = user.Result.UsuarioNombreCompleto;
                                info.FechaIngreso = DateTime.Now;

                                var modelinfo = ndai.InsertNivelInfo(info);                                
                            }
                        }

                        //------------ segundo loop...
                        List<TB_TREE> sublvls2 = new List<TB_TREE>();
                        sublvls2 = nda.GetSubLvl(sublvls[a].id).ToList();

                        if (sublvls2.Count > 0)
                        {
                            for (int b = 0; b <= sublvls2.Count - 1; b++)
                            {
                                TB_TREE dupTree_step2 = new TB_TREE();

                                dupTree_step2.title = sublvls2[b].title;
                                dupTree_step2.descripcion = sublvls2[b].descripcion;
                                dupTree_step2.lazy = sublvls2[b].lazy;
                                dupTree_step2.parentId = dupTree_step1.id;
                                dupTree_step2.proyectoId = py.ProyectoID;
                                dupTree_step2.fechaCreacion = DateTime.Now;

                                var countlvl2 = nda.InserNewLevel(dupTree_step2);
                                

                                //----------- duplicar estilos
                                var step2styles = ndas.GetAllStylesFromLevel(sublvls2[b].id, "").ToList();
                                if (step2styles.Count > 0)
                                {
                                    for (int s = 0; s <= step2styles.Count - 1; s++)
                                    {
                                        TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                        sto.NivelID = dupTree_step2.id;
                                        sto.campo = step2styles[s].campo;
                                        sto.style = step2styles[s].style;

                                        var modelstyle = ndas.InsertNivelStyle(sto);                                        
                                    }
                                }

                                //----------- duplicar info
                                var step2info = ndai.GetNivelInfo(sublvls2[b].id).ToList();
                                if (step2info.Count > 0)
                                {
                                    for (int i = 0; i <= step2info.Count - 1; i++)
                                    {
                                        TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                        info.NivelID = dupTree_step2.id;
                                        info.Informacion = step2info[i].Informacion;
                                        info.Usuario = user.Result.UsuarioNombreCompleto;
                                        info.FechaIngreso = DateTime.Now;

                                        var modelinfo = ndai.InsertNivelInfo(info);                                        
                                    }
                                }

                                //------------ tercer loop...
                                List<TB_TREE> sublvls3 = new List<TB_TREE>();
                                sublvls3 = nda.GetSubLvl(sublvls2[b].id).ToList();

                                if (sublvls3.Count > 0)
                                {
                                    for (int c = 0; c <= sublvls3.Count - 1; c++)
                                    {
                                        TB_TREE dupTree_step3 = new TB_TREE();

                                        dupTree_step3.title = sublvls3[c].title;
                                        dupTree_step3.descripcion = sublvls3[c].descripcion;
                                        dupTree_step3.lazy = sublvls3[c].lazy;
                                        dupTree_step3.parentId = dupTree_step2.id;
                                        dupTree_step3.proyectoId = py.ProyectoID;
                                        dupTree_step3.fechaCreacion = DateTime.Now;

                                        var countlvl3 = nda.InserNewLevel(dupTree_step3);
                                        

                                        //----------- duplicar estilos
                                        var step3styles = ndas.GetAllStylesFromLevel(sublvls3[c].id, "").ToList();
                                        if (step3styles.Count > 0)
                                        {
                                            for (int s = 0; s <= step3styles.Count - 1; s++)
                                            {
                                                TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                sto.NivelID = dupTree_step3.id;
                                                sto.campo = step3styles[s].campo;
                                                sto.style = step3styles[s].style;

                                                var modelstyle = ndas.InsertNivelStyle(sto);                                                
                                            }
                                        }

                                        //----------- duplicar info
                                        var step3info = ndai.GetNivelInfo(sublvls3[c].id).ToList();
                                        if (step3info.Count > 0)
                                        {
                                            for (int i = 0; i <= step3info.Count - 1; i++)
                                            {
                                                TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                info.NivelID = dupTree_step3.id;
                                                info.Informacion = step3info[i].Informacion;
                                                info.Usuario = user.Result.UsuarioNombreCompleto;
                                                info.FechaIngreso = DateTime.Now;

                                                var modelinfo = ndai.InsertNivelInfo(info);                                                
                                            }
                                        }

                                        //------------ cuarto loop...
                                        List<TB_TREE> sublvls4 = new List<TB_TREE>();
                                        sublvls4 = nda.GetSubLvl(sublvls3[c].id).ToList();

                                        if (sublvls4.Count > 0)
                                        {
                                            for (int d = 0; d <= sublvls4.Count - 1; d++)
                                            {
                                                TB_TREE dupTree_step4 = new TB_TREE();

                                                dupTree_step4.title = sublvls4[d].title;
                                                dupTree_step4.descripcion = sublvls4[d].descripcion;
                                                dupTree_step4.lazy = sublvls4[d].lazy;
                                                dupTree_step4.parentId = dupTree_step3.id;
                                                dupTree_step4.proyectoId = py.ProyectoID;
                                                dupTree_step4.fechaCreacion = DateTime.Now;

                                                var countlvl4 = nda.InserNewLevel(dupTree_step4);                                                

                                                //----------- duplicar estilos
                                                var step4styles = ndas.GetAllStylesFromLevel(sublvls4[d].id, "").ToList();
                                                if (step4styles.Count > 0)
                                                {
                                                    for (int s = 0; s <= step4styles.Count - 1; s++)
                                                    {
                                                        TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                        sto.NivelID = dupTree_step4.id;
                                                        sto.campo = step4styles[s].campo;
                                                        sto.style = step4styles[s].style;

                                                        var modelstyle = ndas.InsertNivelStyle(sto);
                                                        
                                                    }
                                                }

                                                //----------- duplicar info
                                                var step4info = ndai.GetNivelInfo(sublvls4[d].id).ToList();
                                                if (step4info.Count > 0)
                                                {
                                                    for (int i = 0; i <= step4info.Count - 1; i++)
                                                    {
                                                        TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                        info.NivelID = dupTree_step4.id;
                                                        info.Informacion = step4info[i].Informacion;
                                                        info.Usuario = user.Result.UsuarioNombreCompleto;
                                                        info.FechaIngreso = DateTime.Now;

                                                        var modelinfo = ndai.InsertNivelInfo(info);
                                                        
                                                    }
                                                }

                                                //------------ quinto loop...
                                                List<TB_TREE> sublvls5 = new List<TB_TREE>();
                                                sublvls5 = nda.GetSubLvl(sublvls4[d].id).ToList();

                                                if (sublvls5.Count > 0)
                                                {
                                                    for (int e = 0; e <= sublvls5.Count - 1; e++)
                                                    {
                                                        TB_TREE dupTree_step5 = new TB_TREE();

                                                        dupTree_step5.title = sublvls5[e].title;
                                                        dupTree_step5.descripcion = sublvls5[e].descripcion;
                                                        dupTree_step5.lazy = sublvls5[e].lazy;
                                                        dupTree_step5.parentId = dupTree_step4.id;
                                                        dupTree_step5.proyectoId = py.ProyectoID;
                                                        dupTree_step5.fechaCreacion = DateTime.Now;

                                                        var countlvl5 = nda.InserNewLevel(dupTree_step5);
                                                        

                                                        //----------- duplicar estilos
                                                        var step5styles = ndas.GetAllStylesFromLevel(sublvls5[e].id, "").ToList();
                                                        if (step5styles.Count > 0)
                                                        {
                                                            for (int s = 0; s <= step5styles.Count - 1; s++)
                                                            {
                                                                TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                sto.NivelID = dupTree_step5.id;
                                                                sto.campo = step5styles[s].campo;
                                                                sto.style = step5styles[s].style;

                                                                var modelstyle = ndas.InsertNivelStyle(sto);
                                                                
                                                            }
                                                        }

                                                        //----------- duplicar info
                                                        var step5info = ndai.GetNivelInfo(sublvls5[e].id).ToList();
                                                        if (step5info.Count > 0)
                                                        {
                                                            for (int i = 0; i <= step5info.Count - 1; i++)
                                                            {
                                                                TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                info.NivelID = dupTree_step5.id;
                                                                info.Informacion = step5info[i].Informacion;
                                                                info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                info.FechaIngreso = DateTime.Now;

                                                                var modelinfo = ndai.InsertNivelInfo(info);
                                                                
                                                            }
                                                        }

                                                        //------------ sexto loop...
                                                        List<TB_TREE> sublvls6 = new List<TB_TREE>();
                                                        sublvls6 = nda.GetSubLvl(sublvls5[e].id).ToList();

                                                        if (sublvls6.Count > 0)
                                                        {
                                                            for (int f = 0; f <= sublvls6.Count - 1; f++)
                                                            {
                                                                TB_TREE dupTree_step6 = new TB_TREE();

                                                                dupTree_step6.title = sublvls6[f].title;
                                                                dupTree_step6.descripcion = sublvls6[f].descripcion;
                                                                dupTree_step6.lazy = sublvls6[f].lazy;
                                                                dupTree_step6.parentId = dupTree_step5.id;
                                                                dupTree_step6.proyectoId = py.ProyectoID;
                                                                dupTree_step6.fechaCreacion = DateTime.Now;

                                                                var countlvl6 = nda.InserNewLevel(dupTree_step6);
                                                                

                                                                //----------- duplicar estilos
                                                                var step6styles = ndas.GetAllStylesFromLevel(sublvls6[f].id, "").ToList();
                                                                if (step6styles.Count > 0)
                                                                {
                                                                    for (int s = 0; s <= step6styles.Count - 1; s++)
                                                                    {
                                                                        TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                        sto.NivelID = dupTree_step6.id;
                                                                        sto.campo = step6styles[s].campo;
                                                                        sto.style = step6styles[s].style;

                                                                        var modelstyle = ndas.InsertNivelStyle(sto);
                                                                        
                                                                    }
                                                                }

                                                                //----------- duplicar info
                                                                var step6info = ndai.GetNivelInfo(sublvls6[f].id).ToList();
                                                                if (step6info.Count > 0)
                                                                {
                                                                    for (int i = 0; i <= step6info.Count - 1; i++)
                                                                    {
                                                                        TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                        info.NivelID = dupTree_step6.id;
                                                                        info.Informacion = step6info[i].Informacion;
                                                                        info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                        info.FechaIngreso = DateTime.Now;

                                                                        var modelinfo = ndai.InsertNivelInfo(info);
                                                                        
                                                                    }
                                                                }

                                                                //------------ septimo loop...
                                                                List<TB_TREE> sublvls7 = new List<TB_TREE>();
                                                                sublvls7 = nda.GetSubLvl(sublvls6[f].id).ToList();

                                                                if (sublvls7.Count > 0)
                                                                {
                                                                    for (int g = 0; g <= sublvls7.Count - 1; g++)
                                                                    {
                                                                        TB_TREE dupTree_step7 = new TB_TREE();

                                                                        dupTree_step7.title = sublvls7[g].title;
                                                                        dupTree_step7.descripcion = sublvls7[g].descripcion;
                                                                        dupTree_step7.lazy = sublvls7[g].lazy;
                                                                        dupTree_step7.parentId = dupTree_step6.id;
                                                                        dupTree_step7.proyectoId = py.ProyectoID;
                                                                        dupTree_step7.fechaCreacion = DateTime.Now;

                                                                        var countlvl7 = nda.InserNewLevel(dupTree_step7);
                                                                        

                                                                        //----------- duplicar estilos
                                                                        var step7styles = ndas.GetAllStylesFromLevel(sublvls7[g].id, "").ToList();
                                                                        if (step7styles.Count > 0)
                                                                        {
                                                                            for (int s = 0; s <= step7styles.Count - 1; s++)
                                                                            {
                                                                                TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                                sto.NivelID = dupTree_step7.id;
                                                                                sto.campo = step7styles[s].campo;
                                                                                sto.style = step7styles[s].style;

                                                                                var modelstyle = ndas.InsertNivelStyle(sto);
                                                                                
                                                                            }
                                                                        }


                                                                        //----------- duplicar info
                                                                        var step7info = ndai.GetNivelInfo(sublvls7[g].id).ToList();
                                                                        if (step7info.Count > 0)
                                                                        {
                                                                            for (int i = 0; i <= step7info.Count - 1; i++)
                                                                            {
                                                                                TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                                info.NivelID = dupTree_step7.id;
                                                                                info.Informacion = step7info[i].Informacion;
                                                                                info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                                info.FechaIngreso = DateTime.Now;

                                                                                var modelinfo = ndai.InsertNivelInfo(info);
                                                                                
                                                                            }
                                                                        }


                                                                        //------------ octavo loop...
                                                                        List<TB_TREE> sublvls8 = new List<TB_TREE>();
                                                                        sublvls8 = nda.GetSubLvl(sublvls7[g].id).ToList();

                                                                        if (sublvls8.Count > 0)
                                                                        {
                                                                            for (int h = 0; h <= sublvls8.Count - 1; h++)
                                                                            {
                                                                                TB_TREE dupTree_step8 = new TB_TREE();

                                                                                dupTree_step8.title = sublvls8[h].title;
                                                                                dupTree_step8.descripcion = sublvls8[h].descripcion;
                                                                                dupTree_step8.lazy = sublvls8[h].lazy;
                                                                                dupTree_step8.parentId = dupTree_step7.id;
                                                                                dupTree_step8.proyectoId = py.ProyectoID;
                                                                                dupTree_step8.fechaCreacion = DateTime.Now;

                                                                                var countlvl8 = nda.InserNewLevel(dupTree_step8);
                                                                                

                                                                                //----------- duplicar estilos
                                                                                var step8styles = ndas.GetAllStylesFromLevel(sublvls8[h].id, "").ToList();
                                                                                if (step8styles.Count > 0)
                                                                                {
                                                                                    for (int s = 0; s <= step8styles.Count - 1; s++)
                                                                                    {
                                                                                        TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                                        sto.NivelID = dupTree_step8.id;
                                                                                        sto.campo = step8styles[s].campo;
                                                                                        sto.style = step8styles[s].style;

                                                                                        var modelstyle = ndas.InsertNivelStyle(sto);
                                                                                        
                                                                                    }
                                                                                }

                                                                                //----------- duplicar info
                                                                                var step8info = ndai.GetNivelInfo(sublvls8[h].id).ToList();
                                                                                if (step8info.Count > 0)
                                                                                {
                                                                                    for (int i = 0; i <= step8info.Count - 1; i++)
                                                                                    {
                                                                                        TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                                        info.NivelID = dupTree_step8.id;
                                                                                        info.Informacion = step8info[i].Informacion;
                                                                                        info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                                        info.FechaIngreso = DateTime.Now;

                                                                                        var modelinfo = ndai.InsertNivelInfo(info);
                                                                                        
                                                                                    }
                                                                                }

                                                                                //------------ noveno loop...
                                                                                List<TB_TREE> sublvls9 = new List<TB_TREE>();
                                                                                sublvls9 = nda.GetSubLvl(sublvls8[h].id).ToList();

                                                                                if (sublvls9.Count > 0)
                                                                                {
                                                                                    for (int i = 0; i <= sublvls9.Count - 1; i++)
                                                                                    {
                                                                                        TB_TREE dupTree_step9 = new TB_TREE();

                                                                                        dupTree_step9.title = sublvls9[i].title;
                                                                                        dupTree_step9.descripcion = sublvls9[i].descripcion;
                                                                                        dupTree_step9.lazy = sublvls9[i].lazy;
                                                                                        dupTree_step9.parentId = dupTree_step8.id;
                                                                                        dupTree_step9.proyectoId = py.ProyectoID;
                                                                                        dupTree_step9.fechaCreacion = DateTime.Now;

                                                                                        var countlvl9 = nda.InserNewLevel(dupTree_step9);
                                                                                        

                                                                                        //----------- duplicar estilos
                                                                                        var step9styles = ndas.GetAllStylesFromLevel(sublvls9[i].id, "").ToList();
                                                                                        if (step9styles.Count > 0)
                                                                                        {
                                                                                            for (int s = 0; s <= step9styles.Count - 1; s++)
                                                                                            {
                                                                                                TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                                                sto.NivelID = dupTree_step9.id;
                                                                                                sto.campo = step9styles[s].campo;
                                                                                                sto.style = step9styles[s].style;

                                                                                                var modelstyle = ndas.InsertNivelStyle(sto);
                                                                                                
                                                                                            }
                                                                                        }

                                                                                        //----------- duplicar info
                                                                                        var step9info = ndai.GetNivelInfo(sublvls9[i].id).ToList();
                                                                                        if (step9info.Count > 0)
                                                                                        {
                                                                                            for (int ii = 0; ii <= step9info.Count - 1; ii++)
                                                                                            {
                                                                                                TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                                                info.NivelID = dupTree_step9.id;
                                                                                                info.Informacion = step9info[ii].Informacion;
                                                                                                info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                                                info.FechaIngreso = DateTime.Now;

                                                                                                var modelinfo = ndai.InsertNivelInfo(info);
                                                                                                
                                                                                            }
                                                                                        }

                                                                                        //------------ decimo loop...
                                                                                        List<TB_TREE> sublvls10 = new List<TB_TREE>();
                                                                                        sublvls10 = nda.GetSubLvl(sublvls9[i].id).ToList();

                                                                                        if (sublvls10.Count > 0)
                                                                                        {
                                                                                            for (int j = 0; j <= sublvls10.Count - 1; j++)
                                                                                            {
                                                                                                TB_TREE dupTree_step10 = new TB_TREE();

                                                                                                dupTree_step10.title = sublvls10[j].title;
                                                                                                dupTree_step10.descripcion = sublvls10[j].descripcion;
                                                                                                dupTree_step10.lazy = sublvls10[j].lazy;
                                                                                                dupTree_step10.parentId = dupTree_step9.id;
                                                                                                dupTree_step10.proyectoId = py.ProyectoID;
                                                                                                dupTree_step10.fechaCreacion = DateTime.Now;

                                                                                                var countlvl10 = nda.InserNewLevel(dupTree_step10);
                                                                                                

                                                                                                //----------- duplicar estilos
                                                                                                var step10styles = ndas.GetAllStylesFromLevel(sublvls10[j].id, "").ToList();
                                                                                                if (step10styles.Count > 0)
                                                                                                {
                                                                                                    for (int s = 0; s <= step10styles.Count - 1; s++)
                                                                                                    {
                                                                                                        TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                                                        sto.NivelID = dupTree_step10.id;
                                                                                                        sto.campo = step10styles[s].campo;
                                                                                                        sto.style = step10styles[s].style;

                                                                                                        var modelstyle = ndas.InsertNivelStyle(sto);
                                                                                                        
                                                                                                    }
                                                                                                }

                                                                                                //----------- duplicar info
                                                                                                var step10info = ndai.GetNivelInfo(sublvls10[j].id).ToList();
                                                                                                if (step10info.Count > 0)
                                                                                                {
                                                                                                    for (int ii = 0; ii <= step10info.Count - 1; ii++)
                                                                                                    {
                                                                                                        TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                                                        info.NivelID = dupTree_step10.id;
                                                                                                        info.Informacion = step10info[ii].Informacion;
                                                                                                        info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                                                        info.FechaIngreso = DateTime.Now;

                                                                                                        var modelinfo = ndai.InsertNivelInfo(info);
                                                                                                        
                                                                                                    }
                                                                                                }

                                                                                                //------------ onceavo loop...
                                                                                                List<TB_TREE> sublvls11 = new List<TB_TREE>();
                                                                                                sublvls11 = nda.GetSubLvl(sublvls10[j].id).ToList();

                                                                                                if (sublvls11.Count > 0)
                                                                                                {
                                                                                                    for (int k = 0; k <= sublvls11.Count - 1; k++)
                                                                                                    {
                                                                                                        TB_TREE dupTree_step11 = new TB_TREE();

                                                                                                        dupTree_step11.title = sublvls11[k].title;
                                                                                                        dupTree_step11.descripcion = sublvls11[k].descripcion;
                                                                                                        dupTree_step11.lazy = sublvls11[k].lazy;
                                                                                                        dupTree_step11.parentId = dupTree_step10.id;
                                                                                                        dupTree_step11.proyectoId = py.ProyectoID;
                                                                                                        dupTree_step11.fechaCreacion = DateTime.Now;

                                                                                                        var countlvl11 = nda.InserNewLevel(dupTree_step11);
                                                                                                        

                                                                                                        //----------- duplicar estilos
                                                                                                        var step11styles = ndas.GetAllStylesFromLevel(sublvls11[k].id, "").ToList();
                                                                                                        if (step11styles.Count > 0)
                                                                                                        {
                                                                                                            for (int s = 0; s <= step11styles.Count - 1; s++)
                                                                                                            {
                                                                                                                TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                                                                sto.NivelID = dupTree_step11.id;
                                                                                                                sto.campo = step11styles[s].campo;
                                                                                                                sto.style = step11styles[s].style;

                                                                                                                var modelstyle = ndas.InsertNivelStyle(sto);
                                                                                                                
                                                                                                            }
                                                                                                        }

                                                                                                        //----------- duplicar info
                                                                                                        var step11info = ndai.GetNivelInfo(sublvls11[k].id).ToList();
                                                                                                        if (step11info.Count > 0)
                                                                                                        {
                                                                                                            for (int ii = 0; ii <= step11info.Count - 1; ii++)
                                                                                                            {
                                                                                                                TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                                                                info.NivelID = dupTree_step11.id;
                                                                                                                info.Informacion = step11info[ii].Informacion;
                                                                                                                info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                                                                info.FechaIngreso = DateTime.Now;

                                                                                                                var modelinfo = ndai.InsertNivelInfo(info);
                                                                                                                
                                                                                                            }
                                                                                                        }


                                                                                                        //------------ doceavo loop...
                                                                                                        List<TB_TREE> sublvls12 = new List<TB_TREE>();
                                                                                                        sublvls12 = nda.GetSubLvl(sublvls11[k].id).ToList();

                                                                                                        if (sublvls12.Count > 0)
                                                                                                        {
                                                                                                            for (int m = 0; m <= sublvls12.Count - 1; m++)
                                                                                                            {
                                                                                                                TB_TREE dupTree_step12 = new TB_TREE();

                                                                                                                dupTree_step12.title = sublvls12[m].title;
                                                                                                                dupTree_step12.descripcion = sublvls12[m].descripcion;
                                                                                                                dupTree_step12.lazy = sublvls12[m].lazy;
                                                                                                                dupTree_step12.parentId = dupTree_step11.id;
                                                                                                                dupTree_step12.proyectoId = py.ProyectoID;
                                                                                                                dupTree_step12.fechaCreacion = DateTime.Now;

                                                                                                                var countlvl12 = nda.InserNewLevel(dupTree_step12);
                                                                                                                


                                                                                                                //----------- duplicar estilos
                                                                                                                var step12styles = ndas.GetAllStylesFromLevel(sublvls12[m].id, "").ToList();
                                                                                                                if (step12styles.Count > 0)
                                                                                                                {
                                                                                                                    for (int s = 0; s <= step12styles.Count - 1; s++)
                                                                                                                    {
                                                                                                                        TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                                                                        sto.NivelID = dupTree_step12.id;
                                                                                                                        sto.campo = step12styles[s].campo;
                                                                                                                        sto.style = step12styles[s].style;

                                                                                                                        var modelstyle = ndas.InsertNivelStyle(sto);
                                                                                                                        
                                                                                                                    }
                                                                                                                }

                                                                                                                //----------- duplicar info
                                                                                                                var step12info = ndai.GetNivelInfo(sublvls12[m].id).ToList();
                                                                                                                if (step12info.Count > 0)
                                                                                                                {
                                                                                                                    for (int ii = 0; ii <= step11info.Count - 1; ii++)
                                                                                                                    {
                                                                                                                        TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                                                                        info.NivelID = dupTree_step12.id;
                                                                                                                        info.Informacion = step12info[ii].Informacion;
                                                                                                                        info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                                                                        info.FechaIngreso = DateTime.Now;

                                                                                                                        var modelinfo = ndai.InsertNivelInfo(info);
                                                                                                                        
                                                                                                                    }
                                                                                                                }


                                                                                                                //------------ treceabo loop...
                                                                                                                List<TB_TREE> sublvls13 = new List<TB_TREE>();
                                                                                                                sublvls13 = nda.GetSubLvl(sublvls12[m].id).ToList();

                                                                                                                if (sublvls13.Count > 0)
                                                                                                                {
                                                                                                                    for (int n = 0; n <= sublvls13.Count - 1; n++)
                                                                                                                    {
                                                                                                                        TB_TREE dupTree_step13 = new TB_TREE();

                                                                                                                        dupTree_step13.title = sublvls13[n].title;
                                                                                                                        dupTree_step13.descripcion = sublvls13[n].descripcion;
                                                                                                                        dupTree_step13.lazy = sublvls13[n].lazy;
                                                                                                                        dupTree_step13.parentId = dupTree_step12.id;
                                                                                                                        dupTree_step13.proyectoId = py.ProyectoID;
                                                                                                                        dupTree_step13.fechaCreacion = DateTime.Now;

                                                                                                                        var countlvl13 = nda.InserNewLevel(dupTree_step13);
                                                                                                                        

                                                                                                                        //----------- duplicar estilos
                                                                                                                        var step13styles = ndas.GetAllStylesFromLevel(sublvls13[n].id, "").ToList();
                                                                                                                        if (step13styles.Count > 0)
                                                                                                                        {
                                                                                                                            for (int s = 0; s <= step13styles.Count - 1; s++)
                                                                                                                            {
                                                                                                                                TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                                                                                sto.NivelID = dupTree_step13.id;
                                                                                                                                sto.campo = step13styles[s].campo;
                                                                                                                                sto.style = step13styles[s].style;

                                                                                                                                var modelstyle = ndas.InsertNivelStyle(sto);
                                                                                                                                
                                                                                                                            }
                                                                                                                        }

                                                                                                                        //----------- duplicar info
                                                                                                                        var step13info = ndai.GetNivelInfo(sublvls13[n].id).ToList();
                                                                                                                        if (step13info.Count > 0)
                                                                                                                        {
                                                                                                                            for (int ii = 0; ii <= step13info.Count - 1; ii++)
                                                                                                                            {
                                                                                                                                TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                                                                                info.NivelID = dupTree_step13.id;
                                                                                                                                info.Informacion = step13info[ii].Informacion;
                                                                                                                                info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                                                                                info.FechaIngreso = DateTime.Now;

                                                                                                                                var modelinfo = ndai.InsertNivelInfo(info);
                                                                                                                                
                                                                                                                            }
                                                                                                                        }

                                                                                                                        //------------ catorce loop...
                                                                                                                        List<TB_TREE> sublvls14 = new List<TB_TREE>();
                                                                                                                        sublvls14 = nda.GetSubLvl(sublvls13[n].id).ToList();

                                                                                                                        if (sublvls14.Count > 0)
                                                                                                                        {
                                                                                                                            for (int o = 0; o <= sublvls14.Count - 1; o++)
                                                                                                                            {
                                                                                                                                TB_TREE dupTree_step14 = new TB_TREE();

                                                                                                                                dupTree_step14.title = sublvls14[o].title;
                                                                                                                                dupTree_step14.descripcion = sublvls14[o].descripcion;
                                                                                                                                dupTree_step14.lazy = sublvls14[o].lazy;
                                                                                                                                dupTree_step14.parentId = dupTree_step13.id;
                                                                                                                                dupTree_step14.proyectoId = py.ProyectoID;
                                                                                                                                dupTree_step14.fechaCreacion = DateTime.Now;

                                                                                                                                var countlvl14 = nda.InserNewLevel(dupTree_step14);
                                                                                                                                

                                                                                                                                //----------- duplicar estilos
                                                                                                                                var step14styles = ndas.GetAllStylesFromLevel(sublvls14[o].id, "").ToList();
                                                                                                                                if (step14styles.Count > 0)
                                                                                                                                {
                                                                                                                                    for (int s = 0; s <= step14styles.Count - 1; s++)
                                                                                                                                    {
                                                                                                                                        TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                                                                                        sto.NivelID = dupTree_step14.id;
                                                                                                                                        sto.campo = step14styles[s].campo;
                                                                                                                                        sto.style = step14styles[s].style;

                                                                                                                                        var modelstyle = ndas.InsertNivelStyle(sto);
                                                                                                                                        
                                                                                                                                    }
                                                                                                                                }

                                                                                                                                //----------- duplicar info
                                                                                                                                var step14info = ndai.GetNivelInfo(sublvls14[o].id).ToList();
                                                                                                                                if (step14info.Count > 0)
                                                                                                                                {
                                                                                                                                    for (int ii = 0; ii <= step14info.Count - 1; ii++)
                                                                                                                                    {
                                                                                                                                        TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                                                                                        info.NivelID = dupTree_step14.id;
                                                                                                                                        info.Informacion = step14info[ii].Informacion;
                                                                                                                                        info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                                                                                        info.FechaIngreso = DateTime.Now;

                                                                                                                                        var modelinfo = ndai.InsertNivelInfo(info);
                                                                                                                                        
                                                                                                                                    }
                                                                                                                                }


                                                                                                                                //------------ quince loop...
                                                                                                                                List<TB_TREE> sublvls15 = new List<TB_TREE>();
                                                                                                                                sublvls15 = nda.GetSubLvl(sublvls14[o].id).ToList();

                                                                                                                                if (sublvls15.Count > 0)
                                                                                                                                {
                                                                                                                                    for (int p = 0; p <= sublvls15.Count - 1; p++)
                                                                                                                                    {
                                                                                                                                        TB_TREE dupTree_step15 = new TB_TREE();

                                                                                                                                        dupTree_step15.title = sublvls15[p].title;
                                                                                                                                        dupTree_step15.descripcion = sublvls15[p].descripcion;
                                                                                                                                        dupTree_step15.lazy = sublvls15[p].lazy;
                                                                                                                                        dupTree_step15.parentId = dupTree_step14.id;
                                                                                                                                        dupTree_step15.proyectoId = py.ProyectoID;
                                                                                                                                        dupTree_step15.fechaCreacion = DateTime.Now;

                                                                                                                                        var countlvl15 = nda.InserNewLevel(dupTree_step15);
                                                                                                                                        


                                                                                                                                        //----------- duplicar estilos
                                                                                                                                        var step15styles = ndas.GetAllStylesFromLevel(sublvls15[p].id, "").ToList();
                                                                                                                                        if (step15styles.Count > 0)
                                                                                                                                        {
                                                                                                                                            for (int s = 0; s <= step15styles.Count - 1; s++)
                                                                                                                                            {
                                                                                                                                                TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                                                                                                sto.NivelID = dupTree_step15.id;
                                                                                                                                                sto.campo = step15styles[s].campo;
                                                                                                                                                sto.style = step15styles[s].style;

                                                                                                                                                var modelstyle = ndas.InsertNivelStyle(sto);
                                                                                                                                                
                                                                                                                                            }
                                                                                                                                        }

                                                                                                                                        //----------- duplicar info
                                                                                                                                        var step15info = ndai.GetNivelInfo(sublvls15[p].id).ToList();
                                                                                                                                        if (step15info.Count > 0)
                                                                                                                                        {
                                                                                                                                            for (int ii = 0; ii <= step15info.Count - 1; ii++)
                                                                                                                                            {
                                                                                                                                                TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                                                                                                info.NivelID = dupTree_step15.id;
                                                                                                                                                info.Informacion = step15info[ii].Informacion;
                                                                                                                                                info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                                                                                                info.FechaIngreso = DateTime.Now;

                                                                                                                                                var modelinfo = ndai.InsertNivelInfo(info);
                                                                                                                                                
                                                                                                                                            }
                                                                                                                                        }

                                                                                                                                        //------------ dieciseis loop...
                                                                                                                                        List<TB_TREE> sublvls16 = new List<TB_TREE>();
                                                                                                                                        sublvls16 = nda.GetSubLvl(sublvls15[p].id).ToList();

                                                                                                                                        if (sublvls16.Count > 0)
                                                                                                                                        {
                                                                                                                                            for (int q = 0; q <= sublvls16.Count - 1; q++)
                                                                                                                                            {
                                                                                                                                                TB_TREE dupTree_step16 = new TB_TREE();

                                                                                                                                                dupTree_step16.title = sublvls16[q].title;
                                                                                                                                                dupTree_step16.descripcion = sublvls16[q].descripcion;
                                                                                                                                                dupTree_step16.lazy = sublvls16[q].lazy;
                                                                                                                                                dupTree_step16.parentId = dupTree_step15.id;
                                                                                                                                                dupTree_step16.proyectoId = py.ProyectoID;
                                                                                                                                                dupTree_step16.fechaCreacion = DateTime.Now;

                                                                                                                                                var countlvl16 = nda.InserNewLevel(dupTree_step16);
                                                                                                                                                

                                                                                                                                                //----------- duplicar estilos
                                                                                                                                                var step16styles = ndas.GetAllStylesFromLevel(sublvls16[q].id, "").ToList();
                                                                                                                                                if (step16styles.Count > 0)
                                                                                                                                                {
                                                                                                                                                    for (int s = 0; s <= step16styles.Count - 1; s++)
                                                                                                                                                    {
                                                                                                                                                        TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                                                                                                        sto.NivelID = dupTree_step16.id;
                                                                                                                                                        sto.campo = step16styles[s].campo;
                                                                                                                                                        sto.style = step16styles[s].style;

                                                                                                                                                        var modelstyle = ndas.InsertNivelStyle(sto);
                                                                                                                                                        
                                                                                                                                                    }
                                                                                                                                                }// colocar debajo un nuevo nivel si se requiere.

                                                                                                                                                //----------- duplicar info
                                                                                                                                                var step16info = ndai.GetNivelInfo(sublvls16[q].id).ToList();
                                                                                                                                                if (step16info.Count > 0)
                                                                                                                                                {
                                                                                                                                                    for (int ii = 0; ii <= step16info.Count - 1; ii++)
                                                                                                                                                    {
                                                                                                                                                        TB_NIVEL_INFO info = new TB_NIVEL_INFO();

                                                                                                                                                        info.NivelID = dupTree_step16.id;
                                                                                                                                                        info.Informacion = step16info[ii].Informacion;
                                                                                                                                                        info.Usuario = user.Result.UsuarioNombreCompleto;
                                                                                                                                                        info.FechaIngreso = DateTime.Now;

                                                                                                                                                        var modelinfo = ndai.InsertNivelInfo(info);
                                                                                                                                                        
                                                                                                                                                    }
                                                                                                                                                }

                                                                                                                                                count = count + countlvl16;
                                                                                                                                            }
                                                                                                                                        }

                                                                                                                                        count = count + countlvl15;
                                                                                                                                    }
                                                                                                                                }
                                                                                                                                count = count + countlvl14;
                                                                                                                            }
                                                                                                                        }
                                                                                                                        count = count + countlvl13;
                                                                                                                    }
                                                                                                                }
                                                                                                                count = count + countlvl12;
                                                                                                            }
                                                                                                        }
                                                                                                        count = count + countlvl11;
                                                                                                    }
                                                                                                }
                                                                                                count = count + countlvl10;
                                                                                            }
                                                                                        }
                                                                                        count = count + countlvl9;
                                                                                    }
                                                                                }
                                                                                count = count + countlvl8;
                                                                            }
                                                                        }
                                                                        count = count + countlvl7;
                                                                    }
                                                                }
                                                                count = count + countlvl6;
                                                            }
                                                        }
                                                        count = count + countlvl5;
                                                    }
                                                }
                                                count = count + countlvl4;
                                            }
                                        }
                                        count = count + countlvl3;
                                    }
                                }
                                count = count + countlvl2;
                            }
                        }
                        count = count + countlvl;
                    }
                }

                if (count == treeTotalCount)
                {
                    jres = new { msg = "Se duplicaron correctamente los niveles", registros = count, total = treeTotalCount };
                } else if (count < treeTotalCount)
                {
                    jres = new { msg = "Falto duplicar algunos niveles", registros = count, total = treeTotalCount };
                } else if (count > treeTotalCount)
                {
                    jres = new { msg = "Excepcion no controlada", registros = count, total = treeTotalCount };
                }

                return Json(jres);
            }
            catch (Exception e)
            {
                result = e.Message;
                var jres = new { msg = "Hubo el siguiente error: " + result + " en el intento", registros = count, total = 0 };
                return Json(jres);
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
