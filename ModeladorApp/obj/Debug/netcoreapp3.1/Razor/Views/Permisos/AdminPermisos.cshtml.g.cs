#pragma checksum "C:\Users\didie\source\repos\ModeladorApp\ModeladorApp\Views\Permisos\AdminPermisos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c00c5eb6543620df809356e9fa7a33228051c73"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Permisos_AdminPermisos), @"mvc.1.0.view", @"/Views/Permisos/AdminPermisos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c00c5eb6543620df809356e9fa7a33228051c73", @"/Views/Permisos/AdminPermisos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a004a41642ca9f278fa6fb07d1d5fc2e7164305b", @"/Views/_ViewImports.cshtml")]
    public class Views_Permisos_AdminPermisos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ModeladorApp.Models.Entities.TB_PERMISOS>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "CREADOS", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "CONCEDIDOS", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
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
                        Admin de Permisos
                    </h2>
                </div>

                <!-- Page title actions -->

                <div class=""col-auto ms-auto d-print-none"">

                    <div class=""btn-list"">

                        <span class=""d-none d-sm-inline"">
                            <label class=""form-label col-6 col-form-label"">Permisos: </label>
                        </span>

                        <span class=""d-none d-sm-inline"">
                            <select class=""form-select"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c00c5eb6543620df809356e9fa7a33228051c734779", async() => {
                WriteLiteral("CREADOS");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c00c5eb6543620df809356e9fa7a33228051c735971", async() => {
                WriteLiteral("CONCEDIDOS");
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
            WriteLiteral(@"
                            </select>
                        </span>


                        <a href=""#"" class=""btn btn-primary d-none d-sm-inline-block"" data-bs-toggle=""modal"" data-bs-target=""#modal-report"">
                            <!-- Download SVG icon from http://tabler-icons.io/i/plus -->
                            <svg xmlns=""http://www.w3.org/2000/svg"" class=""icon icon-tabler icon-tabler-search"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round"">
                                <path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none""></path>
                                <circle cx=""10"" cy=""10"" r=""7""></circle>
                                <line x1=""21"" y1=""21"" x2=""15"" y2=""15""></line>
                            </svg>
                            Mostrar
                        </a>
                        <a href=""#"" class=""btn btn-primary d-sm-none btn-icon"" data-bs-toggle=""modal"" data-bs-tar");
            WriteLiteral(@"get=""#modal-report"" aria-label=""Create new report"">
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

                <div class=""col-lg-12"">
                    <div class=""row row-cards"">

                        <div class=""col-12"">
                            <div class=""card"">
                                <div class=""table-responsive"">
          ");
            WriteLiteral(@"                          <table class=""table table-vcenter table-mobile-md card-table"">
                                        <thead>
                                            <tr>
                                                <th>Name</th>
                                                <th>Title</th>
                                                <th>Role</th>
                                                <th class=""w-1""></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td data-label=""Name"">
                                                    <div class=""d-flex py-1 align-items-center"">
                                                        <span class=""avatar me-2"" style=""background-image: url(./static/avatars/010m.jpg)""></span>
                                                        ");
            WriteLiteral(@"<div class=""flex-fill"">
                                                            <div class=""font-weight-medium"">Thatcher Keel</div>
                                                            <div class=""text-muted""><a href=""#"" class=""text-reset"">tkeelf@blogger.com</a></div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td data-label=""Title"">
                                                    <div>VP Sales</div>
                                                    <div class=""text-muted"">Business Development</div>
                                                </td>
                                                <td class=""text-muted"" data-label=""Role"">
                                                    User
                                                </td>
                                                <td>");
            WriteLiteral(@"
                                                    <div class=""btn-list flex-nowrap"">
                                                        <a href=""#"" class=""btn btn-white"">
                                                            Edit
                                                        </a>
                                                        <div class=""dropdown"">
                                                            <button class=""btn dropdown-toggle align-text-top"" data-bs-boundary=""viewport"" data-bs-toggle=""dropdown"">
                                                                Actions
                                                            </button>
                                                            <div class=""dropdown-menu dropdown-menu-end"">
                                                                <a class=""dropdown-item"" href=""#"">
                                                                    Action
                                         ");
            WriteLiteral(@"                       </a>
                                                                <a class=""dropdown-item"" href=""#"">
                                                                    Another action
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td data-label=""Name"">
                                                    <div class=""d-flex py-1 align-items-center"">
                                                        <span class=""avatar me-2"" style=""background-image: url(./static/avatars/005f.jpg)""></span>
                                                        <div class=""flex-fi");
            WriteLiteral(@"ll"">
                                                            <div class=""font-weight-medium"">Dyann Escala</div>
                                                            <div class=""text-muted""><a href=""#"" class=""text-reset"">descalag@usatoday.com</a></div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td data-label=""Title"">
                                                    <div>Mechanical Systems Engineer</div>
                                                    <div class=""text-muted"">Sales</div>
                                                </td>
                                                <td class=""text-muted"" data-label=""Role"">
                                                    Admin
                                                </td>
                                                <td>
           ");
            WriteLiteral(@"                                         <div class=""btn-list flex-nowrap"">
                                                        <a href=""#"" class=""btn btn-white"">
                                                            Edit
                                                        </a>
                                                        <div class=""dropdown"">
                                                            <button class=""btn dropdown-toggle align-text-top"" data-bs-boundary=""viewport"" data-bs-toggle=""dropdown"">
                                                                Actions
                                                            </button>
                                                            <div class=""dropdown-menu dropdown-menu-end"">
                                                                <a class=""dropdown-item"" href=""#"">
                                                                    Action
                                                     ");
            WriteLiteral(@"           </a>
                                                                <a class=""dropdown-item"" href=""#"">
                                                                    Another action
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td data-label=""Name"">
                                                    <div class=""d-flex py-1 align-items-center"">
                                                        <span class=""avatar me-2"" style=""background-image: url(./static/avatars/006f.jpg)""></span>
                                                        <div class=""flex-fill"">
      ");
            WriteLiteral(@"                                                      <div class=""font-weight-medium"">Avivah Mugleston</div>
                                                            <div class=""text-muted""><a href=""#"" class=""text-reset"">amuglestonh@intel.com</a></div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td data-label=""Title"">
                                                    <div>Actuary</div>
                                                    <div class=""text-muted"">Sales</div>
                                                </td>
                                                <td class=""text-muted"" data-label=""Role"">
                                                    User
                                                </td>
                                                <td>
                                        ");
            WriteLiteral(@"            <div class=""btn-list flex-nowrap"">
                                                        <a href=""#"" class=""btn btn-white"">
                                                            Edit
                                                        </a>
                                                        <div class=""dropdown"">
                                                            <button class=""btn dropdown-toggle align-text-top"" data-bs-boundary=""viewport"" data-bs-toggle=""dropdown"">
                                                                Actions
                                                            </button>
                                                            <div class=""dropdown-menu dropdown-menu-end"">
                                                                <a class=""dropdown-item"" href=""#"">
                                                                    Action
                                                                </a>
            ");
            WriteLiteral(@"                                                    <a class=""dropdown-item"" href=""#"">
                                                                    Another action
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td data-label=""Name"">
                                                    <div class=""d-flex py-1 align-items-center"">
                                                        <span class=""avatar me-2"">AA</span>
                                                        <div class=""flex-fill"">
                                                            <div class=""font-weight-medium");
            WriteLiteral(@""">Arlie Armstead</div>
                                                            <div class=""text-muted""><a href=""#"" class=""text-reset"">aarmsteadi@yellowpages.com</a></div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td data-label=""Title"">
                                                    <div>VP Quality Control</div>
                                                    <div class=""text-muted"">Accounting</div>
                                                </td>
                                                <td class=""text-muted"" data-label=""Role"">
                                                    Owner
                                                </td>
                                                <td>
                                                    <div class=""btn-list flex-nowrap"">
                ");
            WriteLiteral(@"                                        <a href=""#"" class=""btn btn-white"">
                                                            Edit
                                                        </a>
                                                        <div class=""dropdown"">
                                                            <button class=""btn dropdown-toggle align-text-top"" data-bs-boundary=""viewport"" data-bs-toggle=""dropdown"">
                                                                Actions
                                                            </button>
                                                            <div class=""dropdown-menu dropdown-menu-end"">
                                                                <a class=""dropdown-item"" href=""#"">
                                                                    Action
                                                                </a>
                                                                <a class=""dr");
            WriteLiteral(@"opdown-item"" href=""#"">
                                                                    Another action
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td data-label=""Name"">
                                                    <div class=""d-flex py-1 align-items-center"">
                                                        <span class=""avatar me-2"" style=""background-image: url(./static/avatars/008f.jpg)""></span>
                                                        <div class=""flex-fill"">
                                                            <div class=""font-weight-medium"">Tessie ");
            WriteLiteral(@"Curzon</div>
                                                            <div class=""text-muted""><a href=""#"" class=""text-reset"">tcurzonj@hp.com</a></div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td data-label=""Title"">
                                                    <div>Research Nurse</div>
                                                    <div class=""text-muted"">Product Management</div>
                                                </td>
                                                <td class=""text-muted"" data-label=""Role"">
                                                    Admin
                                                </td>
                                                <td>
                                                    <div class=""btn-list flex-nowrap"">
                                 ");
            WriteLiteral(@"                       <a href=""#"" class=""btn btn-white"">
                                                            Edit
                                                        </a>
                                                        <div class=""dropdown"">
                                                            <button class=""btn dropdown-toggle align-text-top"" data-bs-boundary=""viewport"" data-bs-toggle=""dropdown"">
                                                                Actions
                                                            </button>
                                                            <div class=""dropdown-menu dropdown-menu-end"">
                                                                <a class=""dropdown-item"" href=""#"">
                                                                    Action
                                                                </a>
                                                                <a class=""dropdown-item"" href");
            WriteLiteral(@"=""#"">
                                                                    Another action
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
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
