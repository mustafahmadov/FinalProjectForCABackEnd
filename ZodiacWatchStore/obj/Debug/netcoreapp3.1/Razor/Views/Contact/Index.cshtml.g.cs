#pragma checksum "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d184d8e9f703a5ae254dd900dfcbdc2a1919761"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
#nullable restore
#line 4 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d184d8e9f703a5ae254dd900dfcbdc2a1919761", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd8ccf09f10d6bf96bd93b2bd5c0e10ea49bebed", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Bio>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <nav aria-label=\"breadcrumb\">\r\n        <ol class=\"breadcrumb\">\r\n            <li class=\"breadcrumb-item\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d184d8e9f703a5ae254dd900dfcbdc2a19197614710", async() => {
                WriteLiteral("\r\n                <i class=\"fas fa-home\"></i>\r\n                Əsas Səhifə\r\n             ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </li>
            <li class=""breadcrumb-item active"" aria-current=""page"">Əlaqə</li>
        </ol>
    </nav>
</div>

<section class=""py-5 contact-section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-8"">
                <div class=""row"">
                    <div class=""col"">
                        <div class=""map"" style=""height: 500px;"">
                            <iframe class=""w-100 h-100 border-0""");
            BeginWriteAttribute("src", "\r\n                                    src=\"", 810, "\"", 869, 1);
#nullable restore
#line 27 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Contact\Index.cshtml"
WriteAttributeValue("", 853, Model.MapAdress, 853, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                    width=\"600\" height=\"450\" style=\"border:0;\"");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 950, "\"", 968, 0);
            EndWriteAttribute();
            WriteLiteral(@"></iframe>

                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 mt-6 mt-lg-0"">
                <div class=""shadow-sm rounded p-5"">
                    <div class=""mb-5"">
                        <h6 class=""mb-1"">— Əlaqə Məlumatları</h6>
                    </div>
                    <div class=""d-flex mb-3 "">
                        <div class=""mr-2"">
                            <i class=""fas fa-map-marker-alt ic-2x""></i>
                        </div>
                        <div>
                            <h6 class=""mb-1 text-light"">Mağazanın ünvanı</h6>
                            <p class=""mb-0 text-muted"">");
#nullable restore
#line 45 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Contact\Index.cshtml"
                                                  Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </div>
                    </div>
                    <div class=""d-flex mb-3"">
                        <div class=""mr-2"">
                            <i class=""fas fa-envelope ic-2x""></i>
                        </div>
                        <div>
                            <h6 class=""mb-1 text-light"">Email Ünvanımız</h6>
                            <a class=""text-muted""");
            BeginWriteAttribute("href", " href=\"", 2114, "\"", 2140, 2);
            WriteAttributeValue("", 2121, "mailto:", 2121, 7, true);
#nullable restore
#line 54 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Contact\Index.cshtml"
WriteAttributeValue("", 2128, Model.Email, 2128, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 54 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Contact\Index.cshtml"
                                                                        Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                        </div>
                    </div>
                    <div class=""d-flex mb-3"">
                        <div class=""mr-3"">
                            <i class=""fas fa-mobile ic-2x""></i>
                        </div>
                        <div>
                            <h6 class=""mb-1 text-light"">Əlaqə nömrəsi</h6>
                            <a class=""text-muted""");
            BeginWriteAttribute("href", " href=\"", 2564, "\"", 2587, 2);
            WriteAttributeValue("", 2571, "tel:", 2571, 4, true);
#nullable restore
#line 63 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Contact\Index.cshtml"
WriteAttributeValue("", 2575, Model.Phone, 2575, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 63 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Contact\Index.cshtml"
                                                                     Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                        </div>
                    </div>
                    <div class=""d-flex mb-3"">
                        <div class=""mr-2"">
                            <i class=""fas fa-clock ic-2x""></i>
                        </div>
                        <div>
                            <h6 class=""mb-1 text-light"">İş saatları</h6>
                            <span class=""text-muted"">");
#nullable restore
#line 72 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Contact\Index.cshtml"
                                                Write(Model.WorkHours);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                    </div>`\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Bio> Html { get; private set; }
    }
}
#pragma warning restore 1591
