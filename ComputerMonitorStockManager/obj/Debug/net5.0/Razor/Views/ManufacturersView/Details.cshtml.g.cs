#pragma checksum "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe762b6abeb1bfe4a43c58841af9cada9c1550da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManufacturersView_Details), @"mvc.1.0.view", @"/Views/ManufacturersView/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe762b6abeb1bfe4a43c58841af9cada9c1550da", @"/Views/ManufacturersView/Details.cshtml")]
    public class Views_ManufacturersView_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DomainLayer.Models.Manufacturers>
    {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe762b6abeb1bfe4a43c58841af9cada9c1550da2781", async() => {
                WriteLiteral(@"
    <style>
        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            border: 1px solid #006600;
            background-color: #f1f1c1;
        }

        li {
            float: left;
        }

            li a {
                display: block;
                color: #666;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
            }

                li a:hover:not(.active) {
                    color: white;
                    background-color: #006600;
                }
    </style>
");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe762b6abeb1bfe4a43c58841af9cada9c1550da4408", async() => {
                WriteLiteral("\r\n\r\n    <ul>\r\n        <li><a");
                BeginWriteAttribute("href", " href=\"", 756, "\"", 790, 1);
#nullable restore
#line 35 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
WriteAttributeValue("", 763, Url.Action("Index","Home"), 763, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Home</a></li>\r\n        <li><a");
                BeginWriteAttribute("href", " href=\"", 821, "\"", 876, 1);
#nullable restore
#line 36 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
WriteAttributeValue("", 828, Url.Action("Manufacturers","ManufacturersView"), 828, 48, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Manufacturers</a></li>\r\n        <li><a");
                BeginWriteAttribute("href", " href=\"", 916, "\"", 961, 1);
#nullable restore
#line 37 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
WriteAttributeValue("", 923, Url.Action("Monitors","MonitorsView"), 923, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Monitors</a></li>\r\n    </ul>\r\n\r\n");
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 42 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
  
    ViewData["Title"] = "ManufacturerDetails";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div>
    <h1>Manufacturer details</h1>
    <hr />
</div>


<style>
    table, th, td {
        border: 1px solid #006600;
        border-collapse: collapse;
    }

    th {
        padding: 8px;
        text-align: left;
    }

    td {
        padding: 5px;
        text-align: left;
    }

    table.manufacturer {
        width: 50%;
        background-color: #f1f1c1;
    }
</style>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe762b6abeb1bfe4a43c58841af9cada9c1550da7430", async() => {
                WriteLiteral("\r\n    <table class=\"manufacturer\">\r\n        <tr>\r\n            <th>");
#nullable restore
#line 77 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
           Write(Html.DisplayName("ID:"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n            <td>");
#nullable restore
#line 78 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
           Write(Html.DisplayFor(model => model.ManufacturerID));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>");
#nullable restore
#line 81 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
           Write(Html.DisplayName("Name:"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n            <td>");
#nullable restore
#line 82 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
           Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>");
#nullable restore
#line 85 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
           Write(Html.DisplayName("Phone Number:"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n            <td>");
#nullable restore
#line 86 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
           Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        </tr>\r\n    </table>\r\n");
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
            WriteLiteral("\r\n\r\n<div>\r\n    <hr />\r\n    ");
#nullable restore
#line 93 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new {id = Model.ManufacturerID} ));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ||\r\n    ");
#nullable restore
#line 94 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
Write(Html.ActionLink("Delete", "Delete", new { id = Model.ManufacturerID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ||\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 2164, "\"", 2219, 1);
#nullable restore
#line 95 "C:\Users\VLACA\GIT\new git\ComputerMonitorStockManager\Views\ManufacturersView\Details.cshtml"
WriteAttributeValue("", 2171, Url.Action("Manufacturers","ManufacturersView"), 2171, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Back to list of manufacturers</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DomainLayer.Models.Manufacturers> Html { get; private set; }
    }
}
#pragma warning restore 1591