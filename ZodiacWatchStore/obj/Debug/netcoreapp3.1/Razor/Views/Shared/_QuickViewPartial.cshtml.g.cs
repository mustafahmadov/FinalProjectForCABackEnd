#pragma checksum "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Shared\_QuickViewPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d1336dbb138a5656280fd119a2cf7089dc63557"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__QuickViewPartial), @"mvc.1.0.view", @"/Views/Shared/_QuickViewPartial.cshtml")]
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
#line 1 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\_ViewImports.cshtml"
using ZodiacWatchStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\_ViewImports.cshtml"
using ZodiacWatchStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\_ViewImports.cshtml"
using ZodiacWatchStore.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d1336dbb138a5656280fd119a2cf7089dc63557", @"/Views/Shared/_QuickViewPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf495bd5d74212fd0d352176c9d7ee82121d37f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__QuickViewPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"modal-body\">\r\n    <div class=\"row align-items-center\">\r\n        <div class=\"col-lg-5 col-12\">\r\n            <img class=\"img-fluid rounded\"");
            BeginWriteAttribute("src", " src=\"", 165, "\"", 197, 2);
            WriteAttributeValue("", 171, "assets/images/", 171, 14, true);
#nullable restore
#line 5 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Shared\_QuickViewPartial.cshtml"
WriteAttributeValue("", 185, Model.Image, 185, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"image\" />\r\n        </div>\r\n        <div class=\"col-lg-7 col-12 mt-5 mt-lg-0\">\r\n            <div class=\"product-details\">\r\n                <h3 class=\"mb-0\">");
#nullable restore
#line 9 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Shared\_QuickViewPartial.cshtml"
                            Write(Model.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                 <span class=""product-price h4"">
                    $25.00 <del class=""text-muted h6""></del>
                </span>
                <ul class=""list-unstyled my-4"">
                    <li class=""mb-2"">
                        Mövcudluq :<span class=""text-muted""> Anbarda</span>
                    </li>
                    <li>
                        Brend :<span class=""text-muted""> Tissot</span>
                    </li>
                    <li>
                        Kateqoriya :<span class=""text-muted""> Kişi</span>
                    </li>
                </ul>
                <div class=""d-sm-flex align-items-center mb-5"">
                    <div class=""d-flex align-items-center mr-sm-4"">
                        <div class=""number"">
                            <input type=""number"" value=""1"" id=""quickViewInput"" />
                        </div>
                        
                    </div>
                </div>
                <div class=""d-sm-flex a");
            WriteLiteral(@"lign-items-center mt-5"">
                    <button class=""btn btn-primary btn-animated mr-sm-4  mb-sm-0 btn-cart btn-quick"" id=""addToBasket"">
                        <i class=""fas fa-shopping-cart mr-1""></i>Səbətə At
                    </button>
                    <input type=""hidden""");
            BeginWriteAttribute("value", " value=\"", 1688, "\"", 1705, 1);
#nullable restore
#line 36 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Shared\_QuickViewPartial.cshtml"
WriteAttributeValue("", 1696, Model.Id, 1696, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                    <button class=""btn btn-animated btn-dark"" href=""#"" id=""addToWishlist"">
                        <i class=""far fa-heart mr-1"">

                        </i> Arzu siyahısına əlavə et
                    </button>
                    <input type=""hidden""");
            BeginWriteAttribute("value", " value=\"", 1986, "\"", 2003, 1);
#nullable restore
#line 42 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Shared\_QuickViewPartial.cshtml"
WriteAttributeValue("", 1994, Model.Id, 1994, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />

                </div>
                <div class=""d-sm-flex align-items-center border-top pt-4 mt-5"">
                    <h6 class=""mb-sm-0 mr-sm-4"">Paylaş:</h6>
                    <ul class=""list-inline"">
                        <li class=""list-inline-item"">
                            <a class=""bg-white shadow-sm rounded p-2""
                               href=""#""><i class=""fa fa-facebook""></i></a>
                        </li>

                        <li class=""list-inline-item"">
                            <a class=""bg-white shadow-sm rounded p-2""
                               href=""#""><i class=""fa fa-instagram""></i></a>
                        </li>
                        <li class=""list-inline-item"">
                            <a class=""bg-white shadow-sm rounded p-2""
                               href=""#""><i class=""fa fa-twitter""></i></a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</di");
            WriteLiteral("v>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
