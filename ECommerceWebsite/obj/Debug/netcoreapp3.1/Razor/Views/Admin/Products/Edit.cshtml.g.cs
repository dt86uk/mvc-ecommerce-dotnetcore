#pragma checksum "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16602666077b7c5bf0233a316bd5a648a013695d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Products_Edit), @"mvc.1.0.view", @"/Views/Admin/Products/Edit.cshtml")]
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
#line 1 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\_ViewImports.cshtml"
using ECommerceWebsite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\_ViewImports.cshtml"
using ECommerceWebsite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
using ECommerceWebsite.Models.Admin;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16602666077b7c5bf0233a316bd5a648a013695d", @"/Views/Admin/Products/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60e1bb6044e2a254cdf4529f0fd05e08b27283ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Products_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EditProductViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
  
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"subTitleHeader\">Edit Product</div>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
 using (Html.BeginForm("Update", "products", Model, FormMethod.Post, false, new { @class = "displayInlineBlock" }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 13 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.LabelFor(p => p.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 16 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.TextBoxFor(p => p.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("        </div>\r\n        <div class=\"clearBoth\"></div>\r\n    </div>\r\n");
            WriteLiteral("    <div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 24 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.LabelFor(p => p.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 27 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.TextBoxFor(p => p.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"clearBoth\"></div>\r\n    </div>\r\n");
            WriteLiteral("    <div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 34 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.LabelFor(p => p.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 37 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.TextAreaFor(p => p.Description, 5, 20, new { @class = "editTextArea" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
            WriteLiteral("\r\n");
            WriteLiteral("        </div>\r\n        <div class=\"clearBoth\"></div>\r\n    </div>\r\n");
            WriteLiteral("    <div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 45 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.LabelFor(p => p.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 48 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.TextBoxFor(p => p.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("        </div>\r\n        <div class=\"clearBoth\"></div>\r\n    </div>\r\n");
            WriteLiteral("    <div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 56 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.HiddenFor(p => p.Brand.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 57 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.LabelFor(p => p.Brand.BrandName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 60 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.TextBoxFor(p => p.Brand.BrandName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("        </div>\r\n        <div class=\"clearBoth\"></div>\r\n    </div>\r\n");
            WriteLiteral("    <div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 68 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.HiddenFor(p => p.Category.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 69 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.LabelFor(p => p.Category.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 72 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.TextBoxFor(p => p.Category.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("        </div>\r\n        <div class=\"clearBoth\"></div>\r\n    </div>\r\n");
            WriteLiteral("    <div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 80 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.LabelFor(p => p.HeroImage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"floatLeft width20perc\">\r\n");
            WriteLiteral("        </div>\r\n        <div class=\"clearBoth\"></div>\r\n    </div>\r\n");
            WriteLiteral("    <div>\r\n        <div class=\"floatLeft width20perc\">\r\n            ");
#nullable restore
#line 91 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
       Write(Html.LabelFor(p => p.Images));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"floatLeft width20perc\">\r\n");
            WriteLiteral("        </div>\r\n        <div class=\"clearBoth\"></div>\r\n    </div>\r\n");
#nullable restore
#line 99 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Admin\Products\Edit.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EditProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
