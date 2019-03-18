#pragma checksum "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Admin\AddPictureToGallery.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31f485961787a39c23119b0358be5f86414c5fbd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AddPictureToGallery), @"mvc.1.0.view", @"/Views/Admin/AddPictureToGallery.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/AddPictureToGallery.cshtml", typeof(AspNetCore.Views_Admin_AddPictureToGallery))]
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
#line 1 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Admin\AddPictureToGallery.cshtml"
using FindGavenCore;

#line default
#line hidden
#line 2 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\_ViewImports.cshtml"
using FindGavenCore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31f485961787a39c23119b0358be5f86414c5fbd", @"/Views/Admin/AddPictureToGallery.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"858adcb359cf13b713a5dd24210ce208aa4db16c", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AddPictureToGallery : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AddPicturesToGalleryViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(60, 121, true);
            WriteLiteral("\r\n<div class=\"container aboutpage\">\r\n    <div class=\"row\">\r\n        <div class=\"col-xs-12 about-content faq-content\">\r\n\r\n");
            EndContext();
#line 8 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Admin\AddPictureToGallery.cshtml"
             using (Html.BeginForm(actionName: "AddPictureToGallery", controllerName: "Admin", method: FormMethod.Post, htmlAttributes: new { role = "form", enctype = "multipart/form-data" }))
            {

#line default
#line hidden
            BeginContext(390, 800, true);
            WriteLiteral(@"                <div class=""form-horizontal"">
                    <h4>Tilføj nyt billede</h4>
                    <hr />
                    <div class=""form-group"">
                        <label for=""picture"" class=""control-label col-md-2"">.png</label>
                        <div class=""col-md-10"">
                            <input type=""file"" name=""picture"" />
                        </div>
                    </div>

                    <div class=""form-group"">
                        <div class=""col-md-offset-2 col-md-10"">
                            <input type=""submit"" value=""Gem"" class=""btn btn-default"" />
                            <a href=""/admin"" class=""btn btn-link"">Tilbage</a>
                        </div>
                    </div>
                </div>
");
            EndContext();
#line 27 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Admin\AddPictureToGallery.cshtml"
            }

#line default
#line hidden
            BeginContext(1205, 30, true);
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n");
            EndContext();
#line 31 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Admin\AddPictureToGallery.cshtml"
     foreach (var picture in Model.Images)
    {

#line default
#line hidden
            BeginContext(1286, 31, true);
            WriteLiteral("        <div>\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1317, "\"", 1338, 2);
            WriteAttributeValue("", 1323, "/", 1323, 1, true);
#line 34 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Admin\AddPictureToGallery.cshtml"
WriteAttributeValue("", 1324, picture.value, 1324, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1339, 65, true);
            WriteLiteral(" style=\"margin-top: 5px; max-height: 100px; max-width: 100px\" /> ");
            EndContext();
            BeginContext(1406, 41, false);
#line 34 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Admin\AddPictureToGallery.cshtml"
                                                                                                   Write(System.IO.Path.GetFileName(picture.value));

#line default
#line hidden
            EndContext();
            BeginContext(1448, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 35 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Admin\AddPictureToGallery.cshtml"
             using (Html.BeginForm(actionName: "DeletePictureFromGallery", controllerName: "Admin", method: FormMethod.Post))
            {

#line default
#line hidden
            BeginContext(1592, 52, true);
            WriteLiteral("                <input type=\"hidden\" name=\"filename\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1644, "\"", 1666, 1);
#line 37 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Admin\AddPictureToGallery.cshtml"
WriteAttributeValue("", 1652, picture.value, 1652, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1667, 233, true);
            WriteLiteral(">\r\n                <input type=\"submit\" value=\"Slet\" class=\"btn btn-danger\" onclick=\"return confirm(\'Er du sikker?\')\" style=\"width:100px; height:20px; padding-top:0px; border-top-left-radius: 0px; border-top-right-radius: 0px; \" />\r\n");
            EndContext();
#line 39 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Admin\AddPictureToGallery.cshtml"
            }

#line default
#line hidden
            BeginContext(1915, 16, true);
            WriteLiteral("        </div>\r\n");
            EndContext();
#line 41 "C:\Users\Thomas\Documents\Visual Studio 2017\FindGavenCore\FindGavenCore\Views\Admin\AddPictureToGallery.cshtml"
    }

#line default
#line hidden
            BeginContext(1938, 12, true);
            WriteLiteral("</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AddPicturesToGalleryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591