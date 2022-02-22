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
using Newtonsoft.Json;

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
            var allProyectos = daPer.getProyectosWithPermisos(userId);

            if (allProyectos.ToList().Count > 0)
            {
                var firstPy = allProyectos?.First();
                var firstPyID = firstPy?.ProyectoID;
                ViewBag.firstPyID = firstPyID;
                ViewBag.permiso = firstPy.Permiso;

                return View(allProyectos);
            }
            else
            {
                return RedirectToAction("VerProyectos", "Proyectos", new { nullpys = "emptyProjects" });
            }
        }
        public List<TB_TREE> funGetLvlMaster()
        {
            var da = new NivelDA();
            //Un momento por favor xD
            System.Threading.Thread.Sleep(2000);
            var master = da.GetLvl().ToList();
            return master;
        }

        public List<TB_TREE> funGetLvlFromPyUsuario(int idProyecto)
        {
            var da = new NivelDA();
            //Un momento por favor xD
            System.Threading.Thread.Sleep(2000);
            var pyUsuario = da.GetLvlFromPyUsuario(idProyecto).ToList();
            return pyUsuario;
        }

        public JsonResult funGetSubLvls(int parent)
        {
            var da = new NivelDA();
            var subMenus = da.GetSubLvl(parent);
            return Json(subMenus);
        }

        public int funInsertLvl(string titulo, string descripcion, int parent, int projectId)
        {
            var result = "0";
            var nda = new NivelDA();
            var ndas = new TreeStylesDA();

            try
            {
                TB_TREE t = new TB_TREE();

                t.title = titulo;
                t.descripcion = descripcion;
                t.lazy = true;
                t.parentId = parent;
                t.proyectoId = projectId;
                t.fechaCreacion = DateTime.Now;

                var modelcount = nda.InserNewLevel(t);

                //aplicando el estilo negrita a todos los campos de titulos nuevos.
                TB_TREE_STYLE ts = new TB_TREE_STYLE();

                ts.NivelID = t.id;
                ts.campo = "titulo";
                ts.style = "bold";

                var modelstyle = ndas.InsertNivelStyle(ts);

                return modelcount + modelstyle;
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
            var daPer = new HomeDA();
            System.Threading.Thread.Sleep(10); // 10 milisegundos de espera
            var totalInserts = 0;
            try
            {
                for (int i = 1; i <= cantidad; i++)
                {
                    TB_TREE t = new TB_TREE();

                    t.title = i + "." + " " + nombreBase + " " + i;
                    t.descripcion = "Descripcion " + i;
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

        public int funUpdateLvlDescriptionFromChilds(int Id, string descriptionfromchilds)
        {
            var result = "0";
            var cDa = new NivelDA();
            try
            {
                var modelcount = cDa.UpdateLvlDescriptionFromChilds(Id, descriptionfromchilds);
                return modelcount;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public int funUpdateLvlNameDescription(int Id, string title, string description)
        {
            var result = "0";
            var cDa = new NivelDA();
            try
            {
                var modelcount = cDa.UpdateLvlTitleAndDescription(Id, title, description);
                return modelcount;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public int funUpdateLvlParent(int id, int newparentId)
        {
            var result = "0";
            var cDa = new NivelDA();
            try
            {
                var modelcount = cDa.UpdateLvlParent(id, newparentId);
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

            var sda = new TreeStylesDA();

            try
            {
                var modelcount = da.DeleteLevel(Id);

                //---- > delete styles 
                List<TB_TREE_STYLE> styles = new List<TB_TREE_STYLE>();
                styles = sda.GetAllStylesFromLevel(Id, "").ToList();
                for (int s = 0; s < styles.Count; s++)
                {
                    sda.deleteNivelStyle(styles[s].StyleID);
                }

                //---
                List<TB_TREE> sublevelsToDelete = new List<TB_TREE>();
                sublevelsToDelete = da.GetSubLvl(Id).ToList();

                for (int i = 0; i < sublevelsToDelete.Count; i++)
                {
                    try
                    {
                        da.DeleteLevel(sublevelsToDelete[i].id);

                        //---- > delete sub level styles 
                        List<TB_TREE_STYLE> sublevelstyles = new List<TB_TREE_STYLE>();
                        sublevelstyles = sda.GetAllStylesFromLevel(sublevelsToDelete[i].id, "").ToList();
                        for (int s = 0; s < sublevelstyles.Count; s++)
                        {
                            sda.deleteNivelStyle(sublevelstyles[s].StyleID);
                        }
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
            System.Threading.Thread.Sleep(100);
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

        public int funDuplicateLevels(int vId, int vParentId, int projectId, int cantidad)
        {
            var result = "0";
            var nda = new NivelDA();

            var ndas = new TreeStylesDA();

            var count = 0;
            try
            {
                System.Threading.Thread.Sleep(100); //100 milisegundos de espera.

                for (int qty = 1; qty <= cantidad; qty++)
                {
                    TB_TREE lvl = new TB_TREE();
                    lvl = nda.GetLevelToDuplicate(vId);

                    TB_TREE firstInsert = new TB_TREE();
                    firstInsert.title = lvl.title;
                    firstInsert.descripcion = lvl.descripcion;
                    firstInsert.lazy = lvl.lazy;
                    firstInsert.parentId = vParentId;
                    firstInsert.proyectoId = projectId;
                    firstInsert.fechaCreacion = DateTime.Now;

                    var finsert = nda.InserNewLevel(firstInsert);
                    count = count + finsert;

                    //----------- duplicar estilos
                    var stylesfirst = ndas.GetAllStylesFromLevel(lvl.id, "").ToList();
                    if (stylesfirst.Count > 0)
                    {
                        for (int s = 0; s <= stylesfirst.Count - 1; s++)
                        {
                            TB_TREE_STYLE sto = new TB_TREE_STYLE();

                            sto.NivelID = firstInsert.id;
                            sto.campo = stylesfirst[s].campo;
                            sto.style = stylesfirst[s].style;

                            var modelstyle = ndas.InsertNivelStyle(sto);
                        }
                    }

                    //------------ primer loop del primer nivel...
                    List<TB_TREE> sublvls = new List<TB_TREE>();
                    sublvls = nda.GetSubLvl(lvl.id).ToList();

                    if (sublvls.Count > 0)
                    {
                        for (int a = 0; a <= sublvls.Count - 1; a++)
                        {
                            TB_TREE dupTree_step1 = new TB_TREE();

                            dupTree_step1.title = sublvls[a].title;
                            dupTree_step1.descripcion = sublvls[a].descripcion;
                            dupTree_step1.lazy = sublvls[a].lazy;
                            dupTree_step1.parentId = firstInsert.id;
                            dupTree_step1.proyectoId = projectId;
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
                                    dupTree_step2.proyectoId = projectId;
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
                                            dupTree_step3.proyectoId = projectId;
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
                                                    dupTree_step4.proyectoId = projectId;
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
                                                            dupTree_step5.proyectoId = projectId;
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
                                                                    dupTree_step6.proyectoId = projectId;
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
                                                                            dupTree_step7.proyectoId = projectId;
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
                                                                                    dupTree_step8.proyectoId = projectId;
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
                                                                                            dupTree_step9.proyectoId = projectId;
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
                                                                                                    dupTree_step10.proyectoId = projectId;
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
                                                                                                            dupTree_step11.proyectoId = projectId;
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
                                                                                                                    dupTree_step12.proyectoId = projectId;
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
                                                                                                                            dupTree_step13.proyectoId = projectId;
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
                                                                                                                                    dupTree_step14.proyectoId = projectId;
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
                                                                                                                                            dupTree_step15.proyectoId = projectId;
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
                                                                                                                                            }// colocar debajo un nuevo nivel si se requiere.


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
                                                                                                                                                    dupTree_step16.proyectoId = projectId;
                                                                                                                                                    dupTree_step16.fechaCreacion = DateTime.Now;

                                                                                                                                                    var countlvl16 = nda.InserNewLevel(dupTree_step16);

                                                                                                                                                    //----------- duplicar estilos
                                                                                                                                                    var step16styles = ndas.GetAllStylesFromLevel(sublvls16[q].id, "").ToList();
                                                                                                                                                    if (step16styles.Count > 0)
                                                                                                                                                    {
                                                                                                                                                        for (int s = 0; s <= step16styles.Count - 1; s++)
                                                                                                                                                        {
                                                                                                                                                            TB_TREE_STYLE sto = new TB_TREE_STYLE();

                                                                                                                                                            sto.NivelID = dupTree_step15.id;
                                                                                                                                                            sto.campo = step16styles[s].campo;
                                                                                                                                                            sto.style = step16styles[s].style;

                                                                                                                                                            var modelstyle = ndas.InsertNivelStyle(sto);
                                                                                                                                                        }
                                                                                                                                                    }// colocar debajo un nuevo nivel si se requiere.


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
                }
                return count;
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
            System.Threading.Thread.Sleep(100);
            var estilos = da.GetAllStylesFromLevel(nivelID, "").ToList();
            return estilos;
        }

        public int funInsertLvlStyle(int nivelID, string style, string campo)
        {
            var result = "0";
            var da = new TreeStylesDA();
            try
            {
                TB_TREE_STYLE stylesfound_i = new TB_TREE_STYLE();
                stylesfound_i = da.GetAllStylesFromLevel(nivelID, campo).Where(r => r.style == style && r.campo == campo).FirstOrDefault();

                if (stylesfound_i?.StyleID == null)
                {
                    TB_TREE_STYLE t = new TB_TREE_STYLE();

                    t.NivelID = nivelID;
                    t.campo = campo;
                    t.style = style;

                    var modelcount = da.InsertNivelStyle(t);
                    return modelcount;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public int funRemoveColorsAndSizes(int nivelID)
        {

            var da = new TreeStylesDA();

            int remove = 0;

            string[] arrayCampos = { "titulo", "descripcion" };

            foreach (string campo in arrayCampos)
            {
                string[] arrayColorsNSizes = { "silver", "lightslategray", "grey", "dimgrey", "dark", "#206bc4"
                                                , "#4299e1"
                                                , "#4263eb"
                                                , "#ae3ec9"
                                                , "#d6336c"
                                                , "#d63939"
                                                , "#f76707"
                                                , "#f59f00"
                                                , "#74b816"
                                                    , "8px", "10px", "12px", "14px", "16px"};

                foreach (string estilo in arrayColorsNSizes)
                {
                    int removecount = 0;
                    TB_TREE_STYLE stylesfound_m = new TB_TREE_STYLE();
                    stylesfound_m = da.GetAllStylesFromLevel(nivelID, campo).Where(r => r.style == estilo && r.campo == campo).FirstOrDefault();

                    if (stylesfound_m != null)
                    {
                        removecount = da.deleteNivelStyle(stylesfound_m.StyleID);
                    }
                    remove = remove + removecount;
                }
            }
            return remove;
        }

        public int funDeleteStyle(int nivelID, string style, string campo)
        {
            var result = "0";
            var da = new TreeStylesDA();

            var modelcount = 0;
            try
            {
                TB_TREE_STYLE styleToDelete = new TB_TREE_STYLE();
                styleToDelete = da.GetAllStylesFromLevel(nivelID, campo).Where(r => r.style == style && r.campo == campo).FirstOrDefault();

                if (styleToDelete != null)
                {
                    modelcount = da.deleteNivelStyle(styleToDelete.StyleID);
                }
                return modelcount;
            }
            catch (Exception se)
            {
                result = se.Message;
                return 0;
            }
        }

        class CaracteristicaEquipo
        {
            public int idC;
            public int idE;
        }
        public int funInsertEquiposToTreeInDB(string datos, int idPadre, int projectId)
        {
            var result = "0";
            var daE = new EquipoDA();
            var daC = new EquipoCaracteristicaDA();
            var dat = new NivelDA();
            var dai = new NivelInfoDA();

            var modelcount = 0;

            try
            {
                //deserializamos una lista de objetos(idCaracteristica, idEquipo) para insertarlos.
                var caracteristicas = JsonConvert.DeserializeObject<List<CaracteristicaEquipo>>(datos);

                //obtenemos los ids de los equipos distintos.
                List<int> equiposDistintos = caracteristicas.Select(o => o.idE).Distinct().ToList();
                List<int> caracDistintas = caracteristicas.Select(o => o.idC).Distinct().ToList();

                foreach (int idEquipo in equiposDistintos)
                {
                    TB_EQUIPO e = new TB_EQUIPO();
                    e = daE.getEquipo(idEquipo);

                    TB_TREE lvlFoundEquipo = new TB_TREE();
                    lvlFoundEquipo = dat.getInfoLevelBeforeDuplicate(e.NOMBRE_EQUIPO, projectId, idPadre);

                    int idEquipoParent = 0;

                    TB_TREE te = new TB_TREE();

                    te.title = e.NOMBRE_EQUIPO;
                    te.descripcion = null;
                    te.lazy = true;
                    te.parentId = idPadre;
                    te.proyectoId = projectId;
                    te.fechaCreacion = DateTime.Now;

                    if (lvlFoundEquipo == null)
                    {
                        modelcount = dat.InserNewLevel(te);
                        modelcount = modelcount + 1;
                    }
                    else {
                        idEquipoParent = lvlFoundEquipo.id;
                    }

                    TB_NIVEL_INFO infoe = new TB_NIVEL_INFO();

                    if (lvlFoundEquipo == null) { infoe.NivelID = te.id; }
                    else { infoe.NivelID = lvlFoundEquipo.id; }

                    infoe.Informacion = Convert.ToString(e.NRC_EQUIPO);
                    infoe.Usuario = "APLICACION";
                    infoe.FechaIngreso = DateTime.Now;

                    if (lvlFoundEquipo == null)
                    {
                        modelcount = dai.InsertNivelInfo(infoe);
                        modelcount = modelcount + 1;
                    }

                    foreach (int idCar in caracDistintas)
                    {
                        TB_EQUIPO_CARACTERISTICA carEncontrada = new TB_EQUIPO_CARACTERISTICA();
                        //obtenemos las caracteristicas segun los ID que enviamos en AJAX.
                        carEncontrada = daC.GetEquipoCaracteristicas(e.ID_EQUIPO).Where(r => r.ID_EQUIPO_C == idCar).FirstOrDefault();
                        if (carEncontrada != null)
                        {
                            TB_TREE lvlFoundCar = new TB_TREE();
                            lvlFoundCar = dat.getInfoLevelBeforeDuplicate(carEncontrada.NOMBRE_CARACTERISTICA, projectId, idEquipoParent);                           

                            TB_TREE tc = new TB_TREE();

                            tc.title = carEncontrada.NOMBRE_CARACTERISTICA;
                            tc.descripcion = null;
                            tc.lazy = true;

                            if (lvlFoundCar == null && te.id == 0) { tc.parentId = idEquipoParent; }
                            else if (lvlFoundCar == null ) { tc.parentId = te.id; }
                           

                            tc.proyectoId = projectId;
                            tc.fechaCreacion = DateTime.Now;

                            if (lvlFoundCar == null)
                            {
                                modelcount = dat.InserNewLevel(tc);
                                modelcount = modelcount + 1;
                            }

                            //---------- Si se quiere agregar mas datos a la grilla tendrá que contarse la cantidad de columnas
                            //---------- y hacer la cantidad de Inserts necesarios a TB_NIVEL_INFO con el mismo ID basados en el conteo de columnas.
                            TB_NIVEL_INFO infoc = new TB_NIVEL_INFO();

                            if (lvlFoundCar == null && te.id == 0) { 
                                tc.parentId = idEquipoParent; 
                                infoc.NivelID = tc.id; 
                            } else if (lvlFoundCar == null ) { infoc.NivelID = tc.id; }                          

                            infoc.Informacion = Convert.ToString(carEncontrada.NRC_CARACTERISTICA);
                            infoc.Usuario = "APLICACION";
                            infoc.FechaIngreso = DateTime.Now;

                            if (lvlFoundCar == null)
                            {
                                modelcount = dai.InsertNivelInfo(infoc);
                                modelcount = modelcount + 1;
                            }
                            //----------------------------->
                        }
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

        //---------------------------------TREE VIEW REAL        

    }
}
