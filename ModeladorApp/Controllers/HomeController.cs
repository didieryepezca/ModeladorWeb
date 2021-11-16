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

            var da = new ProyectoDA();

            var proyectos = da.GetProyectos();

            return View(proyectos);
        }

        public JsonResult GetSubMenu(int parentId) {

            var da = new ProyectoDA();

            //System.Threading.Thread.Sleep(5000);
            var subMenus = da.GetProyectoSubMenu(parentId);

            return Json(subMenus);
        }


        [Authorize]
        public IActionResult AdminProyectos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
