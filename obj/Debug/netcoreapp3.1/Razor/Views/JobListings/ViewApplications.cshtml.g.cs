#pragma checksum "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0fcf53cadb9079a76a56b054744ba7917fe4171a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_JobListings_ViewApplications), @"mvc.1.0.view", @"/Views/JobListings/ViewApplications.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fcf53cadb9079a76a56b054744ba7917fe4171a", @"/Views/JobListings/ViewApplications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f566a44b2c43ba4ef385023ba109af4cd7cdf64", @"/Views/_ViewImports.cshtml")]
    public class Views_JobListings_ViewApplications : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Application>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btl-anchor"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Applications", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
  
    ViewData["Title"] = "View applications";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"read-section\">\r\n    <h1>Current applications for this job listing</h1>\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fcf53cadb9079a76a56b054744ba7917fe4171a5149", async() => {
                WriteLiteral("Back to dashboard");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"cards cards-joblistings\">\r\n");
#nullable restore
#line 15 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
          
            if (Model.Count() > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"cards\">\r\n");
#nullable restore
#line 19 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"card\">\r\n                            <div class=\"card-title\">\r\n                                ");
#nullable restore
#line 23 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.JobListing.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-title\">\r\n                                ");
#nullable restore
#line 26 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.JobListing.Position));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                ");
#nullable restore
#line 29 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.JobListing.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                ");
#nullable restore
#line 32 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.JobListing.Region));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 32 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                                                                                  Write(Html.DisplayFor(modelItem => item.JobListing.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                ");
#nullable restore
#line 35 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.JobListing.Company.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                ");
#nullable restore
#line 38 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.JobListing.Category.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                ");
#nullable restore
#line 41 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ApplicationWrittenAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                by ");
#nullable restore
#line 44 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                              Write(Html.DisplayFor(modelItem => item.JobFinderUser.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 44 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                                                                                         Write(Html.DisplayFor(modelItem => item.JobFinderUser.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-description\">\r\n                                ");
#nullable restore
#line 47 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n\r\n                            <div class=\"card-actions\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fcf53cadb9079a76a56b054744ba7917fe4171a12046", async() => {
                WriteLiteral("View");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-applicationId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                                                                                                   WriteLiteral(item.ApplicationId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["applicationId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-applicationId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["applicationId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 54 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 56 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p class=\"no-entries__message\">Unfortunately, you haven\'t received any job applications.</p>\r\n");
#nullable restore
#line 60 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\JobListings\ViewApplications.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Application>> Html { get; private set; }
    }
}
#pragma warning restore 1591
