#pragma checksum "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04a962d69f4acb7e1992e421e8081d734e553375"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Applications_Create), @"mvc.1.0.view", @"/Views/Applications/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04a962d69f4acb7e1992e421e8081d734e553375", @"/Views/Applications/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f566a44b2c43ba4ef385023ba109af4cd7cdf64", @"/Views/_ViewImports.cshtml")]
    public class Views_Applications_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btl-anchor"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Jobs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"jobs-crud\">\r\n        <h2>Submit your application</h2>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04a962d69f4acb7e1992e421e8081d734e5533754980", async() => {
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"JobListingId\"");
                BeginWriteAttribute("value", " value=\"", 250, "\"", 276, 1);
#nullable restore
#line 9 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
WriteAttributeValue("", 258, ViewData["JobId"], 258, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/>\r\n");
#nullable restore
#line 10 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
              
                if ((byte)ViewData["showWorkExperienceFields"] == 1)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <div class=""subfield-title"">Your most recent Work Experience</div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">Company Name</label>
                        <input class=""form-control"" name=""workExpCompanyName"" placeholder=""Enter previous or current company name...""required/>
                    </div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">Start Date</label>
                        <input type=""date"" class=""form-control"" name=""workExpStartDate"" required/>
                    </div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">End Date</label>
                        <input type=""date"" class=""form-control"" name=""workExpEndDate"" required/>
                    </div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">Position</label>
               ");
                WriteLiteral(@"         <input class=""form-control"" name=""workExpPosition"" placeholder=""Enter position held in the company...""required/>
                    </div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">Responsibilities</label>
                        <textarea class=""form-control"" name=""workExpResponsibilities"" rows=""10"" 
                                  placeholder=""Enter brief responsibilites on the position, using words such as accomplished, achieved, acquired,competed, compiled, conceived, consolidated,established, expedited, evaluated, increased, initiated, investigated,provided, published,represented,obtained,volunteered..."" required></textarea>
                    </div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">Duties</label>
                        <textarea class=""form-control"" name=""workExpDuties"" rows=""10"" required placeholder=""Enter brief duties on the position...""></textarea>
                WriteLiteral("\n                    </div>\r\n");
#nullable restore
#line 39 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
                }
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
              
                if ((byte)ViewData["showEducationFields"] == 1)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <div class=""subfield-title"">Your highest Educational level to date</div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">School Name</label>
                        <input class=""form-control"" name=""schoolName"" placeholder=""Enter the university/college/institution/school name..."" required/>
                    </div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">Start Date</label>
                        <input type=""date"" class=""form-control"" name=""educationStartDate"" required/>
                    </div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">End Date</label>
                        <input type=""date"" class=""form-control"" name=""educationEndDate"" required/>
                    </div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">Degree</label>
 ");
                WriteLiteral("                       <input class=\"form-control\" name=\"educationDegree\" placeholder=\"Enter the degree/diploma/calification obtained...\" required/>\r\n                    </div>\r\n");
#nullable restore
#line 61 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
                }
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
              
                if ((byte)ViewData["showSkillsFields"] == 1)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <div class=""subfield-title"">Your most valuable skill for the current job listing</div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">Skill</label>
                        <input class=""form-control"" name=""skillName"" placeholder=""Enter your skill"" required/>
                    </div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">Skill Rating (from 1 to 5)</label>
                        <input type=""number"" min=""1"" max=""5"" class=""form-control"" value=""1"" name=""skillRating"" required/>
                    </div>
                    <div class=""form-jobs-group"">
                        <label class=""control-label"">Description (optional)</label>
                        <input class=""form-control"" name=""skillDescription"" placeholder=""Enter any description related to the said skill if needed...""/>
                    </div>
");
#nullable restore
#line 79 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
                }
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
              
                if ((byte)ViewData["showOtherNotes"] == 1)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <div class=""subfield-title"">Other mentions you would like to make.</div>
                    <div class=""form-jobs-group"">
                        <textarea name=""otherNotes"" rows=""10"" placeholder=""Enter anyother mentions you would like the HR to see...""></textarea>
                    </div>
");
#nullable restore
#line 88 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Send application\" class=\"btn btn-primary\" />\r\n            </div>\r\n            <div>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04a962d69f4acb7e1992e421e8081d734e55337512778", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 94 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
                                                                                   WriteLiteral(ViewData["JobId"]);

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
                WriteLiteral("\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 100 "C:\Users\danie\source\repos\JobFinderTwo\JobFinderTwo\Views\Applications\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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