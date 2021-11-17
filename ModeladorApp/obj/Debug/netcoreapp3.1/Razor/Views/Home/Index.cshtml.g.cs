#pragma checksum "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1185138a994ea248ff113732ff3b26731a9443c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1185138a994ea248ff113732ff3b26731a9443c2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a004a41642ca9f278fa6fb07d1d5fc2e7164305b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ModeladorApp.Models.Entities.TB_NIVEL>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Inicio";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""https://code.jquery.com/jquery-1.11.0.min.js""></script>

<style>
    .loadingP {
        background-image: url(img/loading.gif);
        width: 15px;
        display: inline-block;
    }

    .colapsado {
        width: 15px;        
        cursor: pointer;
    }

    .expandido {
        width: 15px;
        background-image: url(img/tabler-icon-minus.svg);
        background-repeat: no-repeat;
        background-position: -50px -17px;
        display: inline-block;
        cursor: pointer;
    }

    .treeview ul {
        font: 14px Arial, Sans-Serif;
        margin: 0px;
        padding-left: 20px;
        list-style: none;
    }

    .treeview > li > a {
        font-weight: bold;
    }

    .treeview li a {
        padding: 4px;
        font-size: 12px;
        display: inline-block;
        text-decoration: none;
        width: auto;
    }
</style>



