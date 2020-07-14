#pragma checksum "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4490299ac1c976a377e010755e08aafb6969e7bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Jobs_Index), @"mvc.1.0.view", @"/Views/Jobs/Index.cshtml")]
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
#line 1 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\_ViewImports.cshtml"
using JobFinder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\_ViewImports.cshtml"
using JobFinder.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4490299ac1c976a377e010755e08aafb6969e7bd", @"/Views/Jobs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f566a44b2c43ba4ef385023ba109af4cd7cdf64", @"/Views/_ViewImports.cshtml")]
    public class Views_Jobs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<JobFinder.Models.JobListing>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"read-section\">\r\n        <h1>Job listings</h1>\r\n\r\n");
#nullable restore
#line 11 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
          
            if (Model.Count() > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"cards\">\r\n");
#nullable restore
#line 15 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"card\">\r\n                            <div class=\"card-title\">\r\n                                Title:\r\n                                ");
#nullable restore
#line 20 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                Location:\r\n                                ");
#nullable restore
#line 24 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                Region:\r\n                                ");
#nullable restore
#line 28 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Region));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                Type:\r\n                                ");
#nullable restore
#line 32 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                Added At:\r\n                                ");
#nullable restore
#line 36 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.JobListingAddedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                Industry:\r\n                                ");
#nullable restore
#line 40 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Category.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                Company:\r\n                                ");
#nullable restore
#line 44 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Company.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n\r\n                            <div class=\"card-actions\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4490299ac1c976a377e010755e08aafb6969e7bd7610", async() => {
                WriteLiteral("Job Details");
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
#line 48 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
                                                          WriteLiteral(item.JobListingId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 51 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 53 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
            } else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p class=\"no-entries__message\">Unfortunately, there are no jobs listed on this site yet. Try again later.</p>\r\n");
#nullable restore
#line 56 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Jobs\Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<JobFinder.Models.JobListing>> Html { get; private set; }
    }
}
#pragma warning restore 1591
