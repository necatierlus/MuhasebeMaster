#pragma checksum "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d29fa122f421f48c4be06f733faa0372f2ca7f02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_GetAccountDetail), @"mvc.1.0.view", @"/Views/Account/GetAccountDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d29fa122f421f48c4be06f733faa0372f2ca7f02", @"/Views/Account/GetAccountDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a0a3481cbceb2b6573cfc1aa43afea33ec0503c", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_GetAccountDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MuhasebeMaster.MvcWebUI.Models.AccountViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml"
  
    ViewData["Title"] = "GetAccountDetail";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"container\">\r\n    <h2>");
#nullable restore
#line 10 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml"
   Write(Model.Account.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <div class=\"row\">\r\n        <div class=\"col-12 col-sm-12 col-md-6 col-lg-6\">\r\n            <ul class=\"list-group\">\r\n                <li class=\"list-group-item\">");
#nullable restore
#line 14 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml"
                                       Write(Model.Account.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">");
#nullable restore
#line 15 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml"
                                       Write(Model.Account.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">");
#nullable restore
#line 16 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml"
                                       Write(Model.Account.District);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">");
#nullable restore
#line 17 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml"
                                       Write(Model.Account.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">");
#nullable restore
#line 18 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml"
                                       Write(Model.Account.AddedDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">");
#nullable restore
#line 19 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml"
                                       Write(Model.Account.AccountType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">\r\n\r\n                ");
#nullable restore
#line 22 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml"
           Write(ViewBag.Balance);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 22 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml"
                            Write(Model.Account.CostType);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n    ");
#nullable restore
#line 27 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\GetAccountDetail.cshtml"
Write(await Component.InvokeAsync("Transaction"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MuhasebeMaster.MvcWebUI.Models.AccountViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591