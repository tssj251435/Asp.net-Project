#pragma checksum "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Shared\Components\Provider\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0341158a65c27383a646f78c36ed72daa9714a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Provider_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Provider/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Provider/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Provider_Default))]
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
#line 1 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\_ViewImports.cshtml"
using FindGavenCore;

#line default
#line hidden
#line 2 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\_ViewImports.cshtml"
using FindGavenCore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0341158a65c27383a646f78c36ed72daa9714a6", @"/Views/Shared/Components/Provider/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"858adcb359cf13b713a5dd24210ce208aa4db16c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Provider_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Provider>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 232, true);
            WriteLiteral("\r\n<div class=\"dropdown\">\r\n    <button class=\"btn btn-default topBarBtn dropdown-toggle\" type=\"button\" data-toggle=\"dropdown\">\r\n        Gaveubydere\r\n        <span class=\"caret\"></span>\r\n    </button>\r\n    <ul class=\"dropdown-menu\">\r\n");
            EndContext();
#line 9 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Shared\Components\Provider\Default.cshtml"
         foreach (var provider in Model)
        {

#line default
#line hidden
            BeginContext(315, 18, true);
            WriteLiteral("            <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 333, "\"", 363, 2);
            WriteAttributeValue("", 340, "/providers/", 340, 11, true);
#line 11 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Shared\Components\Provider\Default.cshtml"
WriteAttributeValue("", 351, provider.Id, 351, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(364, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(366, 13, false);
#line 11 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Shared\Components\Provider\Default.cshtml"
                                             Write(provider.Name);

#line default
#line hidden
            EndContext();
            BeginContext(379, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 12 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Shared\Components\Provider\Default.cshtml"
        }

#line default
#line hidden
            BeginContext(401, 17, true);
            WriteLiteral("    </ul>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Provider>> Html { get; private set; }
    }
}
#pragma warning restore 1591
