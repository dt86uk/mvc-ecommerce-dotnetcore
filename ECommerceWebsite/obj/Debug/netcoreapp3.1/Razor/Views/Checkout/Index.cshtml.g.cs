#pragma checksum "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "251a2431d256b89f915de03c331b51036c621a3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Checkout_Index), @"mvc.1.0.view", @"/Views/Checkout/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"251a2431d256b89f915de03c331b51036c621a3e", @"/Views/Checkout/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60e1bb6044e2a254cdf4529f0fd05e08b27283ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Checkout_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CheckoutViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
  
    ViewData["Title"] = "Checkout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div id=\"checkout\">\r\n    ");
#nullable restore
#line 6 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
Write(Html.ValidationSummary());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
     using (Html.BeginForm("OrderSuccessful", "Checkout", FormMethod.Post))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div id=""shippingDetails"" class=""formDetails"">
            <div id=""shippingHeader"" class=""formHeader purpleBlueGrad"">Shipping Information</div>
            <div class=""padding10"" onkeyup=""checkShippingForm();"">
                <div>
                    <div class=""formLabel floatLeft"">
                        ");
#nullable restore
#line 15 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.ShippingFirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"required\">*</span>\r\n                    </div>\r\n                    <div class=\"formInput floatLeft shippingRequired\">\r\n                        ");
#nullable restore
#line 18 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.ShippingFirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 25 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.ShippingLastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"required\">*</span>\r\n                    </div>\r\n                    <div class=\"formInput floatLeft shippingRequired\">\r\n                        ");
#nullable restore
#line 28 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.ShippingLastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 35 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.ShippingAddress1));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"required\">*</span>\r\n                    </div>\r\n                    <div class=\"formInput floatLeft shippingRequired\">\r\n                        ");
#nullable restore
#line 38 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.ShippingAddress1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 45 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.ShippingAddress2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"formInput floatLeft\">\r\n                        ");
#nullable restore
#line 48 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.ShippingAddress2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 55 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.ShippingCityTown));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"required\">*</span>\r\n                    </div>\r\n                    <div class=\"formInput floatLeft shippingRequired\">\r\n                        ");
#nullable restore
#line 58 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.ShippingCityTown));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 65 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.ShippingPostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"required\">*</span>\r\n                    </div>\r\n                    <div class=\"formInput floatLeft shippingRequired\">\r\n                        ");
#nullable restore
#line 68 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.ShippingPostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 75 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.ShippingCountry));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"required\">*</span>\r\n                    </div>\r\n                    <div class=\"formInput floatLeft shippingRequired\">\r\n                        ");
#nullable restore
#line 78 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.ShippingCountry));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 85 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.ShippingDeliveryMethod));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"required\">*</span>\r\n                    </div>\r\n                    <div class=\"formInput floatLeft\">\r\n                        ");
#nullable restore
#line 88 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Model.ShippingDeliveryMethod);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 95 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.ShippingPhone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"formInput floatLeft\">\r\n                        ");
#nullable restore
#line 98 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.ShippingPhone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 105 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.ShippingEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"required\">*</span>\r\n                    </div>\r\n                    <div class=\"formInput floatLeft shippingRequired\">\r\n                        ");
#nullable restore
#line 108 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.ShippingEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                    <div class=""clearBoth""></div>
                </div>

                <div>
                    <div class=""floatRight marginTop10"">
                        <input id=""btnShipping"" type=""button"" value=""Proceed to Billing"" class=""btnSubmit disabledButton"" onclick=""confirmShippingForm();"" />
                    </div>
                    <div class=""clearBoth""></div>
                </div>
            </div>
        </div>
");
            WriteLiteral("        <div id=\"billingDetails\" class=\"formDetails\">\r\n            <div id=\"billingHeader\" class=\"inactiveForm\">Billing Information</div>\r\n            <div id=\"billingForm\" onkeyup=\"checkBillingForm();\">\r\n                <div>\r\n                    ");
