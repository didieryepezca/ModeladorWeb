﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using ModeladorApp.Models;
using ModeladorApp.Models.Entities;
using ModeladorApp.Data.DataAccess;

using System.IO;
using Excel;
using System.Data;
using Newtonsoft.Json;

namespace ModeladorApp.Controllers
{
    public class MicrobasesController : Controller
    {
        private IHostingEnvironment hostingEnv;
        private readonly UserManager<ApplicationUser> userManager;      

        public MicrobasesController(IHostingEnvironment hostingEnv, UserManager<ApplicationUser> userManager)
        {
            this.hostingEnv = hostingEnv;
            this.userManager = userManager;            
        }
        public IActionResult Administrar()
        {
            var user = userManager.GetUserAsync(User);
            ViewBag.currentUser = user.Result.UsuarioNombreCompleto;
            return View();
        }

        public JsonResult funGetAllEquipos()
        {
            var da = new EquipoDA();
            var equipos = da.GetAllEquipos();
            return Json(equipos);
        }

        public JsonResult funGetEquipoCaracteristicas(int idEquipo)
        {
            var da = new EquipoCaracteristicaDA();
            var caracteristicas = da.GetEquipoCaracteristicas(idEquipo);
            return Json(caracteristicas);
        }

        public int funInsertEquipo(string datos)
        {
            var result = "0";
            var user = userManager.GetUserAsync(User);
            var da = new EquipoDA();
            try
            {
                TB_EQUIPO equipo = JsonConvert.DeserializeObject<TB_EQUIPO>(datos);
                TB_EQUIPO e = new TB_EQUIPO();

                e.NOMBRE_EQUIPO = equipo.NOMBRE_EQUIPO;
                e.NCR_EQUIPO = equipo.NCR_EQUIPO;
                e.FECHA_REGISTRO = DateTime.Now;
                e.USUARIO = user.Result.UsuarioNombreCompleto;                

                var modelcount = da.InsertEquipo(e);              

                return modelcount;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public int funUpdateEquipo(string datos)
        {
            var result = "0";
            var cDa = new EquipoDA();

            TB_EQUIPO equipo = JsonConvert.DeserializeObject<TB_EQUIPO>(datos);
            try
            {
                var modelcount = cDa.UpdateEquipo(equipo.ID_EQUIPO, equipo.NOMBRE_EQUIPO, equipo.NCR_EQUIPO);
                return modelcount;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public int funDeleteEquipoAndCaracteristicas(int idEquipo)
        {
            var result = "0";
            var eda = new EquipoDA();
            var cda = new EquipoCaracteristicaDA();            

            try
            {
                int modelcount = 0;

                modelcount = eda.deleteEquipo(idEquipo);

                //---- > eliminar caracteristicas 
                List<TB_EQUIPO_CARACTERISTICA> caracteristicas = new List<TB_EQUIPO_CARACTERISTICA>();
                caracteristicas = cda.GetEquipoCaracteristicas(idEquipo).ToList();
                for (int c = 0; c < caracteristicas.Count; c++)
                {
                    cda.deleteCaracteristica(caracteristicas[c].ID_EQUIPO_C);
                    modelcount = modelcount + 1;
                }                
                return modelcount;
            }
            catch (Exception se)
            {
                result = se.Message;
                return 0;
            }
        }
        public int funInsertEquipoCaracteristica(string datos)
        {
            var result = "0";
            var user = userManager.GetUserAsync(User);
            var da = new EquipoCaracteristicaDA();
            try
            {
                TB_EQUIPO_CARACTERISTICA caracteristica = JsonConvert.DeserializeObject<TB_EQUIPO_CARACTERISTICA>(datos);
                TB_EQUIPO_CARACTERISTICA e = new TB_EQUIPO_CARACTERISTICA();

                e.ID_EQUIPO = caracteristica.ID_EQUIPO;
                e.NOMBRE_CARACTERISTICA = caracteristica.NOMBRE_CARACTERISTICA;
                e.NCR_CARACTERISTICA = caracteristica.NCR_CARACTERISTICA;
                e.FECHA_REGISTRO = DateTime.Now;
                e.USUARIO = user.Result.UsuarioNombreCompleto;

                var modelcount = da.InsertEquipoCaracteristica(e);

                return modelcount;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }

        public int funUpdateEquipoCaracteristica(string datos)
        {
            var result = "0";
            var cDa = new EquipoCaracteristicaDA();

            TB_EQUIPO_CARACTERISTICA caracteristica = JsonConvert.DeserializeObject<TB_EQUIPO_CARACTERISTICA>(datos);
            try
            {
                var modelcount = cDa.UpdateEquipoCaracteristica(caracteristica.ID_EQUIPO_C, 
                                                                caracteristica.NOMBRE_CARACTERISTICA, 
                                                                caracteristica.NCR_CARACTERISTICA);
                return modelcount;
            }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }
        }
        public int funDeleteCaracteristica(int idc)
        {
            var result = "0";
            var da = new EquipoCaracteristicaDA();
            var modelcount = 0;
            try
            {                
                modelcount = da.deleteCaracteristica(idc);                
                return modelcount;
            }
            catch (Exception se)
            {
                result = se.Message;
                return 0;
            }
        }

        class EquipoTemp {
            public int id_equipo;
            public string nombre;
            public decimal ncr;
            public int? id_caracteristica;
        }

        [Authorize]
        public IActionResult subirArchivo(ICollection<Microsoft.AspNetCore.Http.IFormFile> files, string observaciones)
        {
            var user = userManager.GetUserAsync(User);

            EquipoDA eda = new EquipoDA();
            EquipoCaracteristicaDA ecda = new EquipoCaracteristicaDA();

            ArchivosDA files_da = new ArchivosDA();

            int contador = 0;
            var jres = new { msg = "", registros = "" };
            var archivo = Request.Form.Files;

            if (archivo.Count() == 0)
            {
                jres = new { msg = "Debe seleccionar un archivo excel. ", registros = "" };
                return Json(jres);
            }           

            var uploads = Path.Combine(hostingEnv.WebRootPath, "uploads");

            int i = 0;          

            //string[] paths = { @"\\172.17.1.66\CarpetaUbicacionDeRed\", "CarpetaNombre" };
            //var uploads = Path.Combine(paths);

            foreach (var file in archivo)
            {
                TB_ARCHIVOS xfile = new TB_ARCHIVOS();

                // -----------------------CREACION Y GUARDADO DE ARCHIVO
                List<EquipoTemp> equiposTemp = new List<EquipoTemp>();
                int codigo_equipo = 0;

                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {

                        file.CopyTo(fileStream);
                        //----
                        IExcelDataReader reader = null;
                        if (file.FileName.EndsWith(".xls"))
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(fileStream, true);
                        }
                        else if (file.FileName.EndsWith(".xlsx"))
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
                        }
                        else
                        {
                            jres = new { msg = "El archivo selecionado no es un documento Excel.Verifique que la extención del documento sea .XLS o .XLSX", registros = "" };
                            return Json(jres);
                        }

                        reader.IsFirstRowAsColumnNames = true;
                        DataSet result = reader.AsDataSet(true);                                                    

                        foreach (DataTable table in (result.Tables))
                        {                            
                            foreach (DataRow dr in table.Rows)
                            {
                                try
                                {                            
                                    string e = "EQUIPO";                                    
                                    
                                    var campo = result.Tables[0].Rows[i]["EQUIPO"].ToString();
                                    string equipo_licencia = campo.Substring(0, 7); //cortar los primeros 8 digitos.

                                    bool evaluar = equipo_licencia.Contains(e); // preguntar si los 8 primeros digitos contienen la palabra equipo     
                                                                   
                                    EquipoTemp eq_temp = new EquipoTemp();

                                    eq_temp.id_equipo = i;

                                    if (evaluar == true)
                                    {
                                        codigo_equipo = i;
                                        eq_temp.id_caracteristica = null;
                                    }
                                    else {
                                        //eq_temp.id_caracteristica = i - j;
                                        eq_temp.id_caracteristica = codigo_equipo;
                                    }                                   

                                    eq_temp.nombre = result.Tables[0].Rows[i]["EQUIPO"].ToString();
                                    eq_temp.ncr = Convert.ToDecimal(result.Tables[0].Rows[i]["NCR"].ToString());
                                    equiposTemp.Add(eq_temp);                                                                            
                                   
                                    i++;
                                }
                                catch (Exception ex)
                                {
                                    jres = new { msg = "El formato de una o varias columnas no es el establecido, por favor revisar el Excel." + " Error: " + ex.Message, registros = "" };
                                    return Json(jres);
                                }
                            }
                        }
                        reader.Close();

                        

                        foreach (var element in equiposTemp) {                           

                            TB_EQUIPO e_entity = new TB_EQUIPO();

                            e_entity.NOMBRE_EQUIPO = element.nombre;
                            e_entity.NCR_EQUIPO = element.ncr;
                            e_entity.USUARIO = user.Result.UsuarioNombreCompleto;
                            e_entity.FECHA_REGISTRO = DateTime.Now;

                            string ei = "EQUIPO";

                            var campoi = element.nombre;
                            string equipo_licenciai = campoi.Substring(0, 7); 

                            bool evaluari = equipo_licenciai.Contains(ei); 

                            if (evaluari == true) { //insertamos solo si el registro contiene "EQUIPO"
                                var result2 = eda.InsertEquipo(e_entity);
                                if (result2 == -1)
                                {
                                    jres = new { msg = "Error al insertar ", registros = "" };
                                    return Json(jres);
                                } else if (result2 > 0) {
                                    contador = contador + 1;
                                }
                            }                      

                            var subelementos = equiposTemp.Where(i => i.id_caracteristica == element.id_equipo).ToList();
                            if (subelementos.Count > 0) {
                                for (int s = 0; s < subelementos.Count; s++)
                                {
                                    TB_EQUIPO_CARACTERISTICA c_entity = new TB_EQUIPO_CARACTERISTICA();

                                    c_entity.ID_EQUIPO = e_entity.ID_EQUIPO;
                                    c_entity.NOMBRE_CARACTERISTICA = subelementos[s].nombre;
                                    c_entity.NCR_CARACTERISTICA = subelementos[s].ncr;
                                    c_entity.USUARIO = user.Result.UsuarioNombreCompleto;
                                    c_entity.FECHA_REGISTRO = DateTime.Now;

                                    var result3 = ecda.InsertEquipoCaracteristica(c_entity);
                                    if (result3 == -1)                                    {
                                        jres = new { msg = "Error al insertar ", registros = "" };
                                        return Json(jres);
                                    }else if (result3 > 0)
                                    {
                                        contador = contador + 1;
                                    }
                                }
                            }                           
                        }
                    }


                    // -----------------------REGISTRO DE ENTIDAD ARCHIVO
                    try
                    {
                        xfile.estado_archivo = "CARGADO";
                        xfile.nombre_archivo = file.FileName;
                        xfile.observaciones = observaciones;
                        xfile.usuario = user.Result.UsuarioNombreCompleto;
                        xfile.fecha_carga = DateTime.Now;

                        var model = files_da.InsertArchivo(xfile);

                        if (model < 0)
                        {
                            jres = new { msg = "No se pudo grabar la información del archivo", registros = "" };
                            return Json(jres);
                            //return View();
                        }
                    }
                    catch (Exception ex)
                    {
                        jres = new { msg = "No se pudo grabar la información enlace. " + ex.Message, registros = "" };
                        return Json(jres);
                    }
                    // -----------------------REGISTRO DE ENTIDAD ARCHIVO
                    // -----------------------CREACION Y GUARDADO DE ARCHIVO
                }
                else
                {
                    jres = new { msg = "Hubo un error con el archivo", registros = "ERROR" };
                    return Json(jres);
                }                
            }

            string countRegistros = contador.ToString();

            jres = new { msg = "Archivo subido con exito.", registros = countRegistros };      
            return Json(jres);
        }

    }
}