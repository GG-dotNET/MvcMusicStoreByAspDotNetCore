#pragma checksum "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\StoreManager\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "757c059b0d3a816f13c3238b66cc0c1127b0c569"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StoreManager_Details), @"mvc.1.0.view", @"/Views/StoreManager/Details.cshtml")]
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
#line 5 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"757c059b0d3a816f13c3238b66cc0c1127b0c569", @"/Views/StoreManager/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ccfda4f571992a577a9f93e77e3a34b8bbc3710", @"/Views/_ViewImports.cshtml")]
    public class Views_StoreManager_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MVCMusicStore.Models.Album>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\StoreManager\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<fieldset>\r\n    <legend>Album</legend>\r\n\r\n    <div class=\"display-label\">Genre</div>\r\n    <div class=\"display-field\">\r\n        ");
#nullable restore
#line 14 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\StoreManager\Details.cshtml"
   Write(Html.DisplayFor(model => model.Genre.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">Artist</div>\r\n    <div class=\"display-field\">\r\n        ");
#nullable restore
#line 19 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\StoreManager\Details.cshtml"
   Write(Html.DisplayFor(model => model.Artist.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">Title</div>\r\n    <div class=\"display-field\">\r\n        ");
#nullable restore
#line 24 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\StoreManager\Details.cshtml"
   Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">Price</div>\r\n    <div class=\"display-field\">\r\n        ");
#nullable restore
#line 29 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\StoreManager\Details.cshtml"
   Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">AlbumArtUrl</div>\r\n    <div class=\"display-field\">\r\n        ");
#nullable restore
#line 34 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\StoreManager\Details.cshtml"
   Write(Html.DisplayFor(model => model.AlbumArtUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</fieldset>\r\n<p>\r\n    ");
#nullable restore
#line 38 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\StoreManager\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.AlbumId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 39 "C:\Users\ol140\source\repos\MVCMusicStore\MVCMusicStore\Views\StoreManager\Details.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MVCMusicStore.Models.Album> Html { get; private set; }
    }
}
#pragma warning restore 1591
