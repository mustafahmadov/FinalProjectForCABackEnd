#pragma checksum "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b1bc4e841d9f3af1b1bd870ecdf8112aa7c3b7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_ProductDetails), @"mvc.1.0.view", @"/Views/Product/ProductDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b1bc4e841d9f3af1b1bd870ecdf8112aa7c3b7e", @"/Views/Product/ProductDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd8ccf09f10d6bf96bd93b2bd5c0e10ea49bebed", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_ProductDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("pdp-product-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("main-product-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 400px; height: 420px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--product details start-->

<section class=""product-details-gallery"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-6 col-12"">
                <div class=""row align-center justify-content-center"">
                    <div class=""product-image-gallery"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9b1bc4e841d9f3af1b1bd870ecdf8112aa7c3b7e5787", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 475, "~/assets/images/", 475, 16, true);
#nullable restore
#line 15 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
AddHtmlAttributeValue("", 491, Model.Image, 491, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <br>\r\n                        <ul class=\"menu product-thumbs align-center\">\r\n                            <li>\r\n                                <a class=\"sim-thumb\" data-image=\"/assets/images/");
#nullable restore
#line 20 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                                                           Write(Model.Image);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9b1bc4e841d9f3af1b1bd870ecdf8112aa7c3b7e8203", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 858, "~/assets/images/", 858, 16, true);
#nullable restore
#line 21 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
AddHtmlAttributeValue("", 874, Model.Image, 874, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </a>\r\n                            </li>\r\n");
#nullable restore
#line 24 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                             foreach (ProductImage image in Model.ProductImages)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li>\r\n                                    <a class=\"sim-thumb\" data-image=\"/assets/images/");
#nullable restore
#line 27 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                                                               Write(image.Image);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9b1bc4e841d9f3af1b1bd870ecdf8112aa7c3b7e10682", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1271, "~/assets/images/", 1271, 16, true);
#nullable restore
#line 28 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
AddHtmlAttributeValue("", 1287, image.Image, 1287, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </a>\r\n                                </li>\r\n");
#nullable restore
#line 31 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </ul>
                    </div>
                </div>
            </div>
            <div class=""col-lg-6 col-12 mt-5 mt-lg-0"">
                <div class=""product-details"">
                    <h3 class=""mb-0"">
                        ");
#nullable restore
#line 39 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                   Write(Model.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </h3>
                    <span class=""product-price h4"">₼27.00 <del class=""text-muted h6""></del></span>
                    <ul class=""list-unstyled my-4"">
                        <li class=""mb-2"">
                            Mövcudluq:

");
#nullable restore
#line 46 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                             if (Model.Count > 3)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"text-muted\">\r\n                                    Anbarda\r\n                                </span>\r\n");
#nullable restore
#line 51 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                            }
                            else if (Model.Count > 0 && Model.Count < 3)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"text-muted\">\r\n                                    Son ");
#nullable restore
#line 55 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                   Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ədəd!\r\n                                </span>\r\n");
#nullable restore
#line 57 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"text-muted\">\r\n                                    Stokda Yoxdur\r\n                                </span>\r\n");
#nullable restore
#line 63 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </li>\r\n                        <li class=\"mb-2\">\r\n                            Brend :<span class=\"text-muted\"> ");
#nullable restore
#line 67 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                                        Write(Model.Brand.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </li>\r\n                        <li class=\"mb-2\">\r\n                            Model: <span class=\"text-muted\">");
#nullable restore
#line 70 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                                       Write(Model.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </li>\r\n                        <li>\r\n                            Kateqoriya :\r\n");
#nullable restore
#line 74 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                             if (Model.ProductCategories.Count == 2)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"text-muted\">\r\n                                    ");
#nullable restore
#line 77 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                               Write(Model.ProductCategories.ElementAt(0).Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n                                </span>\r\n                                <span class=\"text-muted\">\r\n                                    ");
#nullable restore
#line 80 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                               Write(Model.ProductCategories.ElementAt(1).Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </span>\r\n");
#nullable restore
#line 82 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                            }
                            else if(Model.ProductCategories.Count == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"text-muted\">\r\n                                    ");
#nullable restore
#line 86 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                               Write(Model.ProductCategories.ElementAt(0).Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </span>\r\n");
#nullable restore
#line 88 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                            }
                            else
                            {

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </li>
                    </ul>
                    <div class=""d-sm-flex align-items-center mb-5"">
                        <div class=""d-flex align-items-center mr-sm-4"">
                            <div class=""number"">
                                <input type=""number"" value=""1"" id=""quickViewInput"" />
                            </div>

                        </div>
                    </div>
                    <div class=""d-sm-flex align-items-center mt-5"">
                        <button class=""btn btn-primary btn-animated mr-sm-4  mb-sm-0 btn-cart btn-quick"" id=""addToBasket"">
                            <i class=""fas fa-shopping-cart mr-1""></i>Səbətə At
                        </button>
                        <input type=""hidden""");
            BeginWriteAttribute("value", " value=\"", 4914, "\"", 4931, 1);
#nullable restore
#line 108 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
WriteAttributeValue("", 4922, Model.Id, 4922, 9, false);

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
            BeginWriteAttribute("value", " value=\"", 5232, "\"", 5249, 1);
#nullable restore
#line 114 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
WriteAttributeValue("", 5240, Model.Id, 5240, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />

                    </div>
                    <div class=""d-flex align-items-center border-top border-bottom py-4 mt-5"">
                        <h6 class=""mb-0 mr-4"">Paylaş:</h6>
                        <ul class=""list-inline"">
                            <li class=""list-inline-item"">
                                <a class=""bg-white shadow-sm rounded p-2"" href=""#"">
                                    <i class=""fa fa-facebook""></i>
                                </a>
                            </li>

                            <li class=""list-inline-item"">
                                <a class=""bg-white shadow-sm rounded p-2"" href=""#"">
                                    <i class=""fa fa-instagram""></i>
                                </a>
                            </li>
                            <li class=""list-inline-item"">
                                <a class=""bg-white shadow-sm rounded p-2"" href=""#"">
                                    <i class=""fa fa-twitter""></i>");
            WriteLiteral(@"
                                </a>
                            </li>

                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<!--product details end-->
<!--tab start-->

<section class=""p-0 product-spec"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""tab"">
                    <!-- Nav tabs -->
                    <nav>
                        <div class=""nav nav-tabs"" id=""nav-tab"" role=""tablist"">
                            <a class=""nav-item nav-link active"" id=""nav-tab2"" data-toggle=""tab"" href=""#tab3-2""
                               role=""tab"" aria-selected=""false"">Xüsusiyyətlər</a>
                        </div>
                    </nav>
                    <!-- Tab panes -->
                    <div class=""tab-content pt-5 p-0 show"">
                        <div role=""tabpanel"" class=""tab-panel"" id=""tab3-2"">
            ");
            WriteLiteral("                <table class=\"table table-bordered mb-0\">\r\n                                <tbody>\r\n                                    <tr>\r\n                                        <td>Brend</td>\r\n                                        <td>");
#nullable restore
#line 167 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                       Write(Model.Brand.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td>Mexanizm</td>\r\n                                        <td>");
#nullable restore
#line 171 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                       Write(Model.Mechanism.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td>Qolbaq Növü</td>\r\n                                        <td>");
#nullable restore
#line 175 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                       Write(Model.BandType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td>Su Keçirməzlik</td>\r\n                                        <td>");
#nullable restore
#line 179 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                       Write(Model.WaterProtection.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td>Şüşə</td>\r\n                                        <td>");
#nullable restore
#line 183 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                       Write(Model.GlassType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td>Korpus Ölçüsü</td>\r\n                                        <td>");
#nullable restore
#line 187 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                       Write(Model.CaseThick.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td>Kateqoriya</td>\r\n                                        \r\n");
#nullable restore
#line 192 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                             if (Model.ProductCategories.Count == 2)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                             <td>\r\n                                                 ");
#nullable restore
#line 195 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                            Write(Model.ProductCategories.ElementAt(0).Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n                                                 ");
#nullable restore
#line 196 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                            Write(Model.ProductCategories.ElementAt(1).Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                             </td>\r\n");
#nullable restore
#line 198 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"

                                             }
                                             else if (Model.ProductCategories.Count == 1)
                                             {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                             <td>\r\n                                                  ");
#nullable restore
#line 203 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                             Write(Model.ProductCategories.ElementAt(0).Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                             </td>\r\n");
#nullable restore
#line 205 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                             }
                                             else
                                             {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                 <td>\r\n\r\n                                                 </td>\r\n");
#nullable restore
#line 211 "C:\Users\musta\Desktop\FinalProjectForCABackEnd\ZodiacWatchStore\Views\Product\ProductDetails.cshtml"
                                             }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<!--tab end-->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