<script type=""text/javascript"">

    //window.onload = load;

    function load() {

   ");
            WriteLiteral(@"     //console.log(""-------------->>"");

    //$(document).ready(function () {        

    }

    function getSubMenus(pId) {

        console.log(pId)
      
        //Comprobar si la data se ha cargado
        if ($('#node_' + pId).attr('data-loaded') === 'false') {

            $('#node_' + pId).addClass(""loadingP"");   // Show loading panel
            $('#node_' + pId).removeClass(""colapsado"");

            console.log(""ENTRO"");
            // Now Load Data Here 
            $.ajax({
                url: ""/Home/GetSubMenu"",
                type: ""GET"",
                data: { parentId: pId },
                dataType: ""json"",
                success: function (d) {

                    console.log(d);

                    $('#node_' + pId).removeClass(""loadingP"");

                    if (d.length > 0) {

                        var $ul = $(""<ul></ul>"");
                        $.each(d, function (i, element) {
                            $ul.append(
                    ");
            WriteLiteral(@"            $(""<li></li>"").append(
                                    '<span class=""colapsado avatar avatar-xs rounded me-2"" style=""background-image: url(img/tabler-icon-plus.svg)"" id=""node_' + element.nivelID + '"" onclick=""getSubMenus(' + element.nivelID + ')"" data-loaded=""false"" pid=""' + element.nivelID + '"">&nbsp;</span>' +
                                    '<span><a onclick=""editIdentificador(' + element.nivelID + ')"">' + element.identificador + '</a></span>' + '-' +
                                    '<span><a onclick=""editNombre(' + element.nivelID +')"">' + element.nombre + '</a></span>'
                                )
                            )
                        });

                        $('#node_' + pId).parent().append($ul);
                        $('#node_' + pId).addClass('colapsado');
                        $('#node_' + pId).toggleClass('colapsado expandido');
                        $('#node_' + pId).closest('li').children('ul').slideDown();
                    }
");
            WriteLiteral(@"                    else {
                        // no sub menu
                        $('#node_' + pId).css({ 'display': 'inline-block', 'width': '15px' });
                    }

                    $('#node_' + pId).attr('data-loaded', true);
                },
                error: function () {
                    alert(""Error!"");
                }
            });
        }
        else {
            // if already data loaded
            $('#node_' + pId).toggleClass(""colapsado expandido"");
            $('#node_' + pId).closest('li').children('ul').slideToggle();
        }
    }



    
    function editNombre(vId) {

        console.log(vId)

    }

    function editIdentificador(vId) {

        console.log(vId)

    }

    //});

</script>

<div class=""container-fluid"">

    <!-- Page title -->
    <div class=""page-header d-print-none"">
        <div class=""row align-items-center"">
            <div class=""col"">
                <!-- Page pre-title -->
    ");
            WriteLiteral(@"            <div class=""page-pretitle"">
                    Inicio
                </div>
                <h2 class=""page-title"">
                    Pestañas
                </h2>
            </div>

            <!-- Page title actions -->

            <div class=""col-auto ms-auto d-print-none"">
                <div class=""btn-list"">
                    <span class=""d-none d-sm-inline"">
                        <a href=""#"" class=""btn btn-white"">
                            Editar
                        </a>
                    </span>
                    <a href=""#"" class=""btn btn-primary d-none d-sm-inline-block"" data-bs-toggle=""modal"" data-bs-target=""#modal-report"">
                        <!-- Download SVG icon from http://tabler-icons.io/i/plus -->
                        <svg xmlns=""http://www.w3.org/2000/svg"" class=""icon"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""");
            WriteLiteral(@"M0 0h24v24H0z"" fill=""none"" /><line x1=""12"" y1=""5"" x2=""12"" y2=""19"" /><line x1=""5"" y1=""12"" x2=""19"" y2=""12"" /></svg>
                        Crear Nuevo
                    </a>
                    <a href=""#"" class=""btn btn-primary d-sm-none btn-icon"" data-bs-toggle=""modal"" data-bs-target=""#modal-report"" aria-label=""Create new report"">
                        <!-- Download SVG icon from http://tabler-icons.io/i/plus -->
                        <svg xmlns=""http://www.w3.org/2000/svg"" class=""icon"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none"" /><line x1=""12"" y1=""5"" x2=""12"" y2=""19"" /><line x1=""5"" y1=""12"" x2=""19"" y2=""12"" /></svg>
                    </a>
                </div>
            </div>
        </div>
    </div>
</div>




<div class=""page-body"">
    <div class=""container-fluid"">

        <div class=""row row-deck row-cards"">

            <div ");
            WriteLiteral(@"class=""col-lg-12"">
                <div class=""row row-cards"">

                    <div class=""col-md-12"">
                        <div class=""card"">
                            <ul class=""nav nav-tabs nav-fill"" data-bs-toggle=""tabs"">
                                <li class=""nav-item"">
                                    <a href=""#home"" class=""nav-link active"" data-bs-toggle=""tab"">MASTER</a>
                                </li>
                                <li class=""nav-item"">
                                    <a href=""#usuario1"" class=""nav-link"" data-bs-toggle=""tab"">USUARIO 1</a>
                                </li>
                                <li class=""nav-item"">
                                    <a href=""#usuario2"" class=""nav-link"" data-bs-toggle=""tab"">USUARIO 2</a>
                                </li>
                            </ul>
                            <div class=""card-body"">

                                <div class=""tab-content"">

                      ");
            WriteLiteral(@"              <div class=""tab-pane show active"" id=""home"">

                                        <div>Visualización de</div>

                                        <h2>Proyecto Master</h2>
                                        <div style=""border:1px solid black; padding:0px;  background-color:#FAFAFA"">
");
            WriteLiteral("                                                <div class=\"treeview\">\r\n");
#nullable restore
#line 217 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                      
                                                        if (Model != null && Model.Count() > 0)
                                                        {
                                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <ul>\r\n");
#nullable restore
#line 222 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                                 foreach (var i in Model)
                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <li>\r\n");
            WriteLiteral("\r\n                                                                    <span class=\"colapsado avatar avatar-xs rounded me-2\"\r\n                                                                          style=\"background-image: url(img/tabler-icon-plus.svg)\"");
            BeginWriteAttribute("id", "\r\n                                                                          id=\"", 8838, "\"", 8933, 2);
            WriteAttributeValue("", 8918, "node_", 8918, 5, true);
#nullable restore
#line 230 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 8923, i.NivelID, 8923, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 8934, "\"", 8969, 3);
            WriteAttributeValue("", 8944, "getSubMenus(\'", 8944, 13, true);
#nullable restore
#line 230 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 8957, i.NivelID, 8957, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8967, "\')", 8967, 2, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                                                                          data-loaded=\"false\"");
            BeginWriteAttribute("pid", " pid=\"", 9065, "\"", 9081, 1);
#nullable restore
#line 231 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 9071, i.NivelID, 9071, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&nbsp;</span>\r\n\r\n");
            WriteLiteral("\r\n                                                                    <span>\r\n                                                                        <a style=\"cursor:pointer\">");
#nullable restore
#line 237 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                                                             Write(i.Identificador);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                                                    </span>
                                                                    -
                                                                    <span>
                                                                        <a style=""cursor:pointer""");
            BeginWriteAttribute("onclick", " onclick=\"", 9910, "\"", 9944, 3);
            WriteAttributeValue("", 9920, "editNombre(\'", 9920, 12, true);
#nullable restore
#line 241 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 9932, i.NivelID, 9932, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9942, "\')", 9942, 2, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 241 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                                                                                                Write(i.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                                                    </span>\r\n\r\n\r\n                                                                </li>\r\n");
#nullable restore
#line 246 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            </ul>\r\n");
#nullable restore
#line 248 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                        }
                                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </div>\r\n");
            WriteLiteral(@"                                        </div>


                                    </div>

                                    <div class=""tab-pane"" id=""usuario1"">
                                        <div>Visualizacion de Usuario 1</div>
                                    </div>
                                    <div class=""tab-pane"" id=""usuario2"">
                                        <div>Visualizacion de Usuario 2</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>



                    <!--<div class=""col-12"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <h3 class=""card-title"">Traffic summary</h3>
                                <div id=""chart-mentions"" class=""chart-lg""></div>
                            </div>
                        </div>
                    ");
            WriteLiteral(@"</div>


                    <div class=""col-12"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <p class=""mb-3"">Using Storage <strong>6854.45 MB </strong>of 8 GB</p>
                                <div class=""progress progress-separated mb-3"">
                                    <div class=""progress-bar bg-primary"" role=""progressbar"" style=""width: 44%""></div>
                                    <div class=""progress-bar bg-info"" role=""progressbar"" style=""width: 19%""></div>
                                    <div class=""progress-bar bg-success"" role=""progressbar"" style=""width: 9%""></div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-auto d-flex align-items-center pe-2"">
                                        <span class=""legend me-2 bg-primary""></span>
                                        <span>Regular</span>
       ");
            WriteLiteral(@"                                 <span class=""d-none d-md-inline d-lg-none d-xxl-inline ms-2 text-muted"">915MB</span>
                                    </div>
                                    <div class=""col-auto d-flex align-items-center px-2"">
                                        <span class=""legend me-2 bg-info""></span>
                                        <span>System</span>
                                        <span class=""d-none d-md-inline d-lg-none d-xxl-inline ms-2 text-muted"">415MB</span>
                                    </div>
                                    <div class=""col-auto d-flex align-items-center px-2"">
                                        <span class=""legend me-2 bg-success""></span>
                                        <span>Shared</span>
                                        <span class=""d-none d-md-inline d-lg-none d-xxl-inline ms-2 text-muted"">201MB</span>
                                    </div>
                                    <div class=""");
            WriteLiteral(@"col-auto d-flex align-items-center ps-2"">
                                        <span class=""legend me-2""></span>
                                        <span>Free</span>
                                        <span class=""d-none d-md-inline d-lg-none d-xxl-inline ms-2 text-muted"">612MB</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-4"">
                        <div class=""card"">
                            <div class=""card-body p-2 text-center"">
                                <div class=""text-end text-green"">
                                    <span class=""text-green d-inline-flex align-items-center lh-1"">
                                        6%-->
                    <!-- Download SVG icon from http://tabler-icons.io/i/trending-up -->
                    <!--<svg xmlns=""http://www.w3.org/2000/svg"" class=""icon ms-");
            WriteLiteral(@"1"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none"" /><polyline points=""3 17 9 11 13 15 21 7"" /><polyline points=""14 7 21 7 21 14"" /></svg>
                                    </span>
                                </div>
                                <div class=""h1 m-0"">43</div>
                                <div class=""text-muted mb-3"">New Tickets</div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-4"">
                        <div class=""card"">
                            <div class=""card-body p-2 text-center"">
                                <div class=""text-end text-red"">
                                    <span class=""text-red d-inline-flex align-items-center lh-1"">
                                        -2%-->
                    <!-- Download SVG icon from h");
            WriteLiteral(@"ttp://tabler-icons.io/i/trending-down -->
                    <!--<svg xmlns=""http://www.w3.org/2000/svg"" class=""icon ms-1"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none"" /><polyline points=""3 7 9 13 13 9 21 17"" /><polyline points=""21 10 21 17 14 17"" /></svg>
                                    </span>
                                </div>
                                <div class=""h1 m-0"">95</div>
                                <div class=""text-muted mb-3"">Daily Earnings</div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-4"">
                        <div class=""card"">
                            <div class=""card-body p-2 text-center"">
                                <div class=""text-end text-green"">
                                    <span class=""text-green d-inline");
            WriteLiteral(@"-flex align-items-center lh-1"">
                                        9%-->
                    <!-- Download SVG icon from http://tabler-icons.io/i/trending-up -->
                    <!--<svg xmlns=""http://www.w3.org/2000/svg"" class=""icon ms-1"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none"" /><polyline points=""3 17 9 11 13 15 21 7"" /><polyline points=""14 7 21 7 21 14"" /></svg>
                                    </span>
                                </div>
                                <div class=""h1 m-0"">7</div>
                                <div class=""text-muted mb-3"">New Replies</div>
                            </div>
                        </div>
                    </div>-->

                </div>
            </div>

        </div>

    </div>
</div>


<div class=""modal modal-blur fade"" id=""modal-report"" tabindex=""-1"" role=""dial");
            WriteLiteral(@"og"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Nuevo Proyecto</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <div class=""mb-3"">
                    <label class=""form-label"">Identificador de tu Usuario</label>
                    <input type=""text"" class=""form-control"" name=""example-text-input""");
            BeginWriteAttribute("value", " value=\"", 18224, "\"", 18250, 1);
#nullable restore
#line 379 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 18232, ViewBag.usuarioId, 18232, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled>
                </div>
                <div class=""mb-3"">
                    <label class=""form-label"">Nombre</label>
                    <input type=""text"" class=""form-control"" name=""example-text-input"" placeholder=""Escribe el Nombre del Cliente"">
                </div>
                <label class=""form-label"">Tipo</label>
                <div class=""form-selectgroup-boxes row mb-3"">
                    <div class=""col-lg-6"">
                        <label class=""form-selectgroup-item"">
                            <input type=""radio"" name=""report-type"" value=""1"" class=""form-selectgroup-input"" checked>
                            <span class=""form-selectgroup-label d-flex align-items-center p-3"">
                                <span class=""me-3"">
                                    <span class=""form-selectgroup-check""></span>
                                </span>
                                <span class=""form-selectgroup-label-content"">
                                    <s");
            WriteLiteral(@"pan class=""form-selectgroup-title strong mb-1"">Simple</span>
                                    <span class=""d-block text-muted"">Esto es un proyecto Simple.</span>
                                </span>
                            </span>
                        </label>
                    </div>
                    <div class=""col-lg-6"">
                        <label class=""form-selectgroup-item"">
                            <input type=""radio"" name=""report-type"" value=""1"" class=""form-selectgroup-input"">
                            <span class=""form-selectgroup-label d-flex align-items-center p-3"">
                                <span class=""me-3"">
                                    <span class=""form-selectgroup-check""></span>
                                </span>
                                <span class=""form-selectgroup-label-content"">
                                    <span class=""form-selectgroup-title strong mb-1"">Avanzado</span>
                                    <span clas");
            WriteLiteral(@"s=""d-block text-muted"">Esto es un proyecto avanzado</span>
                                </span>
                            </span>
                        </label>
                    </div>
                </div>

            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-lg-6"">
                        <div class=""mb-3"">
                            <label class=""form-label"">Identificador único del cliente</label>
                            <input type=""text"" class=""form-control"" required>
                        </div>
                    </div>
                    <div class=""col-lg-6"">
                        <div class=""mb-3"">
                            <label class=""form-label"">Fecha Límite</label>
                            <input type=""date"" class=""form-control"">
                        </div>
                    </div>
                    <div class=""col-lg-12"">
                        <div>
             ");
            WriteLiteral(@"               <label class=""form-label"">Información Adicional</label>
                            <textarea class=""form-control"" rows=""3""></textarea>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <a href=""#"" class=""btn btn-link link-secondary"" data-bs-dismiss=""modal"">
                    Cancelar
                </a>
                <a href=""#"" class=""btn btn-primary ms-auto"" data-bs-dismiss=""modal"">
");
            WriteLiteral(@"                    <svg xmlns=""http://www.w3.org/2000/svg"" class=""icon"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none"" /><line x1=""12"" y1=""5"" x2=""12"" y2=""19"" /><line x1=""5"" y1=""12"" x2=""19"" y2=""12"" /></svg>
                    Crear Proyecto
                </a>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ModeladorApp.Models.Entities.TB_NIVEL>> Html { get; private set; }
    }
}
#pragma warning restore 1591
