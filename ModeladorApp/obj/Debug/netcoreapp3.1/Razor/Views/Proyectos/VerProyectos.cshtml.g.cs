#pragma checksum "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "944f8877f6f824286df415c97f367994aa0deff6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Proyectos_VerProyectos), @"mvc.1.0.view", @"/Views/Proyectos/VerProyectos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"944f8877f6f824286df415c97f367994aa0deff6", @"/Views/Proyectos/VerProyectos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a004a41642ca9f278fa6fb07d1d5fc2e7164305b", @"/Views/_ViewImports.cshtml")]
    public class Views_Proyectos_VerProyectos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ModeladorApp.Models.Entities.TB_PROYECTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "TODOS LOS PROYECTOS", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "ADMINISTRO", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "EDITO QUE PUEDO EDITAR", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "VEO QUE PUEDO VER", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:blue"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OverviewProyecto", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "VerProyectos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "944f8877f6f824286df415c97f367994aa0deff66422", async() => {
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
                        Proyectos:
                    </h2>
                </div>

                <!-- Page title actions -->
                <div class=""col-auto ms-auto d-print-none"">
                    <div class=""btn-list"">

                        <div class=""my-2 my-md-0 flex-grow-1 flex-md-grow-0 order-first"">
                           
                                <div class=""input-icon"">
                                    <span class=""input-icon-addon"">
                                        <!-- Download SVG icon from http://tabler-icons.io/i/search -->
                               ");
                WriteLiteral(@"         <svg xmlns=""http://www.w3.org/2000/svg"" class=""icon"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none""></path><circle cx=""10"" cy=""10"" r=""7""></circle><line x1=""21"" y1=""21"" x2=""15"" y2=""15""></line></svg>
                                    </span>
                                    <input type=""text"" name=""nombre"" class=""form-control"" placeholder=""Buscar…"" aria-label=""Search in website"">
                                </div>
                            
                        </div>

                        <span class=""d-none d-sm-inline"">
                            <select class=""form-select"" name=""tipoProyecto"">
");
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "944f8877f6f824286df415c97f367994aa0deff68665", async() => {
                    WriteLiteral("TODOS LOS PROYECTOS");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "944f8877f6f824286df415c97f367994aa0deff69933", async() => {
                    WriteLiteral("PROYECTOS QUE ADMINISTRO");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "944f8877f6f824286df415c97f367994aa0deff611206", async() => {
                    WriteLiteral("PROYECTOS QUE PUEDO EDITAR");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("  \r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "944f8877f6f824286df415c97f367994aa0deff612484", async() => {
                    WriteLiteral("PROYECTOS QUE PUEDO VER");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </select>
                        </span>

                        <button type=""submit"" class=""btn btn-primary d-none d-sm-inline-block"">                            
                            Buscar
                        </button>

                        <a href=""#"" class=""btn btn-white d-none d-sm-inline-block"" data-bs-toggle=""modal"" data-bs-target=""#modal-permiso"">
                            <!-- Download SVG icon from http://tabler-icons.io/i/plus -->
                            <svg xmlns=""http://www.w3.org/2000/svg"" class=""icon"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none"" /><line x1=""12"" y1=""5"" x2=""12"" y2=""19"" /><line x1=""5"" y1=""12"" x2=""19"" y2=""12"" /></svg>
                            Crear Proyecto
                        </a>

                    </div>
                </div>
            </div>
        </d");
                WriteLiteral("iv>\r\n    </div>\r\n\r\n    <div class=\"page-body\">\r\n        <div class=\"container-fluid\">\r\n\r\n            <div class=\"row row-deck row-cards\">\r\n\r\n                <div class=\"col-md-12 col-lg-12\">\r\n                    <div class=\"row row-cards\">\r\n\r\n");
#nullable restore
#line 70 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                         foreach (var item in Model.GroupBy(test => test.TB_PERMISOS).Select(grp => grp.First()).ToList())
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <div class=""col-4"">
                                <div class=""card"">
                                    <div class=""progress card-progress"">
                                        <div class=""progress-bar bg-green"" style=""width: 20%"" role=""progressbar"" aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100"">
                                            <span class=""visually-hidden"">20% Complete</span>
                                        </div>
                                    </div>
                                    <div class=""card-body"">
                                        <h3 class=""card-title"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "944f8877f6f824286df415c97f367994aa0deff616196", async() => {
                    WriteLiteral("\r\n                                            ");
#nullable restore
#line 82 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.NombreProyecto));

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                        </h3>                                       
                                                                       
                                        <div class=""card-meta d-flex justify-content-between"">
                                            <span><strong>Colaboradores: </strong></span>
                                            <div class=""d-flex align-items-center"">
");
#nullable restore
#line 88 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                 foreach (var p in item.TB_PERMISOS)
                                                {
                                                    string nombreCompleto = p.UsuarioConcedidoName;

                                                    var firstLetters = new String(nombreCompleto.Split(' ').Select(x => x[0]).ToArray());


#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <span");
                BeginWriteAttribute("title", " title=\"", 5562, "\"", 5585, 1);
#nullable restore
#line 94 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
WriteAttributeValue("", 5570, nombreCompleto, 5570, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                                                          class=\"avatar avatar-sm avatar-rounded\">");
#nullable restore
#line 95 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                                                             Write(firstLetters);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 96 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            </div>\r\n                                            <span><strong>Creado por:</strong> ");
#nullable restore
#line 98 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                                          Write(Html.DisplayFor(modelItem => item.PropietarioName));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                        </div>

                                        <div class=""card-meta d-flex justify-content-between"">
                                            <div class=""d-flex align-items-center"">
                                                <!-- Download SVG icon from http://tabler-icons.io/i/check -->
                                                <svg xmlns=""http://www.w3.org/2000/svg"" class=""icon me-2"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none""></path><path d=""M5 12l5 5l10 -10""></path></svg>
                                                <span><strong>Última edición:</strong> ");
#nullable restore
#line 105 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                                                  Write(Html.DisplayFor(modelItem => item.FechaUltimaEdicion));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                            </div>\r\n                                            <span><strong>Creación:</strong> ");
#nullable restore
#line 107 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                                        Write(Html.DisplayFor(modelItem => item.FechaCreado));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 112 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
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

                    <div class=""row"">
                        <div class=""col-lg-6"">
                            <div class=""mb-3"">
                                <label class=""form-label"">Selecciona uno de tus Proyectos</label>
                                <select class=""form-select"" id=""selectProyecto"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "944f8877f6f824286df415c97f367994aa0deff623524", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </select>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""mb-3"">
                                <label class=""form-label"">Selecciona un Usuario</label>
                                <select class=""form-select"" id=""selectUsuario"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "944f8877f6f824286df415c97f367994aa0deff625003", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </select>
                            </div>
                        </div>
                    </div>

                    <label class=""form-label"">Tipo de Permiso</label>
                    <div class=""form-selectgroup-boxes row mb-3"">
                        <div class=""col-lg-4"">
                            <label class=""form-selectgroup-item"">
                                <input type=""radio"" name=""report-type"" value=""ADMIN"" class=""form-selectgroup-input"" checked>
                                <span class=""form-selectgroup-label d-flex align-items-center p-3"">
                                    <span class=""me-3"">
                                        <span class=""form-selectgroup-check""></span>
                                    </span>
                                    <span class=""form-selectgroup-label-content"">
                                        <span class=""form-selectgroup-title strong mb-1"">ADMIN</span>
                           ");
                WriteLiteral(@"             <span class=""d-block text-muted"">Permite Ver y Editar la información de Proyectos.</span>
                                    </span>
                                </span>
                            </label>
                        </div>
                        <div class=""col-lg-4"">
                            <label class=""form-selectgroup-item"">
                                <input type=""radio"" name=""report-type"" value=""VIEWER"" class=""form-selectgroup-input"">
                                <span class=""form-selectgroup-label d-flex align-items-center p-3"">
                                    <span class=""me-3"">
                                        <span class=""form-selectgroup-check""></span>
                                    </span>
                                    <span class=""form-selectgroup-label-content"">
                                        <span class=""form-selectgroup-title strong mb-1"">VIEWER</span>
                                        <span class=""d");
                WriteLiteral(@"-block text-muted"">Permite Ver la información de Proyectos</span>
                                    </span>
                                </span>
                            </label>
                        </div>

                        <div class=""col-lg-4"">
                            <label class=""form-selectgroup-item"">
                                <input type=""radio"" name=""report-type"" value=""EDITOR"" class=""form-selectgroup-input"">
                                <span class=""form-selectgroup-label d-flex align-items-center p-3"">
                                    <span class=""me-3"">
                                        <span class=""form-selectgroup-check""></span>
                                    </span>
                                    <span class=""form-selectgroup-label-content"">
                                        <span class=""form-selectgroup-title strong mb-1"">EDITOR</span>
                                        <span class=""d-block text-muted"">Permite Editar l");
                WriteLiteral(@"a información de Proyectos</span>
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
                WriteLiteral("                      <line x1=\"5\" y1=\"12\" x2=\"19\" y2=\"12\" />\r\n                        </svg>\r\n                        Añadir\r\n                    </a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ModeladorApp.Models.Entities.TB_PROYECTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
