#pragma checksum "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74e6142b8acbd39c71c19ad9befdd4162c5c9c32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fitness_OneClass), @"mvc.1.0.view", @"/Views/Fitness/OneClass.cshtml")]
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
#line 1 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\_ViewImports.cshtml"
using FitnessProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\_ViewImports.cshtml"
using FitnessProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74e6142b8acbd39c71c19ad9befdd4162c5c9c32", @"/Views/Fitness/OneClass.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff1ba7cc9b995f879724c86605e967437c1b7731", @"/Views/_ViewImports.cshtml")]
    public class Views_Fitness_OneClass : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Container>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditClass", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Fitness", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteClass", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UnRSVP", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RSVP", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 div-class-photo\"><img");
            BeginWriteAttribute("src", " src=\"", 86, "\"", 115, 1);
#nullable restore
#line 4 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
WriteAttributeValue("", 92, Model.Class.ClassPhoto, 92, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 116, "\"", 144, 1);
#nullable restore
#line 4 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
WriteAttributeValue("", 122, Model.Class.ClassName, 122, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <h1>");
#nullable restore
#line 9 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
       Write(Model.Class.ClassName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" with ");
#nullable restore
#line 9 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
                                   Write(Model.Class.Instructor.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        <h5>Class Date: ");
#nullable restore
#line 10 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
                   Write(Model.Class.ClassDate.ToString("MMMM dd yyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <h5>Guests:</h5>\r\n        <ul>\r\n");
#nullable restore
#line 13 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
             foreach (var rsvp in Model.AllRSVPs)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>");
#nullable restore
#line 15 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
               Write(rsvp.Attendee.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 15 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
                                        Write(rsvp.Attendee.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 16 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n");
#nullable restore
#line 18 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
          
            if (User.IsInRole("Instructor"))
            {
                if (Model.Class.InstructorId == Model.LoggedInstructor.InstructorId)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74e6142b8acbd39c71c19ad9befdd4162c5c9c328444", async() => {
                WriteLiteral("Edit Class");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-classId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 23 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
                                                                              WriteLiteral(Model.Class.ClassId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["classId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-classId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["classId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74e6142b8acbd39c71c19ad9befdd4162c5c9c3210976", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-classId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
                                                                                WriteLiteral(Model.Class.ClassId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["classId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-classId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["classId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 27 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
                }
            }
            if (@Model.Class.Attending != null)
            {
                if (@Model.Class.Attending.Any(a => a.UserId == Model.LoggedUser.Id))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74e6142b8acbd39c71c19ad9befdd4162c5c9c3213902", async() => {
                WriteLiteral("<button\r\n                    class=\"btn btn-sm btn-warning\">Leave</button>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-classId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
                                                                           WriteLiteral(Model.Class.ClassId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["classId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-classId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["classId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 35 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74e6142b8acbd39c71c19ad9befdd4162c5c9c3216668", async() => {
                WriteLiteral("<button\r\n                        class=\"btn btn-sm btn-primary\">Join</button>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-classId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
                                                                         WriteLiteral(Model.Class.ClassId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["classId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-classId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["classId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 40 "C:\Users\mimi_\Documents\Projects\FitnessProject\Views\Fitness\OneClass.cshtml"
                }
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"col-md-6\">\r\n        <p>Placeholder for video</p>\r\n    </div>\r\n    \r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Container> Html { get; private set; }
    }
}
#pragma warning restore 1591
