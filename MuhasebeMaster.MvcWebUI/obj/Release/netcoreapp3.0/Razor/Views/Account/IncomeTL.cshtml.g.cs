#pragma checksum "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\IncomeTL.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e99933be4e540a740ead5adecab93d4adecfc8f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_IncomeTL), @"mvc.1.0.view", @"/Views/Account/IncomeTL.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e99933be4e540a740ead5adecab93d4adecfc8f1", @"/Views/Account/IncomeTL.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a0a3481cbceb2b6573cfc1aa43afea33ec0503c", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_IncomeTL : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MuhasebeMaster.MvcWebUI.Models.AccountViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\IncomeTL.cshtml"
  
    ViewData["Title"] = "IncomeTL";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-sm-12\">\r\n        <div class=\"card-box table-responsive\">\r\n");
            WriteLiteral(@"
            <h4 class=""header-title m-t-0 m-b-30"">TL Gelirler</h4>

            <div id=""datatable-buttons_wrapper"" class=""dataTables_wrapper form-inline dt-bootstrap no-footer"">
                <table id=""datatable-buttons"" class=""table table-striped table-bordered dataTable no-footer dtr-inline collapsed"" role=""grid"" aria-describedby=""datatable-buttons_info"">
                    <thead>
                        <tr role=""row"">
                            <th class=""sorting_asc"" tabindex=""0"" aria-controls=""datatable-buttons"" rowspan=""1"" colspan=""1"" aria-sort=""ascending"" aria-label=""Name: activate to sort column descending"" style=""width: 20px;"">Hesap Id</th>
                            <th class=""sorting_"" tabindex=""1"" aria-controls=""datatable-buttons"" rowspan=""1"" colspan=""1"" aria-sort=""ascending"" aria-label=""Model: activate to sort column descending"" style=""width: 450px;"">Tutar</th>
                            <th class=""sorting"" tabindex=""2"" aria-controls=""datatable-buttons"" rowspan=""1"" colspan=""1""");
            WriteLiteral(" aria-label=\"Quantity: activate to sort column ascending\" style=\"width: 100px;\">Tarih</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 33 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\IncomeTL.cshtml"
                         foreach (var item in Model.Tills)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr role=\"row\" class=\"odd\">\r\n                                <td class=\"sorting_1\" tabindex=\"0\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2187, "\"", 2235, 2);
            WriteAttributeValue("", 2194, "/Account/GetAccountDetail/", 2194, 26, true);
#nullable restore
#line 37 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\IncomeTL.cshtml"
WriteAttributeValue("", 2220, item.AccountId, 2220, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
#nullable restore
#line 38 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\IncomeTL.cshtml"
                                   Write(item.AccountId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </a>\r\n                                </td>\r\n                                <td>");
#nullable restore
#line 41 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\IncomeTL.cshtml"
                               Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 42 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\IncomeTL.cshtml"
                               Write(item.AddedDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 44 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Account\IncomeTL.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div><!-- end col -->\r\n</div>\r\n\r\n");
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
