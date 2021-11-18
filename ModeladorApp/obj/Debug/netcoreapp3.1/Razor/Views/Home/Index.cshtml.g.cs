#pragma checksum "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1564c1d296ed1703d729016ab4363ed9947948af"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1564c1d296ed1703d729016ab4363ed9947948af", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a004a41642ca9f278fa6fb07d1d5fc2e7164305b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ModeladorApp.Models.Entities.TB_PERMISOS>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        background-image: url(https://image.pngaaa.com/549/4811549-middle.png);
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

    window.onload = loadMaster();

    async ");
            WriteLiteral(@"function loadMaster() {

        var data = await funGetMasterData()

        //cuando termina de ejecutarse la función asyncrona oculta el loader...
        $(""#emptyPy"").hide();

        var treeview = """";

        treeview = treeview + '<div style=""border:1px solid black; padding:0px; background-color:#FAFAFA"">';
        treeview = treeview + '<div class=""treeview"">';

        treeview = treeview + '<ul>';

        treeview = treeview + '<li>';
        treeview = treeview + '<span class=""colapsado avatar avatar-xs rounded me-2"" style=""background-image: url(https://image.pngaaa.com/73/4388073-middle.png)"" id=""node_' + data[0].nivelID + '"" onclick=""getSubMenus(' + data[0].nivelID +')"" data-loaded=""false"" pid="""">&nbsp;</span>';
        treeview = treeview + '<span><a style=""cursor:pointer"">' + data[0].identificador +'</a></span> - ';
        treeview = treeview + '<span><a style=""cursor:pointer"" onclick=""editNombre(' + data[0].nivelID +')>' + data[0].nombre + '</a></span>';
        treeview ");
            WriteLiteral(@"= treeview + '</li>';

        treeview = treeview + '</ul>';
        treeview = treeview + '</div>';
        treeview = treeview + '</div>';

        $('#master').append(treeview).fadeIn(300000);
    }

    //trae la información del Master.
    function funGetMasterData() {
        var url = ""/Home/FunGetMaster"";
        return $.get(url, {  }, function (data) {
            //console.log(data);
        });
    };


    function getSubMenus(pId) {

        console.log(pId)

        //Comprobar si la data se ha cargado
        if ($('#node_' + pId).attr('data-loaded') === 'false') {

            $('#node_' + pId).addClass(""loadingP"");   // Show loading panel
            $('#node_' + pId).removeClass(""colapsado"");

            console.log(""ENTRO"");
            // Now Load Data Here
            $.ajax({
                url: ""/Home/funGetSubNiveles"",
                type: ""GET"",
                data: { parentId: pId },
                dataType: ""json"",
                success: f");
            WriteLiteral(@"unction (d) {

                    console.log(d);

                    $('#node_' + pId).removeClass(""loadingP"");

                    if (d.length > 0) {

                        var $ul = $(""<ul></ul>"");
                        $.each(d, function (i, element) {
                            $ul.append(
                                $(""<li></li>"").append(
                                    '<span class=""colapsado avatar avatar-xs rounded me-2"" style=""background-image: url(https://image.pngaaa.com/73/4388073-middle.png)"" id=""node_' + element.nivelID + '"" onclick=""getSubMenus(' + element.nivelID + ')"" data-loaded=""false"" pid=""' + element.nivelID + '"">&nbsp;</span>' +
                                    '<span><a onclick=""editIdentificador(' + element.nivelID + ')"">' + element.identificador + '</a></span>' + '-' +
                                    '<span><a onclick=""editNombre(' + element.nivelID + ')"">' + element.nombre + '</a></span>'
                                )
                     ");
            WriteLiteral(@"       )
                        });

                        $('#node_' + pId).parent().append($ul);
                        $('#node_' + pId).addClass('colapsado');
                        $('#node_' + pId).toggleClass('colapsado expandido');
                        $('#node_' + pId).closest('li').children('ul').slideDown();
                    }
                    else {
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

        co");
            WriteLiteral("nsole.log(vId)\r\n\r\n    }\r\n\r\n    function editIdentificador(vId) {\r\n\r\n        console.log(vId)\r\n\r\n    }\r\n\r\n</script>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1564c1d296ed1703d729016ab4363ed9947948af9578", async() => {
                WriteLiteral(@"

    <div class=""container-fluid"">
        <!-- Page title -->
        <div class=""page-header d-print-none"">
            <div class=""row align-items-center"">
                <div class=""col"">
                    <!-- Page pre-title -->

                    <h2 class=""page-title"">
                        Tus Proyectos
                    </h2>
                </div>

                <!-- Page title actions -->

            </div>
        </div>
    </div>

    <div class=""page-body"">
        <div class=""container-fluid"">

            <div class=""row row-deck row-cards"">

                <div class=""col-lg-12"">
                    <div class=""row row-cards"">

                        <div class=""col-md-12"">
                            <div class=""card"">

                                <ul class=""nav nav-tabs nav-fill"" data-bs-toggle=""tabs"">
                                    <li class=""nav-item"">
                                        <a href=""#master"" class=""nav-link active");
                WriteLiteral("\" data-bs-toggle=\"tab\"><strong>MASTER</strong></a>\r\n                                    </li>\r\n");
#nullable restore
#line 203 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <li class=\"nav-item\">\r\n                                            <a");
                BeginWriteAttribute("href", " href=\"", 6717, "\"", 6750, 2);
                WriteAttributeValue("", 6724, "#proyecto_", 6724, 10, true);
#nullable restore
#line 206 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 6734, item.ProyectoID, 6734, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"nav-link\"\r\n                                               data-bs-toggle=\"tab\">");
#nullable restore
#line 207 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.TB_PROYECTO.NombreProyecto));

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                                        </li>\r\n");
#nullable restore
#line 209 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </ul>

                                <div class=""card-body"">

                                    <div class=""tab-content"">

                                        <div class=""tab-pane show active"" id=""master"">

                                            <div class=""empty"" id=""emptyPy"">
                                                <div class=""empty-img"">
                                                    <img src=""https://miro.medium.com/max/875/1*CsJ05WEGfunYMLGfsT2sXA.gif"" 
                                                         height=""128""");
                BeginWriteAttribute("alt", " alt=\"", 7593, "\"", 7599, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                                </div>
                                                <p class=""empty-title"">Cargando proyecto MASTER</p>                                                                                             
                                            </div>                                           

                                        </div>

");
#nullable restore
#line 228 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div class=\"tab-pane\"");
                BeginWriteAttribute("id", " id=\"", 8178, "\"", 8208, 2);
                WriteAttributeValue("", 8183, "proyecto_", 8183, 9, true);
#nullable restore
#line 230 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 8192, item.ProyectoID, 8192, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n");
#nullable restore
#line 232 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                 if (item.Permiso == "EDITOR") 
                                                { 

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                    <div class=""row align-items-center"">
                                                        <div class=""col-auto ms-auto d-print-none"">
                                                            <div class=""btn-list"">

                                                                <span class=""d-none d-sm-inline"">
                                                                    <a href=""#"" class=""btn btn-primary"">
                                                                        Editar
                                                                    </a>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>
");
#nullable restore
#line 246 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                            </div>\r\n");
#nullable restore
#line 249 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ModeladorApp.Models.Entities.TB_PERMISOS>> Html { get; private set; }
    }
}
#pragma warning restore 1591
