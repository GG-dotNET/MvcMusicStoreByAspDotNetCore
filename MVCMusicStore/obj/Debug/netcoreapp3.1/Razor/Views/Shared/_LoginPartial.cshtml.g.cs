#pragma checksum "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\Shared\_LoginPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08cdb2f83dd5bc5108667a87fb22dba383549e37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoginPartial), @"mvc.1.0.view", @"/Views/Shared/_LoginPartial.cshtml")]
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
#line 2 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\_ViewImports.cshtml"
using MVCMusicStore.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\_ViewImports.cshtml"
using MVCMusicStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\_ViewImports.cshtml"
using MVCMusicStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\Shared\_LoginPartial.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08cdb2f83dd5bc5108667a87fb22dba383549e37", @"/Views/Shared/_LoginPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ccfda4f571992a577a9f93e77e3a34b8bbc3710", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LoginPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<ul class=\"navbar-nav\">\r\n");
#nullable restore
#line 6 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\Shared\_LoginPartial.cshtml"
     if (SignInManager.IsSignedIn(User))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"nav-item\">\r\n            <a class=\"nav-link text-dark\" asp-area=\"Identity\" asp-page=\"/Account/Manage/Index\" title=\"Manage\">Hello ");
#nullable restore
#line 9 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\Shared\_LoginPartial.cshtml"
                                                                                                               Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <form class=\"form-inline\" asp-area=\"Identity\" asp-page=\"/Account/Logout\"");
            BeginWriteAttribute("asp-route-returnUrl", " asp-route-returnUrl=\"", 499, "\"", 568, 1);
#nullable restore
#line 12 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\Shared\_LoginPartial.cshtml"
WriteAttributeValue("", 521, Url.Action("Index", "Home", new { area = "" }), 521, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <button type=\"submit\" class=\"nav-link btn btn-link text-dark\">Logout</button>\r\n            </form>\r\n        </li>\r\n");
#nullable restore
#line 16 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\Shared\_LoginPartial.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <li class=""nav-item"">
            <a class=""nav-link text-dark"" asp-area=""Identity"" asp-page=""/Account/Register"">Register</a>
        </li>
        <li class=""nav-item"">
            <a class=""nav-link text-dark"" asp-area=""Identity"" asp-page=""/Account/Login"">Login</a>
        </li>
");
#nullable restore
#line 25 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\Shared\_LoginPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<User> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
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
