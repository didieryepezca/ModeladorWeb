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


        //---------------------------------TREE VIEW REAL
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

        public List<TB_NIVEL_INFO> funGetInfoFromDB(int lvlId)
        {
            var da = new NivelInfoDA();

            //Un momento por favor xD
            System.Threading.Thread.Sleep(1000);
            var info = da.GetNivelInfo(lvlId).ToList();

            return info;
        }
        //---------------------------------TREE VIEW REAL




        //---------------------------------TREE VIEW ANTERIOR
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
