#pragma checksum "C:\Users\henri\Desktop\AgroTools\Views\Usuario\Panel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48e7644f7215c26bd8d5fdf06bb9825ad2fce2e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Panel), @"mvc.1.0.view", @"/Views/Usuario/Panel.cshtml")]
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
#line 1 "C:\Users\henri\Desktop\AgroTools\Views\_ViewImports.cshtml"
using AgroTools;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\henri\Desktop\AgroTools\Views\_ViewImports.cshtml"
using AgroTools.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48e7644f7215c26bd8d5fdf06bb9825ad2fce2e9", @"/Views/Usuario/Panel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c99208d253d3280947f4a7753d65f6cc598990c8", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Panel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AgroTools.ViewModels.QuestionarioViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("botao-criar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Questionario", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<main >
    <div class=""container-panel"">
        <div class=""panel-container"">
            <div class=""panel-novo"">

                <div class=""d-flex flex-column align-items-center"">
                    <h3>Criar novo questionario</h3>
                    <div class=""d-flex flex-column align-items-center"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48e7644f7215c26bd8d5fdf06bb9825ad2fce2e94350", async() => {
                WriteLiteral("\r\n                    <div class=\"botao-novo\">\r\n                        <i class=\"fas fa-plus\"></i>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <h3>Nova folha</h3>
                    </div>
                </div>
            </div> 
            <div class=""panel-quests"">
                <div class=""buscar-quests"">
                    <h2>Questionarios criados</h2>
                </div>
                <div class=""questionarios"">
");
#nullable restore
#line 24 "C:\Users\henri\Desktop\AgroTools\Views\Usuario\Panel.cshtml"
                     foreach (var item in Model.questionarios)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"item-quest\">\r\n                        <div class=\"item-quest-titulo\">\r\n                            <input");
            BeginWriteAttribute("value", " value=\"", 1153, "\"", 1173, 1);
#nullable restore
#line 28 "C:\Users\henri\Desktop\AgroTools\Views\Usuario\Panel.cshtml"
WriteAttributeValue("", 1161, item.Titulo, 1161, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text\" />\r\n                        </div>\r\n                        <div class=\"item-quest-descricao\">\r\n                            <p>");
#nullable restore
#line 31 "C:\Users\henri\Desktop\AgroTools\Views\Usuario\Panel.cshtml"
                          Write(item.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"item-quest-url\">\r\n                            <p>Link para responder</p>\r\n                        <input");
            BeginWriteAttribute("value", " value=\"", 1507, "\"", 1562, 2);
            WriteAttributeValue("", 1515, "https://localhost:5001/MyQuestionario/", 1515, 38, true);
#nullable restore
#line 35 "C:\Users\henri\Desktop\AgroTools\Views\Usuario\Panel.cshtml"
WriteAttributeValue("", 1553, item.Url, 1553, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text\" />\r\n                        </div>\r\n\r\n                        <a");
            BeginWriteAttribute("href", " href=\'", 1640, "\'", 1710, 1);
#nullable restore
#line 38 "C:\Users\henri\Desktop\AgroTools\Views\Usuario\Panel.cshtml"
WriteAttributeValue("", 1647, Url.Action("ListarQuestionario","Usuario", new {ID = item.ID}), 1647, 63, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Ver mais</a>\r\n                    </div>\r\n");
#nullable restore
#line 40 "C:\Users\henri\Desktop\AgroTools\Views\Usuario\Panel.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AgroTools.ViewModels.QuestionarioViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
