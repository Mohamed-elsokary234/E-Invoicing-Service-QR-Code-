#pragma checksum "C:\Users\elsokary\source\repos\QR code Text\QR code Text\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9e3415669c78004767556cb5f010da849614098"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\elsokary\source\repos\QR code Text\QR code Text\Views\_ViewImports.cshtml"
using QR_code_Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\elsokary\source\repos\QR code Text\QR code Text\Views\_ViewImports.cshtml"
using QR_code_Text.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9e3415669c78004767556cb5f010da849614098", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d77247d060e7cbbe48034097fe03d1a120e258c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\elsokary\source\repos\QR code Text\QR code Text\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n");
#nullable restore
#line 7 "C:\Users\elsokary\source\repos\QR code Text\QR code Text\Views\Home\Index.cshtml"
     using (Html.BeginForm("index", "home", FormMethod.Post))
    {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <label> اسم الشركة</label>
        <input type=""text"" name=""CompanyName"" />
        <br />
        <label> الرقم الضريبي</label>
        <input type=""text"" name=""TaxNumber"" />
        <br />
        <label> الوقت والتاريخ</label>
        <input type=""datetime"" name=""BillDateTime"" />
        <br />
        <label> اجمالي الفاتوره مع الضريبة</label>
        <input type=""text"" name=""TotalAfterVAT"" />
        <br />
        <label> قيمة الضريبة</label>
        <input type=""text"" name=""TotalVAT"" />
        <br />
        <input type=""submit"" value=""Generate"" />
");
#nullable restore
#line 26 "C:\Users\elsokary\source\repos\QR code Text\QR code Text\Views\Home\Index.cshtml"


    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr />\r\n\r\n");
#nullable restore
#line 31 "C:\Users\elsokary\source\repos\QR code Text\QR code Text\Views\Home\Index.cshtml"
     if (ViewBag.QrCode != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <img");
            BeginWriteAttribute("src", " src=\"", 805, "\"", 826, 1);
#nullable restore
#line 33 "C:\Users\elsokary\source\repos\QR code Text\QR code Text\Views\Home\Index.cshtml"
WriteAttributeValue("", 811, ViewBag.QrCode, 811, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:200px;height:200px;\" />\r\n");
#nullable restore
#line 34 "C:\Users\elsokary\source\repos\QR code Text\QR code Text\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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