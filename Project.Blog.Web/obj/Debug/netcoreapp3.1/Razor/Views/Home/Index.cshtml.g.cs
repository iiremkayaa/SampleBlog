#pragma checksum "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0306c7d7561d202d9177741af5141de4b7b1fbac"
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
#line 2 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\_ViewImports.cshtml"
using Project.Blog.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\_ViewImports.cshtml"
using Project.Blog.Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0306c7d7561d202d9177741af5141de4b7b1fbac", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19b6d8ad9a4c66b3c069eb8bb82848aa43827809", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SharingListModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "GET", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\Home\Index.cshtml"
   
    /*string convertDate(DateTime sharingDate)
    {

        var difference = (DateTime.Now - sharingDate).TotalDays;
        if (difference < 1)
        {
            difference = Convert.ToInt32((DateTime.Now - sharingDate).TotalHours);
            if (difference == 0)
            {
                return Convert.ToInt32((DateTime.Now - sharingDate).TotalMinutes).ToString() + " minutes ago";
            }
            else
            {
                return Convert.ToInt32((DateTime.Now - sharingDate).TotalHours).ToString() + " hours ago";

            }

        }
        else if (difference > 1 && difference < 30)
        {
            return Convert.ToInt32(difference).ToString() + " days ago";
        }
        else if (difference > 30 && difference < 365)
        {
            return Convert.ToInt32((((DateTime.Now - sharingDate).TotalDays) / 30) - 1).ToString() + " months ago";

        }
        else if (difference > 365)
        {
            return Convert.ToInt32((((DateTime.Now - sharingDate).TotalDays) / 365)).ToString() + " years ago";
        }
        else
        {
            return "";
        }

    }*/

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"col-md-8\">\r\n   \r\n    <div class=\"my-4\">\r\n");
#nullable restore
#line 49 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\Home\Index.cshtml"
         foreach (var sharing in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card mb-4\">\r\n                <div class=\"card-body\">\r\n                    <h2 class=\"card-title\">");
#nullable restore
#line 53 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\Home\Index.cshtml"
                                      Write(sharing.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <p class=\"lead\">\r\n                        By\r\n                        <a href=\"#\">");
#nullable restore
#line 56 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\Home\Index.cshtml"
                               Write(sharing.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </p>\r\n                    \r\n                    <p class=\"card-text\">");
#nullable restore
#line 59 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\Home\Index.cshtml"
                                    Write(sharing.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0306c7d7561d202d9177741af5141de4b7b1fbac7983", async() => {
                WriteLiteral("See Comments");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\Home\Index.cshtml"
                                             WriteLiteral(sharing.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"card-footer text-muted\">\r\n");
            WriteLiteral("                    ");
#nullable restore
#line 66 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\Home\Index.cshtml"
               Write(sharing.SharingDate.ToString("dddd, MMMM dd yyyy", new System.Globalization.CultureInfo("en-US")));

#line default
#line hidden
#nullable disable
            WriteLiteral(" by  <a href=\"#\">");
#nullable restore
#line 66 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\Home\Index.cshtml"
                                                                                                                                  Write(sharing.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\r\n                </div>\r\n\r\n            </div>\r\n");
#nullable restore
#line 71 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <ul class=""pagination justify-content-center mb-4"">
            <li class=""page-item"">
                <a class=""page-link"" href=""#"">&larr; Older</a>
            </li>
            <li class=""page-item disabled"">
                <a class=""page-link"" href=""#"">Newer &rarr;</a>
            </li>
        </ul>
    </div>

    <!-- Pagination -->


</div>

<!-- Sidebar Widgets Column -->
<div class=""col-md-4"">

    <!-- Search Widget -->
    <div class=""card my-4"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0306c7d7561d202d9177741af5141de4b7b1fbac11834", async() => {
                WriteLiteral("\r\n            <h5 class=\"card-header\">Search</h5>\r\n            <div class=\"card-body\">\r\n                <div class=\"input-group\">\r\n                    <input name=\"key\" type=\"text\" class=\"form-control\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 2937, "\"", 2951, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                    <span class=\"input-group-append\">\r\n                        <button class=\"btn btn-primary\" type=\"submit\">Search</button>\r\n                    </span>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n    <!-- Categories Widget -->\r\n    ");
#nullable restore
#line 107 "C:\Users\Irem\Documents\GitHub\BlogMvc\Project.Blog.Web\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("CategoryList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SharingListModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
