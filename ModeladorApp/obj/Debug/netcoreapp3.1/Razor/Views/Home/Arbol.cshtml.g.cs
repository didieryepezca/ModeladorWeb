#pragma checksum "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Home\Arbol.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f1233bd9fcb27499b4468e7fa09274de50705bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Arbol), @"mvc.1.0.view", @"/Views/Home/Arbol.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f1233bd9fcb27499b4468e7fa09274de50705bb", @"/Views/Home/Arbol.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a004a41642ca9f278fa6fb07d1d5fc2e7164305b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Arbol : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("example"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f1233bd9fcb27499b4468e7fa09274de50705bb3570", async() => {
                WriteLiteral(@"
    <meta http-equiv=""content-type"" content=""text/html; charset=ISO-8859-1"" />

    <title>ON - Modelador Web</title>

    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jquery.fancytree/2.38.0/skin-awesome/ui.fancytree.min.css"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jquery.fancytree/2.38.0/skin-bootstrap-n/ui.fancytree.min.css"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jquery.fancytree/2.38.0/skin-bootstrap/ui.fancytree.min.css"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jquery.fancytree/2.38.0/skin-xp/ui.fancytree.min.css"">

");
                WriteLiteral(@"    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.js""></script>
    <!-- This demo uses an 3rd-party, jQuery UI based context menu -->
    <link href=""//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"" rel=""stylesheet"" />
    <script src=""//code.jquery.com/ui/1.12.1/jquery-ui.min.js""></script>
    <!-- jquery-contextmenu (https://github.com/mar10/jquery-ui-contextmenu/) -->
    <script src=""//cdn.jsdelivr.net/npm/ui-contextmenu/jquery.ui-contextmenu.min.js""></script>

    <style type=""text/css"">
        .ui-menu {
            width: 180px;
            font-size: 63%;
        }

            .ui-menu kbd {
                /* Keyboard shortcuts for ui-contextmenu titles */
                float: right;
            }
        /* custom alignment (set by 'renderColumns'' event) */
        td.alignRight {
            text-align: right;
        }

        td.alignCenter {
            text-align: center;
        }

        td input[type=""input""] {
            wi");
                WriteLiteral(@"dth: 40px;
        }
    </style>

    <script type=""text/javascript"">

        //window.onload = loadMaster();
       

        //async function loadMaster() {
        //    var data = await funGetMasterData()
        //    console.log(data)
        //}
      
        //function funGetMasterData() {
        //    var url = ""/Home/funGetMaster"";
        //    return $.get(url, {}, function (data) {
        //        //console.log(data);
        //    });
        //};

        var CLIPBOARD = null;       

        //var datos = [
        //    {
        //        ""title"": ""Books"", ""expanded"": false, ""folder"": true, ""children"": [
        //            { ""title"": ""Art of War"", ""type"": ""book"", ""author"": ""Sun Tzu"", ""year"": -500, ""qty"": 21, ""price"": 5.95 },
        //            { ""title"": ""The Hobbit"", ""type"": ""book"", ""author"": ""J.R.R. Tolkien"", ""year"": 1937, ""qty"": 32, ""price"": 8.97 },
        //            { ""title"": ""The Little Prince"", ""type"": ""book"", ""author"": ""Antoine de Saint-Exu");
                WriteLiteral(@"pery"", ""year"": 1943, ""qty"": 2946, ""price"": 6.82 },
        //            { ""title"": ""Don Quixote"", ""type"": ""book"", ""author"": ""Miguel de Cervantes"", ""year"": 1615, ""qty"": 932, ""price"": 15.99 }
        //        ]
        //    },
        //    {
        //        ""title"": ""Music"", ""folder"": true, ""children"": [
        //            { ""title"": ""Nevermind"", ""type"": ""music"", ""author"": ""Nirvana"", ""year"": 1991, ""qty"": 916, ""price"": 15.95 },
        //            { ""title"": ""Autobahn"", ""type"": ""music"", ""author"": ""Kraftwerk"", ""year"": 1974, ""qty"": 2261, ""price"": 23.98 },
        //            { ""title"": ""Kind of Blue"", ""type"": ""music"", ""author"": ""Miles Davis"", ""year"": 1959, ""qty"": 9735, ""price"": 21.90 },
        //            { ""title"": ""Back in Black"", ""type"": ""music"", ""author"": ""AC/DC"", ""year"": 1980, ""qty"": 3895, ""price"": 17.99 },
        //            { ""title"": ""The Dark Side of the Moon"", ""type"": ""music"", ""author"": ""Pink Floyd"", ""year"": 1973, ""qty"": 263, ""price"": 17.99 },
        //            { ""title""");
                WriteLiteral(@": ""Sgt. Pepper's Lonely Hearts Club Band"", ""type"": ""music"", ""author"": ""The Beatles"", ""year"": 1967, ""qty"": 521, ""price"": 13.98 }
        //        ]
        //    },
        //    {
        //        ""title"": ""Electronics & Computers"", ""expanded"": false, ""folder"": true, ""children"": [
        //            {
        //                ""title"": ""Cell Phones"", ""folder"": true, ""children"": [
        //                    { ""title"": ""Moto G"", ""type"": ""phone"", ""author"": ""Motorola"", ""year"": 2014, ""qty"": 332, ""price"": 224.99 },
        //                    { ""title"": ""Galaxy S8"", ""type"": ""phone"", ""author"": ""Samsung"", ""year"": 2016, ""qty"": 952, ""price"": 509.99 },
        //                    { ""title"": ""iPhone SE"", ""type"": ""phone"", ""author"": ""Apple"", ""year"": 2016, ""qty"": 444, ""price"": 282.75 },
        //                    { ""title"": ""G6"", ""type"": ""phone"", ""author"": ""LG"", ""year"": 2017, ""qty"": 951, ""price"": 309.99 },
        //                    { ""title"": ""Lumia"", ""type"": ""phone"", ""author"": ""Microsoft"", ""ye");
                WriteLiteral(@"ar"": 2014, ""qty"": 32, ""price"": 205.95 },
        //                    { ""title"": ""Xperia"", ""type"": ""phone"", ""author"": ""Sony"", ""year"": 2014, ""qty"": 77, ""price"": 195.95 },
        //                    { ""title"": ""3210"", ""type"": ""phone"", ""author"": ""Nokia"", ""year"": 1999, ""qty"": 3, ""price"": 85.99 }
        //                ]
        //            },
        //            {
        //                ""title"": ""Computers"", ""folder"": true, ""children"": [
        //                    { ""title"": ""ThinkPad"", ""type"": ""computer"", ""author"": ""IBM"", ""year"": 1992, ""qty"": 16, ""price"": 749.90 },
        //                    { ""title"": ""C64"", ""type"": ""computer"", ""author"": ""Commodore"", ""year"": 1982, ""qty"": 83, ""price"": 595.00 },
        //                    { ""title"": ""MacBook Pro"", ""type"": ""computer"", ""author"": ""Apple"", ""year"": 2006, ""qty"": 482, ""price"": 1949.95 },
        //                    { ""title"": ""Sinclair ZX Spectrum"", ""type"": ""computer"", ""author"": ""Sinclair Research"", ""year"": 1982, ""qty"": 1, ""price"": 529");
                WriteLiteral(@" },
        //                    { ""title"": ""Apple II"", ""type"": ""computer"", ""author"": ""Apple"", ""year"": 1977, ""qty"": 17, ""price"": 1298 },
        //                    { ""title"": ""PC AT"", ""type"": ""computer"", ""author"": ""IBM"", ""year"": 1984, ""qty"": 3, ""price"": 1235.00 }
        //                ]
        //            }
        //        ]
        //    },
        //    { ""title"": ""More..."", ""folder"": true, ""lazy"": true }
        //]

        //console.log(datos);

        $(function () {
            $(""#tree"").fancytree({
               
                titlesTabbable: true, // Add all node titles to TAB chain
                quicksearch: true, // Jump to nodes when pressing first character
                /*source: datos,*/
                //---------------------------------------
                source: $.ajax({
                    dataType: ""json"",
                    url: ""/Home/funGetLvl"",
                    success: function (data) {
                        //console.log(data)
  ");
                WriteLiteral(@"                  }
                }),
                //--------------------------------------
                //source: [{
                //    title: ""Root"",
                //    key: ""1"",
                //    lazy: true,
                //    folder: true
                //}],

                //-------------------------------------- key seria el ID
                //source: {
                //    url: ""/Home/funGetMaster"",
                //    data: { key: 01 },
                //    cache: false
                //},
                
                // Llamada cada vez que se expande un nodo LAZY.
                lazyLoad: function (event, data) {
                  
                    var node = data.node;     //obtenemos el nodo             
                    /*console.log(node.data.id);*/ // obtenemos el id para mandarlo como parent                                 

                    console.log(node.data.parentId)

                    data.result = {
              ");
                WriteLiteral(@"          url: ""/Home/funGetSubLvls"",                       
                        data: { parent: node.data.id },
                        cache: false
                    };
                    
                },             

                extensions: [""edit"", ""dnd5"", ""table"", ""gridnav""],

                dnd5: {
                    preventVoidMoves: true,
                    preventRecursion: true,
                    autoExpandMS: 400,
                    dragStart: function (node, data) {
                        return true;
                    },
                    dragEnter: function (node, data) {
                        // return [""before"", ""after""];
                        return true;
                    },
                    dragDrop: function (node, data) {
                        data.otherNode.moveTo(node, data.hitMode);
                    },
                },
                edit: {
                    triggerStart: [""f2"", ""shift+click"", ""mac+enter""],
       ");
                WriteLiteral(@"             close: function (event, data) {
                        if (data.save && data.isNew) {
                            // Quick-enter: add new nodes until we hit [enter] on an empty title
                            $(""#tree"").trigger(""nodeCommand"", {
                                cmd: ""addSibling"",
                            });
                        }
                    },
                },
                table: {
                    indentation: 20,
                    nodeColumnIdx: 1,
                    //checkboxColumnIdx: 0, //para poner checkboxes en la columna 1
                },
                gridnav: {
                    autofocusInput: false,
                    handleCursorKeys: true,
                },
                createNode: function (event, data) {
                    var node = data.node,
                        $tdList = $(node.tr).find("">td"");

                    // Span the remaining columns if it's a folder.
                    // We can d");
                WriteLiteral(@"o this in createNode instead of renderColumns, because
                    // the `isFolder` status is unlikely to change later
                    if (node.isFolder()) {
                        $tdList
                            .eq(2)
                            .prop(""colspan"", 6)
                            .nextAll()
                            .remove();
                    }
                },
                renderColumns: function (event, data) {
                    var node = data.node,
                        $tdList = $(node.tr).find("">td"");

                    // (Index #0 is rendered by fancytree by adding the checkbox)
                    // Set column #1 info from node data:
                    $tdList.eq(0).text(node.getIndexHier());
                    // (Index #2 is rendered by fancytree)
                    // Podemos setear la información en la columna 2 como por ejemplo el parentId
                    //$tdList
                    //    .eq(2)
                    ");
                WriteLiteral(@"//    .find(""input"")
                    //    .val(node.data.subtitle);

                    $tdList
                        .eq(4)
                        .find(""input"")
                        .val(node.data.foo);

                    // Static markup (more efficiently defined as html row template):
                    // $tdList.eq(3).html(""<input type='input' value='""  """" + ""'>"");
                    // ...
                },
                modifyChild: function (event, data) {
                    data.tree.info(event.type, data);
                },
            })
                .on(""nodeCommand"", function (event, data) {
                    // Custom event handler that is triggered by keydown-handler and
                    // context menu:
                    var refNode,
                        moveMode,
                        tree = $.ui.fancytree.getTree(this),
                        node = tree.getActiveNode();

                    switch (data.cmd) {
                  ");
                WriteLiteral(@"      case ""addChild"":
                        case ""addSibling"":
                        case ""indent"":
                        case ""moveDown"":
                        case ""moveUp"":
                        case ""outdent"":
                        case ""remove"":
                        case ""rename"":
                            tree.applyCommand(data.cmd, node);
                            break;
                        case ""cut"":
                            CLIPBOARD = { mode: data.cmd, data: node };
                            break;
                        case ""copy"":
                            CLIPBOARD = {
                                mode: data.cmd,
                                data: node.toDict(true, function (dict, node) {
                                    delete dict.key;
                                }),
                            };
                            break;
                        case ""clear"":
                            CLIPBOARD = null;
           ");
                WriteLiteral(@"                 break;
                        case ""paste"":
                            if (CLIPBOARD.mode === ""cut"") {
                                // refNode = node.getPrevSibling();
                                CLIPBOARD.data.moveTo(node, ""child"");
                                CLIPBOARD.data.setActive();
                            } else if (CLIPBOARD.mode === ""copy"") {
                                node.addChildren(
                                    CLIPBOARD.data
                                ).setActive();
                            }
                            break;
                        default:
                            alert(""Unhandled command: "" + data.cmd);
                            return;
                    }
                })
                .on(""keydown"", function (e) {
                    var cmd = null;

                    // console.log(e.type, $.ui.fancytree.eventToString(e));
                    switch ($.ui.fancytree.eventToString(e)) {");
                WriteLiteral(@"
                        case ""ctrl+shift+n"":
                        case ""meta+shift+n"": // mac: cmd+shift+n
                            cmd = ""addChild"";
                            break;
                        case ""ctrl+c"":
                        case ""meta+c"": // mac
                            cmd = ""copy"";
                            break;
                        case ""ctrl+v"":
                        case ""meta+v"": // mac
                            cmd = ""paste"";
                            break;
                        case ""ctrl+x"":
                        case ""meta+x"": // mac
                            cmd = ""cut"";
                            break;
                        case ""ctrl+n"":
                        case ""meta+n"": // mac
                            cmd = ""addSibling"";
                            break;
                        case ""del"":
                        case ""meta+backspace"": // mac
                            cmd = ""remove"";
                     ");
                WriteLiteral(@"       break;
                        // case ""f2"":  // already triggered by ext-edit pluging
                        //   cmd = ""rename"";
                        //   break;
                        case ""ctrl+up"":
                        case ""ctrl+shift+up"": // mac
                            cmd = ""moveUp"";
                            break;
                        case ""ctrl+down"":
                        case ""ctrl+shift+down"": // mac
                            cmd = ""moveDown"";
                            break;
                        case ""ctrl+right"":
                        case ""ctrl+shift+right"": // mac
                            cmd = ""indent"";
                            break;
                        case ""ctrl+left"":
                        case ""ctrl+shift+left"": // mac
                            cmd = ""outdent"";
                    }
                    if (cmd) {
                        $(this).trigger(""nodeCommand"", { cmd: cmd });
                        return fal");
                WriteLiteral(@"se;
                    }
                });
           
            /*
             * Tooltips
             */
            // $(""#tree"").tooltip({
            //   content: function () {
            //     return $(this).attr(""title"");
            //   }
            // });

            /*
             * Context menu (https://github.com/mar10/jquery-ui-contextmenu)
             */
            $(""#tree"").contextmenu({
                delegate: ""span.fancytree-node"",
                menu: [
                    {
                        title: ""Editar <kbd>[F2]</kbd>"",
                        cmd: ""rename"",
                        uiIcon: ""ui-icon-pencil"",
                    },
                    {
                        title: ""Eliminar <kbd>[Del]</kbd>"",
                        cmd: ""remove"",
                        uiIcon: ""ui-icon-trash"",
                    },
                    { title: ""----"" },
                    {
                        title: ""Nvo Hermano <kbd>[Ctr");
                WriteLiteral(@"l+N]</kbd>"",
                        cmd: ""addSibling"",
                        uiIcon: ""ui-icon-plus"",
                    },
                    {
                        title: ""Nvo Hijo <kbd>[Ctrl+Shift+N]</kbd>"",
                        cmd: ""addChild"",
                        uiIcon: ""ui-icon-arrowreturn-1-e"",
                    },
                    { title: ""----"" },
                    {
                        title: ""Cortar <kbd>Ctrl+X</kbd>"",
                        cmd: ""cut"",
                        uiIcon: ""ui-icon-scissors"",
                    },
                    {
                        title: ""Copiar <kbd>Ctrl-C</kbd>"",
                        cmd: ""copy"",
                        uiIcon: ""ui-icon-copy"",
                    },
                    {
                        title: ""Pegar as child<kbd>Ctrl+V</kbd>"",
                        cmd: ""paste"",
                        uiIcon: ""ui-icon-clipboard"",
                        disabled: true,
                   ");
                WriteLiteral(@" },
                ],
                beforeOpen: function (event, ui) {
                    var node = $.ui.fancytree.getNode(ui.target);
                    $(""#tree"").contextmenu(
                        ""enableEntry"",
                        ""paste"",
                        !!CLIPBOARD
                    );
                    node.setActive();
                },
                select: function (event, ui) {
                    var that = this;
                    // delay the event, so the menu can close and the click event does
                    // not interfere with the edit control
                    setTimeout(function () {
                        $(that).trigger(""nodeCommand"", { cmd: ui.cmd });
                    }, 100);
                },
            });



        });


        function expandOrContract() {         

            $(""#tree"").fancytree(""getRootNode"").visit(function (node) {               
                if (node.isExpanded() == true) {
         ");
                WriteLiteral("           node.setExpanded(false);\r\n                } else {\r\n                    node.setExpanded(true);\r\n                }                \r\n            });\r\n        }\r\n\r\n\r\n    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f1233bd9fcb27499b4468e7fa09274de50705bb25246", async() => {
                WriteLiteral("\r\n");
                WriteLiteral(@"
    <ul class=""nav nav-tabs nav-fill"" data-bs-toggle=""tabs"">
        <li class=""nav-item"">
            <a href=""#master"" class=""nav-link active""
               data-bs-toggle=""tab""><strong>MASTER</strong></a>
        </li>
        <li class=""nav-item"">
            <a href=""#py1"" class=""nav-link""
               data-bs-toggle=""tab"">Proyecto 1 </a>
        </li>
        <li class=""nav-item"">
            <a href=""#py2"" class=""nav-link""
               data-bs-toggle=""tab"">Proyecto 2</a>
        </li>
    </ul>

    <div class=""tab-content"">
        <div class=""tab-pane show active"" id=""master"">

            <span class=""d-none d-sm-inline"">
                <a onclick=""expandOrContract()"" class=""btn btn-primary"">
                    Expandir/Contraer
                </a>
            </span>

            <table id=""tree"">
                <colgroup>
                    <col width=""30px"" />
                    <col width=""450px"" />
                    <col width=""30px"" />
              ");
                WriteLiteral(@"      <col width=""30px"" />
                    <col width=""30px"" />
                    <col width=""30px"" />
                    <col width=""30px"" />
                    <col width=""50px"" />
                    <col width=""50px"" />
                    <col width=""50px"" />
                    <col width=""50px"" />
                    <col width=""50px"" />
                </colgroup>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Identificador</th>
                        <th>Nombre</th>
                        <th>2</th>
                        <th>3</th>
                        <th>4</th>
                        <th>5</th>
                        <th>6</th>
                        <th>7</th>
                        <th>8</th>
                        <th>9</th>
                        <th>10</th>
                        <th>11</th>
                        <th>12</th>
                        <th>13</th>
                   ");
                WriteLiteral(@"     <th>14</th>
                        <th>15</th>
                        <th>16</th>
                        <th>17</th>
                        <th>18</th>
                        <th>19</th>
                        <th>20</th>
                    </tr>
                </thead>
                <tbody>
                    <!-- Define a row template for all invariant markup: -->
                    <tr>                      
                        <td></td>
                        <td><input");
                BeginWriteAttribute("name", " name=\"", 23622, "\"", 23629, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 23673, "\"", 23680, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 23724, "\"", 23731, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 23775, "\"", 23782, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 23826, "\"", 23833, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 23877, "\"", 23884, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 23928, "\"", 23935, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 23979, "\"", 23986, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24030, "\"", 24037, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24081, "\"", 24088, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24132, "\"", 24139, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24183, "\"", 24190, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24234, "\"", 24241, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24285, "\"", 24292, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24336, "\"", 24343, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24387, "\"", 24394, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24438, "\"", 24445, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24489, "\"", 24496, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24540, "\"", 24547, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24591, "\"", 24598, 0);
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                        <td><input");
                BeginWriteAttribute("name", " name=\"", 24642, "\"", 24649, 0);
                EndWriteAttribute();
                WriteLiteral(@"/></td>
                    </tr>
                </tbody>
            </table>

        </div>

        <div class=""tab-pane show"" id=""py1"">
            <a><strong>Este es mi proyecto 1!</strong></a>
        </div>

        <div class=""tab-pane show"" id=""py2"">
            <a><strong>Este es mi proyecto 2!</strong></a>
        </div>

    </div>

    <!-- (Irrelevant source removed.) -->
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery.fancytree/2.38.0/jquery.fancytree-all-deps.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery.fancytree/2.38.0/jquery.fancytree.min.js""></script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
