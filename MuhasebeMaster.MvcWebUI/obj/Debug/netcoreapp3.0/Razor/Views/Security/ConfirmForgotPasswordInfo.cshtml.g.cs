#pragma checksum "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Security\ConfirmForgotPasswordInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2470856125dda7016fe1c86527f080a260d3740d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Security_ConfirmForgotPasswordInfo), @"mvc.1.0.view", @"/Views/Security/ConfirmForgotPasswordInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2470856125dda7016fe1c86527f080a260d3740d", @"/Views/Security/ConfirmForgotPasswordInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a0a3481cbceb2b6573cfc1aa43afea33ec0503c", @"/Views/_ViewImports.cshtml")]
    public class Views_Security_ConfirmForgotPasswordInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Security\ConfirmForgotPasswordInfo.cshtml"
  
    ViewData["Title"] = "ConfirmForgotPasswordInfo";
    Layout = "~/Views/Shared/_LayoutSecurity.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""account-pages""></div>
<div class=""clearfix""></div>
<div class=""wrapper-page"">

    <div class=""m-t-40 card-box"">
        <div class=""text-center"">
            <a href=""/Home/Index"" class=""logo""><span>Test<span>Project</span></span></a>
        </div>
        <div class=""panel-body text-center"">
            <img src=""/assets/images/mail_confirm.png"" alt=""img"" class=""thumb-lg m-t-20 center-block"" />
            <p class=""text-muted font-13 m-t-20""><b>");
#nullable restore
#line 16 "C:\Users\merte\source\repos\MuhasebeMaster\MuhasebeMaster.MvcWebUI\Views\Security\ConfirmForgotPasswordInfo.cshtml"
                                               Write(TempData["email"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</b> adresinize şifre değişikliği aktivasyonu için bir e-mail gönderilmiştir. Mailinizi kontrol ediniz ve aktivasyon linki ile sitemize tekrar ulaşınız. </p>
        </div>
        <div class=""row"">
            <div class=""col-sm-12 text-center"">
                <p class=""text-muted""><a href=""/Security/Login"" class=""text-primary m-l-5""><b>Giriş Yap</b></a></p>
            </div>
        </div>
    </div>
</div>
<!-- end wrapper page -->
");
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
