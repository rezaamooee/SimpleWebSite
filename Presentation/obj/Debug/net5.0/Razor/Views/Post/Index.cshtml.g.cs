#pragma checksum "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1344cbe65371289ac799f77e81517a276edb839c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Index), @"mvc.1.0.view", @"/Views/Post/Index.cshtml")]
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
#line 1 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\_ViewImports.cshtml"
using Presentation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\_ViewImports.cshtml"
using Presentation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1344cbe65371289ac799f77e81517a276edb839c", @"/Views/Post/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aca7828e27a152be4cd8b1f2c1fa15ad084747ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Common.ViewModel.Post.PostAbsVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1344cbe65371289ac799f77e81517a276edb839c3854", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Author.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ??????????\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PicSRC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ABS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 41 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Author.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Topic.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 56 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PicSRC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 59 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ABS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 62 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 65 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id = item.ID/* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 66 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id = item.ID /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 67 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id = item.ID /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 70 "E:\UserFile\Project\WebSite\BasicalyPersonalWebsite\BasicalyPersonalWebsite\Presentation\Views\Post\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Common.ViewModel.Post.PostAbsVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