#nullable restore
#line 126 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
               Write(Html.LabelFor(m => m.BillingIsShippingAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 127 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
               Write(Html.CheckBoxFor(m => m.BillingIsShippingAddress, new Dictionary<string, object>{
                         { "onclick","showShippingDetails();" },
                         { "class","billingCheckBox" }
                    }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n\r\n                <div id=\"billingFormContainer\">\r\n                    <div id=\"billingFormDetails\" onkeyup=\"checkBillingForm();\">\r\n                        <div class=\"formLabel floatLeft\">\r\n                            ");
#nullable restore
#line 136 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingFirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"formInput floatLeft\">\r\n                            ");
#nullable restore
#line 139 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.BillingFirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"clearBoth\"></div>\r\n                    </div>\r\n\r\n                    <div>\r\n                        <div class=\"formLabel floatLeft\">\r\n                            ");
#nullable restore
#line 146 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingLastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"formInput floatLeft\">\r\n                            ");
#nullable restore
#line 149 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.BillingLastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"clearBoth\"></div>\r\n                    </div>\r\n\r\n                    <div>\r\n                        <div class=\"formLabel floatLeft\">\r\n                            ");
#nullable restore
#line 156 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(p => p.BillingAddress1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"formInput floatLeft\">\r\n                            ");
#nullable restore
#line 159 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.BillingAddress1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"clearBoth\"></div>\r\n                    </div>\r\n\r\n                    <div>\r\n                        <div class=\"formLabel floatLeft\">\r\n                            ");
#nullable restore
#line 166 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingAddress2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"formInput floatLeft\">\r\n                            ");
#nullable restore
#line 169 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.BillingAddress2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"clearBoth\"></div>\r\n                    </div>\r\n\r\n                    <div>\r\n                        <div class=\"formLabel floatLeft\">\r\n                            ");
#nullable restore
#line 176 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(p => p.BillingCityTown));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"formInput floatLeft\">\r\n                            ");
#nullable restore
#line 179 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.BillingCityTown));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"clearBoth\"></div>\r\n                    </div>\r\n\r\n                    <div>\r\n                        <div class=\"formLabel floatLeft\">\r\n                            ");
#nullable restore
#line 186 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingPostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"formInput floatLeft\">\r\n                            ");
#nullable restore
#line 189 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.BillingPostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"clearBoth\"></div>\r\n                    </div>\r\n\r\n                    <div>\r\n                        <div class=\"formLabel floatLeft\">\r\n                            ");
#nullable restore
#line 196 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingCountry));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"formInput floatLeft\">\r\n                            ");
#nullable restore
#line 199 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.BillingCountry));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"clearBoth\"></div>\r\n                    </div>\r\n\r\n                    <div>\r\n                        <div class=\"formLabel floatLeft\">\r\n                            ");
#nullable restore
#line 206 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingPhone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"formInput floatLeft\">\r\n                            ");
#nullable restore
#line 209 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.BillingPhone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"clearBoth\"></div>\r\n                    </div>\r\n\r\n                    <div>\r\n                        <div class=\"formLabel floatLeft\">\r\n                            ");
#nullable restore
#line 216 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"formInput floatLeft\">\r\n                            ");
#nullable restore
#line 219 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.BillingEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div class=""clearBoth""></div>
                    </div>
                </div>
                <div id=""billingShippingInfo"">
                    <div>
                        <div class=""formLabel floatLeft"">
                            ");
#nullable restore
#line 227 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingFirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div class=""formInput floatLeft"">
                            <label id=""billingShippingFirstName""></label>
                        </div>
                        <div class=""clearBoth""></div>
                    </div>

                    <div>
                        <div class=""formLabel floatLeft"">
                            ");
#nullable restore
#line 237 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingLastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div class=""formInput floatLeft"">
                            <label id=""billingShippingLastName""></label>
                        </div>
                        <div class=""clearBoth""></div>
                    </div>

                    <div>
                        <div class=""formLabel floatLeft"">
                            ");
#nullable restore
#line 247 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingAddress1));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div class=""formInput floatLeft"">
                            <label id=""billingShippingAddress1""></label>
                        </div>
                        <div class=""clearBoth""></div>
                    </div>

                    <div>
                        <div class=""formLabel floatLeft"">
                            ");
#nullable restore
#line 257 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingAddress2));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div class=""formInput floatLeft"">
                            <label id=""billingShippingAddress2""></label>
                        </div>
                        <div class=""clearBoth""></div>
                    </div>

                    <div>
                        <div class=""formLabel floatLeft"">
                            ");
#nullable restore
#line 267 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingCityTown));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div class=""formInput floatLeft"">
                            <label id=""billingShippingCityTown""></label>
                        </div>
                        <div class=""clearBoth""></div>
                    </div>

                    <div>
                        <div class=""formLabel floatLeft"">
                            ");
#nullable restore
#line 277 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingPostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div class=""formInput floatLeft"">
                            <label id=""billingShippingPostalCode""></label>
                        </div>
                        <div class=""clearBoth""></div>
                    </div>

                    <div>
                        <div class=""formLabel floatLeft"">
                            ");
#nullable restore
#line 287 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingCountry));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div class=""formInput floatLeft"">
                            <label id=""billingShippingCountry""></label>
                        </div>
                        <div class=""clearBoth""></div>
                    </div>

                    <div>
                        <div class=""formLabel floatLeft"">
                            ");
#nullable restore
#line 297 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingPhone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div class=""formInput floatLeft"">
                            <label id=""billingShippingPhone""></label>
                        </div>
                        <div class=""clearBoth""></div>
                    </div>

                    <div>
                        <div class=""formLabel floatLeft"">
                            ");
#nullable restore
#line 307 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                       Write(Html.LabelFor(m => m.BillingEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div class=""formInput floatLeft"">
                            <label id=""billingShippingEmail""></label>
                        </div>
                        <div class=""clearBoth""></div>
                    </div>
                </div>
                <div>
                    <div class=""floatLeft marginTop10"">
                        <input type=""button"" value=""Back to Shipping"" class=""btnSubmit purpleBlueGrad"" onclick=""returnToShipping();"" />
                    </div>
                    <div class=""floatRight marginTop10"">
                        <input id=""btnBilling"" type=""button"" value=""Proceed to Payment"" class=""btnSubmit disabledButton"" onclick=""confirmBillingForm();"" />
                    </div>
                    <div class=""clearBoth""></div>
                </div>
            </div>
        </div>
");
            WriteLiteral(@"        <div id=""cardDetails"" class=""formDetails"">
            <div id=""cardHeader"" class=""inactiveForm"">Card Details</div>
            <div id=""cardForm"" onkeyup=""checkCardForm();"">
                <div>
                    <div class=""formLabel floatLeft"">
                        ");
#nullable restore
#line 332 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.NameOnCard));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"required\">*</span>\r\n                    </div>\r\n                    <div class=\"formInput floatLeft\">\r\n                        ");
#nullable restore
#line 335 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.NameOnCard));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 342 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.CardNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"required\">*</span>\r\n                    </div>\r\n                    <div class=\"formInput floatLeft cardRequired\">\r\n                        ");
#nullable restore
#line 345 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.CardNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 352 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.ExpiryDateMonth));

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 352 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                                                            Write(Html.LabelFor(m => m.ExpiryDateYear));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"formInput floatLeft cardRequired\">\r\n                        ");
#nullable restore
#line 355 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.ExpiryDateMonth, new { @placeholder = "MM", @class = "cardMonthYearInputs" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 355 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                                                                                                                           Write(Html.TextBoxFor(m => m.ExpiryDateYear, new { @placeholder = "YY", @class = "cardMonthYearInputs" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearBoth\"></div>\r\n                </div>\r\n\r\n                <div>\r\n                    <div class=\"formLabel floatLeft\">\r\n                        ");
#nullable restore
#line 362 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.LabelFor(m => m.CCV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"formInput floatLeft\">\r\n                        ");
#nullable restore
#line 365 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.CCV, new { @type = "password", @class = "cardCcvInput" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                    <div class=""clearBoth""></div>
                </div>

                <div>
                    <div class=""floatRight marginTop10"">
                        <input id=""btnPlaceOrder"" type=""submit"" value=""Place Order"" class=""btnSubmit purpleBlueGrad"" />
                    </div>
                    <div class=""clearBoth""></div>
                </div>
            </div>
        </div>
");
#nullable restore
#line 378 "C:\Users\danie\source\repos\mvc-ecommerce-dotnetcore\ECommerceWebsite\Views\Checkout\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<script>\r\n    window.onload = function () {\r\n        setupCheckout();\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CheckoutViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
