#pragma checksum "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ad9da8d8205c49e40f2f0f59de2c486871da7b2"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ad9da8d8205c49e40f2f0f59de2c486871da7b2", @"/Views/Home/Index.cshtml")]
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


    //----------------------------------------------------------- PESTAÑA PROYECTO MASTER -----------------------
    async function loadMaster() {

        //removemos el pane del proyecto ma");
            WriteLiteral(@"ster para volverlo a construir
        $(""#masterPane"").remove();

        //muestra el loader cuando volvemos a hacer click aqui
        $(""#emptyPy"").show();

        var data = await funGetMasterData()

        //cuando termina de ejecutarse la función asyncrona oculta el loader...
        $(""#emptyPy"").hide();

        //------------------------------------------------------------->>>Treeview Master
        var treeview = """";        

        treeview = treeview + '<div id=""masterPane"" style=""border:1px solid black; padding:0px; background-color:#FAFAFA"">';        
        treeview = treeview + '<div class=""treeview"">';
        treeview = treeview + '<ul>';

        treeview = treeview + '<li>';
        treeview = treeview + '<span class=""colapsado avatar avatar-xs rounded me-2"" style=""background-image: url(https://image.pngaaa.com/73/4388073-middle.png)"" id=""node_' + data[0].nivelID + '"" onclick=""getSubMenus(' + data[0].nivelID + ')"" data-loaded=""false"" pid="""">&nbsp;</span>';
        ");
            WriteLiteral(@"treeview = treeview + '<a style=""cursor:pointer"">' + data[0].identificador + '</a> - ';
        treeview = treeview + '<a style=""cursor:pointer"">' + data[0].nombre + '</a>';
        treeview = treeview + '</li>';

        treeview = treeview + '</ul>';
        treeview = treeview + '</div>';
        treeview = treeview + '</div>';

        $('#master').append(treeview).fadeIn(300000);
        //------------------------------------------------------------->>>Treeview Master
    }

    //trae la información del Master.
    function funGetMasterData() {
        var url = ""/Home/funGetMaster"";
        return $.get(url, {}, function (data) {
            //console.log(data);
        });
    };

    //----------------------------------------------------------- PESTAÑA PROYECTO MASTER -----------------------

    function getSubMenus(pId) {

        //console.log(pId)
        //Comprobar si la data se ha cargado
        if ($('#node_' + pId).attr('data-loaded') === 'false') {
            
");
            WriteLiteral(@"            $('#node_' + pId).attr('style', ""background-image: url(https://raw.githubusercontent.com/Codelessly/FlutterLoadingGIFs/master/packages/cupertino_activity_indicator_selective.gif)"");// Loader
            $('#node_' + pId).removeClass(""colapsado"");

            //console.log(""colapsado"");
            // Cargamos la data con un Ajax Call...
            $.ajax({
                url: ""/Home/funGetSubNiveles"",
                type: ""GET"",
                data: { parentId: pId },
                dataType: ""json"",
                success: function (d) {

                    //console.log(d);
                    
                    $('#node_' + pId).attr('style',""background-image: url(https://iconsplace.com/wp-content/uploads/_icons/ffa500/256/png/minus-2-icon-11-256.png)""); //-

                    if (d.length > 0) {

                        if (d[0].parentNivelID == pId) { $('#ul' + pId).remove(); } //prevenir info duplicada                        

                        var $ul =");
            WriteLiteral(@" $('<ul id=""ul'+ pId +'""></ul>');
                        $.each(d, function (i, element) {

                            //console.log(element.nivelID);
                           
                            var info = funGetInfo(element.nivelID)

                            var cajitas = """";

                            info.then(function (result) {
                                // accedemos al result de la promise info...                                

                                //for para agregar la información dinámica a las cajitas de texto...
                                for (j = 0; j <= result.length - 1; j++) {
                                    //cajitas = cajitas + '<input type=""text"" value=""' + result[j].informacion + '"" style=""width: fit-content"">';
                                    cajitas = cajitas + '<span class=""input"" role=""textbox"" contenteditable>' + result[1].informacion + '</span>';
                                }

                                $ul.ap");
            WriteLiteral(@"pend(
                                    $(""<li></li>"").append(
                                        '<span class=""avatar avatar-xs rounded me-2 colapsado"" style=""background-image: url(https://image.pngaaa.com/73/4388073-middle.png)"" id=""node_' + element.nivelID + '"" onclick=""getSubMenus(' + element.nivelID + ')"" data-loaded=""false"" pid=""' + element.nivelID + '"">&nbsp;</span>' +                                                                       
                                        '<a style=""cursor:pointer"">' + element.identificador + '</a>' + ' - ' +
                                        '<a style=""cursor:pointer"">' + element.nombre + '</a>' + ' - ' +
                                        cajitas                                        
                                        //'<a style=""cursor:pointer""><svg xmlns=""http://www.w3.org/2000/svg"" class=""icon"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""");
            WriteLiteral(@"round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none""></path><circle cx=""6"" cy=""10"" r=""2""></circle><line x1=""6"" y1=""4"" x2=""6"" y2=""8""></line><line x1=""6"" y1=""12"" x2=""6"" y2=""20""></line><circle cx=""12"" cy=""16"" r=""2""></circle><line x1=""12"" y1=""4"" x2=""12"" y2=""14""></line><line x1=""12"" y1=""18"" x2=""12"" y2=""20""></line><circle cx=""18"" cy=""7"" r=""2""></circle><line x1=""18"" y1=""4"" x2=""18"" y2=""5""></line><line x1=""18"" y1=""9"" x2=""18"" y2=""20""></line></svg></a>'                                                                                                                                   
                                    )
                                )

                            });


                        });


                        $('#node_' + pId).parent().append($ul);
                        //$('#node_' + pId).addClass('colapsado');
                        $('#node_' + pId).attr('style', ""background-image: url(https://iconsplace.com/wp-content/uploads/_icons/ffa500/256/png/minus-2-icon-11-256");
            WriteLiteral(@".png)""); //-
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
                    alert(""Hubo un problema al cargar la data!"");
                }
            });
        }
        else {
            // if already data loaded            
            //console.log(""expandido"")
            
            $('#node_' + pId).attr('data-loaded', false);
            $('#node_' + pId).toggleClass(""colapsado expandido"");
            $('#node_' + pId).attr('style', ""background-image: url(https://image.pngaaa.com/73/4388073-middle.png)""); // +
            
           ");
            WriteLiteral(@" $('#node_' + pId).closest('li').children('ul').slideToggle();
        }
    }

    //-------------------------------- para obtener la info de cada nivel...
    async function funGetInfo(lvlID) {
        return info = await funGetInfoFromDB(lvlID);       
        //var info = await funGetInfoFromDB(lvlID);
        //console.log(info)
    };    
    
    function funGetInfoFromDB(lvlID) {        
        var url = ""/Home/funGetInfoFromDB"";
        return $.get(url, { lvlId: lvlID}, function (data) {
            //console.log(data);
        });
    }
    //-------------------------------- para obtener la info de cada nivel...


    function editNombre(vId) {

        console.log(vId)

    }

    function editIdentificador(vId) {

        console.log(vId)

    }

</script>


");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ad9da8d8205c49e40f2f0f59de2c486871da7b213538", async() => {
                WriteLiteral(@"

    <div class=""page-body"">
        <div class=""container-fluid"">

            <div class=""row row-deck row-cards"">

                <div class=""col-lg-12"">
                    <div class=""row row-cards"">

                        <div class=""col-md-12"">
                            <div class=""card"">

                                <ul class=""nav nav-tabs nav-fill"" data-bs-toggle=""tabs"">
                                    <li class=""nav-item"">
                                        <a href=""#master"" onclick=""loadMaster()"" class=""nav-link active""
                                           data-bs-toggle=""tab""><strong>MASTER</strong></a>
                                    </li>
");
#nullable restore
#line 236 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <li class=\"nav-item\">\r\n                                            <a");
                BeginWriteAttribute("href", " href=\"", 10076, "\"", 10109, 2);
                WriteAttributeValue("", 10083, "#proyecto_", 10083, 10, true);
#nullable restore
#line 239 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 10093, item.ProyectoID, 10093, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"nav-link\"\r\n                                               data-bs-toggle=\"tab\">");
#nullable restore
#line 240 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.TB_PROYECTO.NombreProyecto));

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                                        </li>\r\n");
#nullable restore
#line 242 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </ul>

                                <div class=""card-body"">

                                    <div class=""tab-content"">                                       

                                        <div class=""tab-pane show active"" id=""master"">


                                            <div class=""row align-items-center"">
                                                <div class=""col-auto ms-auto d-print-none"">
                                                    <div class=""btn-list"">

                                                        <span class=""d-none d-sm-inline"">
                                                            <a href=""#"" class=""btn btn-primary"">
                                                                Clonar
                                                            </a>
                                                        </span>
                                                    </div>
                       ");
                WriteLiteral(@"                         </div>
                                            </div>                                            

                                            <div class=""empty"" id=""emptyPy"">
                                                <div class=""empty-img"">
                                                    <img src=""https://miro.medium.com/max/875/1*CsJ05WEGfunYMLGfsT2sXA.gif"" height=""128"">
                                                </div>
                                                <p class=""empty-title"">Cargando ""MASTER""</p>
                                            </div>

                                        </div>


");
#nullable restore
#line 275 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div class=\"tab-pane\"");
                BeginWriteAttribute("id", " id=\"", 12230, "\"", 12260, 2);
                WriteAttributeValue("", 12235, "proyecto_", 12235, 9, true);
#nullable restore
#line 277 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 12244, item.ProyectoID, 12244, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n");
#nullable restore
#line 279 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
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
#line 293 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                <div class=\"empty\"");
                BeginWriteAttribute("id", " id=\"", 13417, "\"", 13462, 2);
                WriteAttributeValue("", 13422, "emptyPy_", 13422, 8, true);
#nullable restore
#line 295 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 13430, item.TB_PROYECTO.NombreProyecto, 13430, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                                                    <div class=""empty-img"">
                                                        <img src=""https://miro.medium.com/max/875/1*CsJ05WEGfunYMLGfsT2sXA.gif"" height=""128"">
                                                    </div>
                                                    <p class=""empty-title"">Cargando """);
#nullable restore
#line 299 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
                                                                                Write(item.TB_PROYECTO.NombreProyecto);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"</p>\r\n                                                </div>\r\n\r\n                                            </div>\r\n");
#nullable restore
#line 303 "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Index.cshtml"
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
