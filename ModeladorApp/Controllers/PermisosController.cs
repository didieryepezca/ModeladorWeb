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
        public IActionResult AdminPermisos()
        {
            var user = userManager.GetUserAsync(User);
            var userId = user.Result.Id;

            var da = new PermisosDA();

            var permisos = da.getPermisosWithProyectos(userId);

            return View(permisos);
        }


    }
}
