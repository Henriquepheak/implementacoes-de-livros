#pragma checksum "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8aec932edd6e5107538f18007b6157b295a4a7ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Instituicao_Index), @"mvc.1.0.view", @"/Views/Instituicao/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Instituicao/Index.cshtml", typeof(AspNetCore.Views_Instituicao_Index))]
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
#line 1 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\_ViewImports.cshtml"
using Capitulo01;

#line default
#line hidden
#line 2 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\_ViewImports.cshtml"
using Capitulo01.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8aec932edd6e5107538f18007b6157b295a4a7ba", @"/Views/Instituicao/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbbd315d6a61bbb8e2bff28440d44c4ec4b141e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Instituicao_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Capitulo01.Models.Instituicao>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(80, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(109, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df1760157c3e4e7f83fb2dcb494ee082", async() => {
                BeginContext(115, 87, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Index</title>\r\n");
                EndContext();
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
            EndContext();
            BeginContext(209, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(211, 1188, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "180ee999dc6a44a99de23875d2d8e606", async() => {
                BeginContext(217, 11, true);
                WriteLiteral("\r\n<p>\r\n    ");
                EndContext();
                BeginContext(228, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "297a8b4e47b9459d8bc77e0019440ad5", async() => {
                    BeginContext(251, 22, true);
                    WriteLiteral("Criar nova instituição");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(277, 92, true);
                WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
                EndContext();
                BeginContext(370, 49, false);
#line 22 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.InstituicaoID));

#line default
#line hidden
                EndContext();
                BeginContext(419, 55, true);
                WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
                EndContext();
                BeginContext(475, 40, false);
#line 25 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
                EndContext();
                BeginContext(515, 55, true);
                WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
                EndContext();
                BeginContext(571, 44, false);
#line 28 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Endereco));

#line default
#line hidden
                EndContext();
                BeginContext(615, 86, true);
                WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
                EndContext();
#line 34 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
                BeginContext(733, 48, true);
                WriteLiteral("        <tr>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(782, 48, false);
#line 37 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.InstituicaoID));

#line default
#line hidden
                EndContext();
                BeginContext(830, 55, true);
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(886, 39, false);
#line 40 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
                EndContext();
                BeginContext(925, 55, true);
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(981, 43, false);
#line 43 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Endereco));

#line default
#line hidden
                EndContext();
                BeginContext(1024, 55, true);
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(1080, 66, false);
#line 46 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
           Write(Html.ActionLink("Alterar", "Edit",  new { id=item.InstituicaoID }));

#line default
#line hidden
                EndContext();
                BeginContext(1146, 20, true);
                WriteLiteral(" |\r\n                ");
                EndContext();
                BeginContext(1167, 74, false);
#line 47 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
           Write(Html.ActionLink("Mais detalhes", "Details", new { id=item.InstituicaoID }));

#line default
#line hidden
                EndContext();
                BeginContext(1241, 20, true);
                WriteLiteral(" |\r\n                ");
                EndContext();
                BeginContext(1262, 67, false);
#line 48 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete",  new { id=item.InstituicaoID }));

#line default
#line hidden
                EndContext();
                BeginContext(1329, 36, true);
                WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
                EndContext();
#line 51 "C:\Users\evert\Documents\GitHub\asp-net-core-mvc-casa-do-codigo\SolucaoCapitulo01-Revisao01\Capitulo01\Views\Instituicao\Index.cshtml"
}

#line default
#line hidden
                BeginContext(1368, 24, true);
                WriteLiteral("    </tbody>\r\n</table>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1399, 11, true);
            WriteLiteral("\r\n</html>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Capitulo01.Models.Instituicao>> Html { get; private set; }
    }
}
#pragma warning restore 1591
