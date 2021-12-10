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
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<HomeController> _logger;       

        public HomeController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            this.userManager = userManager;
            _logger = logger;            
        }
        
        //---------------------------------TREE VIEW REAL
        [Authorize]
        public IActionResult Arbol()
        {
            var user = userManager.GetUserAsync(User);
            var userId = user.Result.Id;

            var daPer = new HomeDA();
            var proyectos = daPer.getProyectosWithPermisos(userId);

            return View(proyectos);
        }
        public List<TB_TREE> funGetLvl()
        {
            var da = new NivelDA();

            //Un momento por favor xD
            System.Threading.Thread.Sleep(2500);
            var master = da.GetLvl().ToList();

            return master;
        }

        public List<TB_TREE> funGetLvlFromPyUsuario(int idProyecto)
        {
            var da = new NivelDA();

            //Un momento por favor xD
            System.Threading.Thread.Sleep(2500);
            var pyUsuario = da.GetLvlFromPyUsuario(idProyecto).ToList();

            return pyUsuario;
        }

        public JsonResult funGetSubLvls(int parent)
        {
            var da = new NivelDA();

            System.Threading.Thread.Sleep(1500);
            var subMenus = da.GetSubLvl(parent);

            return Json(subMenus);
        }

        public int funInsertLvl(string titulo, int parent, int projectId)
        {
            var result = "0";
            var nda = new NivelDA();

            try
            {
                TB_TREE t = new TB_TREE();

                t.title = titulo;
                t.lazy = true;
                t.parentId = parent;
                t.proyectoId = projectId;
                t.fechaCreacion = DateTime.Now;
                
                var modelcount = nda.InserNewLevel(t);

                return modelcount;
            }
            catch (Exception e)
            {

                result = e.Message;
                return 0;
            }
        }

        public int funInsertNLvls(int cantidad, string nombreBase, int parent, int projectID)
        {
            var result = "0";
            var nda = new NivelDA();

            var totalInserts = 0;
            try
            {
                for (int i = 1; i <= cantidad; i++) { 

                    TB_TREE t = new TB_TREE();
                    
                    t.title = i+"."+" "+ nombreBase + " " + i;
                    t.lazy = true;
                    t.parentId = parent;
                    t.proyectoId = projectID;
                    t.fechaCreacion = DateTime.Now;

                    var modelcount = nda.InserNewLevel(t);
                    totalInserts = totalInserts + modelcount;
                }
                return totalInserts;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }



        public int funUpdateLvlName(int Id, string nombre)
        {
            var result = "0";
            var cDa = new NivelDA();
            try
            {
                var modelcount = cDa.UpdateLvlName(Id, nombre);
                return modelcount;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public int funDeleteLvlAndSublvls(int Id)
        {
            var result = "0";
            var da = new NivelDA();
            try
            {
                var modelcount = da.DeleteLevel(Id);
                List<TB_TREE> sublevelsToDelete = new List<TB_TREE>();
                sublevelsToDelete = da.GetSubLvl(Id).ToList();

                for (int i = 0; i < sublevelsToDelete.Count; i++)
                {
                    try
                    {
                        da.DeleteLevel(sublevelsToDelete[i].id);                       
                    }
                    catch (Exception fe)
                    {
                        result = fe.Message;
                        Console.WriteLine(result);
                    }
                }                
                return modelcount;
            }
            catch (Exception se)
            {
                result = se.Message;
                return 0;
            }
        }


        public List<TB_NIVEL_INFO> funGetInfoFromDB(int lvlId)
        {
            var da = new NivelInfoDA();

            //Un momento por favor xD
            System.Threading.Thread.Sleep(1000);
            var info = da.GetNivelInfo(lvlId).ToList();

            return info;
        }

        public int funInsertInfo(int idLvl, string info)
        {
            var result = "0";
            var nda = new NivelInfoDA();
            var user = userManager.GetUserAsync(User);
            var userName = user.Result.UsuarioNombreCompleto;
            try
            {
                TB_NIVEL_INFO t = new TB_NIVEL_INFO();

                t.NivelID = idLvl;
                t.Informacion = info;
                t.Usuario = userName;
                t.FechaIngreso = DateTime.Now;               

                nda.InsertNivelInfo(t);

                var infoId = t.InfoID;

                return infoId;
            }
            catch (Exception e)
            {

                result = e.Message;
                return 0;
            }
        }

        public int funUpdateInfo(int id, string informacion)
        {
            var user = userManager.GetUserAsync(User);
            var userName = user.Result.UsuarioNombreCompleto;

            var result = "0";
            var da = new NivelInfoDA();
            try
            {
                var modelcount = da.UpdateNivelInfo(id, userName, informacion);
                return modelcount;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public List<TB_NIVEL_COLUMN_TITLES> funGetColumnTitles(int idProyecto)
        {
            var da = new NivelTituloDA();

            //Un momento por favor xD
            System.Threading.Thread.Sleep(2500);
            var titles = da.GetNivelTitulosByIdProyecto(idProyecto).ToList();

            return titles;
        }


        public int funInsertTitulo(int proyectoId, string title)
        {
            var result = "0";
            var nda = new NivelTituloDA();
            var user = userManager.GetUserAsync(User);
            var userName = user.Result.UsuarioNombreCompleto;
            try
            {
                TB_NIVEL_COLUMN_TITLES ct = new TB_NIVEL_COLUMN_TITLES();

                ct.proyectoID = proyectoId;
                ct.titulo = title;               

                nda.InsertColumnTitle(ct);
                var titleID = ct.TituloID;

                return titleID;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }


        public int funUpdateTitulo(int id, string title)
        {
            var user = userManager.GetUserAsync(User);
            var userName = user.Result.UsuarioNombreCompleto;

            var result = "0";
            var da = new NivelTituloDA();
            try
            {
                var modelcount = da.UpdateColumnTitle(id, title);
                return modelcount;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }


        //----------- Obtener estilos
        public List<TB_TREE_STYLE> funGetLevelStyles(int nivelID)
        {
            var da = new TreeStylesDA();
            //Un momento por favor xD
            System.Threading.Thread.Sleep(1000);
            var estilos = da.GetStylesFromLevel(nivelID).ToList();
            return estilos;
        }


        public int funInsertLvlStyle(int nivelID, string style)
        {
            var result = "0";
            var da = new TreeStylesDA();

            try
            {
                TB_TREE_STYLE stylesfound = new TB_TREE_STYLE();
                stylesfound = da.GetStylesFromLevel(nivelID).Where(r => r.style == style).FirstOrDefault();

                if (stylesfound?.StyleID == null)
                {
                    TB_TREE_STYLE t = new TB_TREE_STYLE();

                    t.NivelID = nivelID;
                    t.style = style;

                    var modelcount = da.InsertNivelStyle(t);

                    return modelcount;                                    
                }
                else {
                    return 0;
                }
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public int funDeleteStyle(int nivelID, string style)
        {
            var result = "0";
            var da = new TreeStylesDA();

            var modelcount = 0;

            try
            {                
                TB_TREE_STYLE styleToDelete = new TB_TREE_STYLE();
                styleToDelete = da.GetStylesFromLevel(nivelID).Where(r => r.style == style).FirstOrDefault();               
               
                modelcount = da.deleteNivelStyle(styleToDelete.StyleID);              

                return modelcount;
            }
            catch (Exception se)
            {
                result = se.Message;
                return 0;
            }
        }
        //---------------------------------TREE VIEW REAL



        //---------------------------------TREE VIEW ANTERIOR
        [Authorize]
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(User);
            ViewBag.usuarioId = user.Result.Id;
            var userId = user.Result.Id;

            var daPer = new HomeDA();
            var proyectos = daPer.getProyectosWithPermisos(userId);

            return View(proyectos);
        }

        public List<TB_NIVEL> funGetMaster(string mode, int parent)
        {
            var da = new NivelDA();

            //Un momento por favor xD
            System.Threading.Thread.Sleep(2500);
            var master = da.GetMaster().ToList();

            return master;
        }

        public JsonResult funGetSubNiveles(int parentId)
        {
            var da = new NivelDA();

            System.Threading.Thread.Sleep(1500);
            var subMenus = da.GetSubNiveles(parentId);

            return Json(subMenus);
        }
        //---------------------------------TREE VIEW ANTERIOR
        
    }
}
