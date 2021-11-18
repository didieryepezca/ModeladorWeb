#pragma checksum "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aefa46b62a3dd134f36d40a8db7e7aec66eb6822"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Proyectos_OverviewProyecto), @"mvc.1.0.view", @"/Views/Proyectos/OverviewProyecto.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\_ViewImports.cshtml"
using ModeladorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\_ViewImports.cshtml"
using ModeladorApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aefa46b62a3dd134f36d40a8db7e7aec66eb6822", @"/Views/Proyectos/OverviewProyecto.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a004a41642ca9f278fa6fb07d1d5fc2e7164305b", @"/Views/_ViewImports.cshtml")]
    public class Views_Proyectos_OverviewProyecto : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ModeladorApp.Models.Entities.TB_PERMISOS>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-select"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("selectUsuario"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OverviewProyecto", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<script src=""https://code.jquery.com/jquery-1.11.0.min.js""></script>

<script type=""text/javascript"">

    var ArrayCamposPermiso = [];

    function AddPermiso() {

        //var tipos = $(""input[type='radio']"");
        //var tipoSeleccionado = tipos.filter("":checked"");

        var proyecto = $('#selectProyecto').val();
        var usuario = $('#selectUsuario').val();
        var permiso = $('form input[type=radio]:checked').val();

        var ArrayCamposPermiso = [];

        if (proyecto != """" && proyecto != null) {
            ArrayCamposPermiso.push(proyecto);
        }

        if (usuario != """" && usuario != null) {
            ArrayCamposPermiso.push(usuario);
        }

        if (permiso != """" && permiso != null) {
            ArrayCamposPermiso.push(permiso);
        }

        var nroCamposLlenos = ArrayCamposPermiso.length;

        if (nroCamposLlenos == 3) {

            url = ""/Permisos/FunInsertPermiso"";
            $.get(url, { py: proyecto, user: us");
            WriteLiteral(@"uario, per: permiso }, function (data) {

                //console.log(data);
                if (data >= 1) {

                    swal({
                        title: ""OK"",
                        text: ""Se Añadio el Permiso con Exito"",
                        type: ""success""
                    }
                        , function () {
                            //window.location = ""http://172.17.1.38:8188/Home/Index"";
                            window.location = ""https://localhost:5001/Permisos/VerPermisos"";
                        }
                    );
                }
                else {
                    swal({
                        title: ""ERROR"",
                        text: ""Hubo un problema al Agregar el Permiso"",
                        type: ""warning""
                    });
                }

            });

            $('#modal-permiso').modal('toggle');

        } else {

            swal({
                title: ""ERROR"",
                text: ");
            WriteLiteral("\"Te falta completar Campos\",\r\n                type: \"warning\"\r\n            });\r\n\r\n        }\r\n    }\r\n</script>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aefa46b62a3dd134f36d40a8db7e7aec66eb68227533", async() => {
                WriteLiteral(@"

    <div class=""container-fluid"">
        <!-- Page title -->
        <div class=""page-header d-print-none"">
            <div class=""row align-items-center"">
                <div class=""col"">
                    <!-- Page pre-title -->
                    <div class=""page-pretitle"">
                        Inicio
                    </div>
                    <h2 class=""page-title"">
                        Administración de Proyecto
                    </h2>
                </div>

                <!-- Page title actions -->
                <div class=""col-auto ms-auto d-print-none"">
                    <div class=""btn-list"">
");
#nullable restore
#line 98 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                          
                            if (@ViewBag.propietarioID == ViewBag.currentUser)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <a href=""#"" class=""btn btn-blue d-none d-sm-inline-block"" data-bs-toggle=""modal"" data-bs-target=""#modal-permiso"">
                                    <!-- Download SVG icon from http://tabler-icons.io/i/plus -->
                                    <svg xmlns=""http://www.w3.org/2000/svg"" class=""icon"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none"" /><line x1=""12"" y1=""5"" x2=""12"" y2=""19"" /><line x1=""5"" y1=""12"" x2=""19"" y2=""12"" /></svg>
                                    Agregar Permiso
                                </a>
");
#nullable restore
#line 106 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"

                            }
                        

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class=""page-body"">
        <div class=""container-fluid"">

            <div class=""row row-deck row-cards"">

                <div class=""col-lg-12"">
                    <div class=""row row-cards"">

                        <div class=""col-12"">
                            <div class=""card"">


                                <ul class=""nav nav-tabs nav-fill"" data-bs-toggle=""tabs"">
                                    <li class=""nav-item"">
                                        <a href=""#overview"" class=""nav-link active"" data-bs-toggle=""tab"">Overview</a>
                                    </li>
                                    <li class=""nav-item"">
                                        <a href=""#accesos"" class=""nav-link"" data-bs-toggle=""tab"">Control de Accesos</a>
                                    </li>
                                   
                                </ul>
");
                WriteLiteral(@"

                                <div class=""card-body"">

                                    <div class=""tab-content"">

                                        <div class=""tab-pane active"" id=""overview"">

                                            <div class=""col-md-12"">
                                                <div class=""card"">
                                                    <div class=""card-header"">
                                                        <h3 class=""card-title"">Información del Proyecto</h3>
                                                    </div>
                                                    <div class=""card-body"">

                                                        <div class=""form-group mb-2 row"">
                                                            <label class=""form-label col-1 col-form-label"">Nombre</label>
                                                            <div class=""col"">
                                                   ");
                WriteLiteral("             <input type=\"email\" class=\"form-control\"");
                BeginWriteAttribute("value", " value=\"", 5934, "\"", 5957, 1);
#nullable restore
#line 154 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
WriteAttributeValue("", 5942, ViewBag.nombre, 5942, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
                WriteLiteral(@"                                                            </div>
                                                        </div>
                                                        <div class=""form-group mb-3 row"">
                                                            <label class=""form-label col-1 col-form-label"">Descripción</label>
                                                            <div class=""col"">
                                                                <textarea id=""txtPyDescripcion""");
                BeginWriteAttribute("value", " value=\"", 6633, "\"", 6661, 1);
#nullable restore
#line 161 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
WriteAttributeValue("", 6641, ViewBag.descripcion, 6641, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" rows=""8""></textarea>
                                                            </div>
                                                        </div>
                                                        <div class=""form-group mb-3 row"">

                                                            <div class=""row"">

                                                                <label class=""form-label col-1 col-form-label"">Creación</label>
                                                                <div class=""col-lg-3"">
                                                                    <input class=""form-control"" id=""datepicker-icon-prepend""");
                BeginWriteAttribute("value", " value=\"", 7353, "\"", 7383, 1);
#nullable restore
#line 170 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
WriteAttributeValue("", 7361, ViewBag.fechacreacion, 7361, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                                                                </div>
                                                                <label class=""form-label col-1 col-form-label"">Última edición</label>
                                                                <div class=""col-lg-3"">
                                                                    <input class=""form-control"" id=""datepicker-icon-prepend""");
                BeginWriteAttribute("value", " value=\"", 7806, "\"", 7835, 1);
#nullable restore
#line 174 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
WriteAttributeValue("", 7814, ViewBag.fechaedicion, 7814, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                                                                </div>
                                                                <label class=""form-label col-1 col-form-label"">Propietario</label>
                                                                <div class=""col-lg-3"">
                                                                    <input class=""form-control""");
                BeginWriteAttribute("value", " value=\"", 8226, "\"", 8254, 1);
#nullable restore
#line 178 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
WriteAttributeValue("", 8234, ViewBag.propietario, 8234, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                                </div>\r\n\r\n                                                            </div>\r\n                                                        </div>\r\n\r\n");
#nullable restore
#line 184 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                         if(@ViewBag.propietarioID == ViewBag.currentUser)
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                            <div class=""form-footer"">
                                                                <a class=""btn btn-primary"">Actualizar</a>
                                                            </div>
");
#nullable restore
#line 189 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class=""tab-pane"" id=""accesos"">                                            

                                            <div class=""table-responsive"">
                                                <table class=""table table-vcenter table-mobile-md card-table"">
                                                    <thead>
                                                        <tr>
                                                            <th>#</th>
                                                            <th>Permiso Creado Por</th>
                                                            <th>Permiso</th>
                                                            <th>Permiso Concedido A</th>
                                         ");
                WriteLiteral(@"                   <th>Fecha de Creacion/Otorgacion</th>
                                                            <th class=""w-1""></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
");
#nullable restore
#line 211 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                          
                                                            int count = 1;
                                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 214 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                         foreach (var item in Model)
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <tr>\r\n                                                                <td class=\"text-muted\" data-label=\"#\">\r\n                                                                    ");
#nullable restore
#line 218 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                               Write(count);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                </td>

                                                                <td class=""text-muted"" data-label=""Permiso Creado Por"">
                                                                    <strong>");
#nullable restore
#line 222 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                                       Write(Html.DisplayFor(modelItem => item.UsuarioCreacionName));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong>
                                                                </td>

                                                                <td class=""text-muted"" data-label=""Permiso"">
                                                                    ");
#nullable restore
#line 226 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.Permiso));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                </td>

                                                                <td class=""text-muted"" data-label=""Permiso Concedido A"">
                                                                    <strong>");
#nullable restore
#line 230 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                                       Write(Html.DisplayFor(modelItem => item.UsuarioConcedidoName));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong>
                                                                </td>

                                                                <td class=""text-muted"" data-label=""Fecha de Creacion/Otorgacion"">
                                                                    ");
#nullable restore
#line 234 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.FechaPermisoCreado));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                </td>\r\n\r\n                                                                <td>\r\n                                                                    <div class=\"btn-list flex-nowrap\">\r\n\r\n");
#nullable restore
#line 240 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                                         if (item.UsuarioCreacionId == ViewBag.currentUser)
                                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                                            <a href=""#"" class=""btn btn-white"">
                                                                                Modificar
                                                                            </a>
                                                                            <a href=""#"" class=""btn btn-red"">
                                                                                Eliminar
                                                                            </a>
");
#nullable restore
#line 248 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                                        }

                                                                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                    </div>\r\n                                                                </td>\r\n                                                            </tr>\r\n");
#nullable restore
#line 266 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
                                                            { count = count + 1; }
                                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                    </tbody>
                                                </table>
                                            </div>

                                        </div>                                       

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>



    <div class=""modal modal-blur fade"" id=""modal-permiso"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
        <div class=""modal-dialog modal-lg"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Agregar Permiso</h5>
                    <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                </div>
                <div class=""modal-body"">
");
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-lg-12"">
                            <div class=""mb-3"">
                                <label class=""form-label"">Selecciona un Usuario</label>
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aefa46b62a3dd134f36d40a8db7e7aec66eb682225986", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aefa46b62a3dd134f36d40a8db7e7aec66eb682226291", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 302 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\OverviewProyecto.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(ViewBag.users, "Id", "UsuarioNombreCompleto"));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </div>
                        </div>
                    </div>

                    <label class=""form-label"">Tipo de Permiso</label>
                    <div class=""form-selectgroup-boxes row mb-3"">

                        <div class=""col-lg-6"">
                            <label class=""form-selectgroup-item"">
                                <input type=""radio"" name=""report-type"" value=""VIEWER"" class=""form-selectgroup-input"">
                                <span class=""form-selectgroup-label d-flex align-items-center p-3"">
                                    <span class=""me-3"">
                                        <span class=""form-selectgroup-check""></span>
                                    </span>
                                    <span class=""form-selectgroup-label-content"">
                                        <span class=""form-selectgroup-title strong mb-1"">VIEWER</span>
                                        <span class=""d-block text-muted"">P");
                WriteLiteral(@"ermite Ver la información de Proyectos</span>
                                    </span>
                                </span>
                            </label>
                        </div>

                        <div class=""col-lg-6"">
                            <label class=""form-selectgroup-item"">
                                <input type=""radio"" name=""report-type"" value=""EDITOR"" class=""form-selectgroup-input"">
                                <span class=""form-selectgroup-label d-flex align-items-center p-3"">
                                    <span class=""me-3"">
                                        <span class=""form-selectgroup-check""></span>
                                    </span>
                                    <span class=""form-selectgroup-label-content"">
                                        <span class=""form-selectgroup-title strong mb-1"">EDITOR</span>
                                        <span class=""d-block text-muted"">Permite Editar la información de Pro");
                WriteLiteral(@"yectos</span>
                                    </span>
                                </span>
                            </label>
                        </div>

                    </div>

                </div>

                <div class=""modal-footer"">
                    <a href=""#"" class=""btn btn-link link-secondary"" data-bs-dismiss=""modal"">
                        Cancelar
                    </a>
                    <a onclick=""AddPermiso()"" class=""btn btn-primary ms-auto"">
                        <svg xmlns=""http://www.w3.org/2000/svg""
                             class=""icon"" width=""24"" height=""24""
                             viewBox=""0 0 24 24"" stroke-width=""2""
                             stroke=""currentColor""
                             fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round"">
                            <path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none"" />
                            <line x1=""12"" y1=""5"" x2=""12"" y2=""19"" />
                          ");
                WriteLiteral("  <line x1=\"5\" y1=\"12\" x2=\"19\" y2=\"12\" />\r\n                        </svg>\r\n                        Añadir\r\n                    </a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ModeladorApp.Models.Entities.TB_PERMISOS>> Html { get; private set; }
    }
}
#pragma warning restore 1591
