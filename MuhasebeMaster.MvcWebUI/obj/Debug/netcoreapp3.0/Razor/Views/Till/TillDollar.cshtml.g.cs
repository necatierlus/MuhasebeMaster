#pragma checksum "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Till\TillDollar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17769093dc559cb778b1c902a468c47388d96312"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Till_TillDollar), @"mvc.1.0.view", @"/Views/Till/TillDollar.cshtml")]
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
#line 1 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\_ViewImports.cshtml"
using MuhasebeMaster.MvcWebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\_ViewImports.cshtml"
using MuhasebeMaster.MvcWebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17769093dc559cb778b1c902a468c47388d96312", @"/Views/Till/TillDollar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a0a3481cbceb2b6573cfc1aa43afea33ec0503c", @"/Views/_ViewImports.cshtml")]
    public class Views_Till_TillDollar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Till\TillDollar.cshtml"
  
    ViewData["Title"] = "TillDollar";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>BAKİYE : ");
#nullable restore
#line 7 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Till\TillDollar.cshtml"
        Write(ViewBag.DOLAR);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $</h2>\r\n\r\n");
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