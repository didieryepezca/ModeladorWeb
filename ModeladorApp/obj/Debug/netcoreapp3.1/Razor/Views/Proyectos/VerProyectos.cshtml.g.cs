#pragma checksum "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b5d8a62fa8d498e7aa462d2d60713403b292441"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b5d8a62fa8d498e7aa462d2d60713403b292441", @"/Views/Proyectos/VerProyectos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a004a41642ca9f278fa6fb07d1d5fc2e7164305b", @"/Views/_ViewImports.cshtml")]
    public class Views_Proyectos_VerProyectos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ModeladorApp.Models.Entities.TB_PROYECTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Proyectos/proyectos.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "ALL", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "VIEWER", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "EDITOR", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:blue"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OverviewProyecto", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "VerProyectos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b5d8a62fa8d498e7aa462d2d60713403b2924416353", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n        var empty = \'");
#nullable restore
#line 9 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                Write(ViewBag.empty);

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        if (empty != \"\") {\r\n            alert(empty);\r\n        }\r\n</script>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b5d8a62fa8d498e7aa462d2d60713403b2924417911", async() => {
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
                        Proyectos: ");
#nullable restore
#line 27 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                              Write(ViewBag.tipo);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    </h2>
                </div>

                <!-- Page title actions -->
                <div class=""col-auto ms-auto d-print-none"">
                    <div class=""btn-list"">

                        <!--<div class=""my-2 my-md-0 flex-grow-1 flex-md-grow-0 order-first"">

                            <div class=""input-icon"">
                                <span class=""input-icon-addon"">-->
                        <!-- Download SVG icon from http://tabler-icons.io/i/search -->
                        <!--<svg xmlns=""http://www.w3.org/2000/svg"" class=""icon"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none""></path><circle cx=""10"" cy=""10"" r=""7""></circle><line x1=""21"" y1=""21"" x2=""15"" y2=""15""></line></svg>
                                </span>
                                <input type=""text"" name=""nombre"" class=""form-control"" placeholder");
                WriteLiteral(@"=""Buscar???"" aria-label=""Search in website"">
                            </div>

                        </div>-->

                        <span class=""d-none d-sm-inline"">
                            <select class=""form-select"" name=""tipoProyecto"">
");
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b5d8a62fa8d498e7aa462d2d60713403b29244110321", async() => {
                    WriteLiteral("TODOS LOS PROYECTOS");
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b5d8a62fa8d498e7aa462d2d60713403b29244111590", async() => {
                    WriteLiteral("PROYECTOS QUE PUEDO VER");
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
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b5d8a62fa8d498e7aa462d2d60713403b29244112863", async() => {
                    WriteLiteral("PROYECTOS QUE PUEDO EDITAR");
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
                WriteLiteral("\r\n                            </select>\r\n                        </span>\r\n");
#nullable restore
#line 55 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                          
                            var search = 'B';
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <button type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 2653, "\"", 2668, 1);
#nullable restore
#line 58 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
WriteAttributeValue("", 2661, search, 2661, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" name=""accion"" class=""btn btn-white d-none d-sm-inline-block"">
                            Buscar
                        </button>

                        <a href=""#"" class=""btn btn-primary d-none d-sm-inline-block"" data-bs-toggle=""modal"" data-bs-target=""#modal-new-project"">
                            <!-- Download SVG icon from http://tabler-icons.io/i/plus -->
                            <svg xmlns=""http://www.w3.org/2000/svg"" class=""icon"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none"" /><line x1=""12"" y1=""5"" x2=""12"" y2=""19"" /><line x1=""5"" y1=""12"" x2=""19"" y2=""12"" /></svg>
                            Crear Proyecto
                        </a>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class=""page-body"">
        <div class=""container-fluid"">

            <div class=""row row-deck row-c");
                WriteLiteral("ards\">\r\n\r\n                <div class=\"col-md-12 col-lg-12\">\r\n                    <div class=\"row row-cards\">\r\n\r\n");
#nullable restore
#line 82 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                         foreach (var item in Model.GroupBy(test => test.TB_PERMISOS).Select(p => p.First()).ToList())
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b5d8a62fa8d498e7aa462d2d60713403b29244117248", async() => {
                    WriteLiteral("\r\n                                                ");
#nullable restore
#line 95 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.NombreProyecto));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-proyectoId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 94 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                                                                          WriteLiteral(item.ProyectoID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["proyectoId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-proyectoId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["proyectoId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 102 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                 foreach (var p in item.TB_PERMISOS)
                                                {
                                                    string nombreCompleto = p.UsuarioConcedidoName;

                                                    var firstLetters = new String(nombreCompleto.Split(' ').Select(x => x[0]).ToArray());


#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <span");
                BeginWriteAttribute("title", " title=\"", 5661, "\"", 5684, 1);
#nullable restore
#line 108 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
WriteAttributeValue("", 5669, nombreCompleto, 5669, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                                                          class=\"avatar avatar-sm avatar-rounded\">");
#nullable restore
#line 109 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                                                             Write(firstLetters);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 110 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            </div>\r\n                                            <span><strong>Creado por:</strong> ");
#nullable restore
#line 112 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
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
                                                <span><strong>??ltima edici??n:</strong> ");
#nullable restore
#line 119 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                                                  Write(Html.DisplayFor(modelItem => item.FechaUltimaEdicion));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                            </div>\r\n                                            <span><strong>Creaci??n:</strong> ");
#nullable restore
#line 121 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                                                        Write(Html.DisplayFor(modelItem => item.FechaCreado));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                        </div>\r\n\r\n\r\n");
#nullable restore
#line 125 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                         if (ViewBag.currentUser == item.PropietarioID)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div class=\"card-footer text-end\">\r\n                                                <div class=\"d-flex\">\r\n                                                    <a class=\"btn btn-link\" style=\"color:red\"");
                BeginWriteAttribute("onclick", "\r\n                                                       onclick=\"", 7504, "\"", 7627, 6);
                WriteAttributeValue("", 7570, "deteleProject(", 7570, 14, true);
#nullable restore
#line 130 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
WriteAttributeValue("", 7584, item.ProyectoID, 7584, 16, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7600, ",", 7600, 1, true);
                WriteAttributeValue(" ", 7601, "`\'", 7602, 3, true);
#nullable restore
#line 130 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
WriteAttributeValue("", 7604, item.NombreProyecto, 7604, 20, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7624, "\'`)", 7624, 3, true);
                EndWriteAttribute();
                WriteLiteral(">Eliminar</a>\r\n\r\n                                                    <a class=\"btn btn-link\" style=\"color:green\"");
                BeginWriteAttribute("onclick", "\r\n                                                       onclick=\"", 7740, "\"", 7893, 9);
                WriteAttributeValue("", 7806, "cloneProject(", 7806, 13, true);
#nullable restore
#line 133 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
WriteAttributeValue("", 7819, item.ProyectoID, 7819, 16, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7835, ",", 7835, 1, true);
                WriteAttributeValue(" ", 7836, "`\'", 7837, 3, true);
#nullable restore
#line 133 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
WriteAttributeValue("", 7839, item.NombreProyecto, 7839, 20, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7859, "\'`,", 7859, 3, true);
                WriteAttributeValue(" ", 7862, "`\'", 7863, 3, true);
#nullable restore
#line 133 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
WriteAttributeValue("", 7865, item.DescripcionProyecto, 7865, 25, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7890, "\'`)", 7890, 3, true);
                EndWriteAttribute();
                WriteLiteral(">Clonar</a>\r\n                                                </div>\r\n                                            </div>\r\n");
#nullable restore
#line 136 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                        }

                                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        \r\n");
#nullable restore
#line 140 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                         if (item.NombreProyecto == "02 - UNFV")
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <a class=\"btn btn-outline-green\" style=\"color:green\"");
                BeginWriteAttribute("onclick", "\r\n                                               onclick=\"", 8431, "\"", 8576, 9);
                WriteAttributeValue("", 8489, "cloneProject(", 8489, 13, true);
#nullable restore
#line 143 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
WriteAttributeValue("", 8502, item.ProyectoID, 8502, 16, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 8518, ",", 8518, 1, true);
                WriteAttributeValue(" ", 8519, "`\'", 8520, 3, true);
#nullable restore
#line 143 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
WriteAttributeValue("", 8522, item.NombreProyecto, 8522, 20, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 8542, "\'`,", 8542, 3, true);
                WriteAttributeValue(" ", 8545, "`\'", 8546, 3, true);
#nullable restore
#line 143 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
WriteAttributeValue("", 8548, item.DescripcionProyecto, 8548, 25, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 8573, "\'`)", 8573, 3, true);
                EndWriteAttribute();
                WriteLiteral("><strong>Clonar</strong></a>\r\n");
#nullable restore
#line 144 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 149 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Proyectos\VerProyectos.cshtml"
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



    <div class=""modal modal-blur fade"" id=""modal-new-project"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
        <div class=""modal-dialog modal-lg"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Crear Proyecto</h5>
                    <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                </div>
                <div class=""modal-body"">

                    <div class=""row"">
                        <div class=""col-lg-12"">
                            <div class=""mb-3"">
                                <label class=""form-label"">Nombre</label>
                                <input id=""txtPyNombre"" type=""text"" class=""form-control""
                                       name=""example-text-input"" placeholder=""Escribe un Nombre para tu Proyecto");
                WriteLiteral(@""">
                            </div>
                        </div>

                        <div class=""col-lg-12"">
                            <div>
                                <label class=""form-label"">Describe tu proyecto</label>
                                <textarea id=""txtPyDescripcion"" class=""form-control"" rows=""8""></textarea>
                            </div>
                        </div>


                    </div>
                </div>

                <div class=""modal-footer"">
                    <a href=""#"" class=""btn btn-link link-secondary"" data-bs-dismiss=""modal"">
                        Cancelar
                    </a>
                    <a onclick=""crearProyecto()"" class=""btn btn-primary ms-auto"">
                        <svg xmlns=""http://www.w3.org/2000/svg""
                             class=""icon"" width=""24"" height=""24""
                             viewBox=""0 0 24 24"" stroke-width=""2""
                             stroke=""currentColor""
              ");
                WriteLiteral(@"               fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round"">
                            <path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none"" />
                            <line x1=""12"" y1=""5"" x2=""12"" y2=""19"" />
                            <line x1=""5"" y1=""12"" x2=""19"" y2=""12"" />
                        </svg>
                        Crear
                    </a>
                </div>
            </div>
        </div>
    </div>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ModeladorApp.Models.Entities.TB_PROYECTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
