#pragma checksum "E:\VaccineAvailability\VaccineAvailability\Views\Home\_GridPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "673ca77d7b52d8ca4f149e778acb6c2ce9ceeda9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__GridPartial), @"mvc.1.0.view", @"/Views/Home/_GridPartial.cshtml")]
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
#line 1 "E:\VaccineAvailability\VaccineAvailability\Views\_ViewImports.cshtml"
using VaccineAvailability;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\VaccineAvailability\VaccineAvailability\Views\_ViewImports.cshtml"
using VaccineAvailability.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"673ca77d7b52d8ca4f149e778acb6c2ce9ceeda9", @"/Views/Home/_GridPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41fe6c091d02ba19da01b163859bd4446ca444b0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__GridPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Root>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<table class=""table table-responsive"">
    <thead>
        <tr>
            <th>Address</th>
            <th>Pin</th>
            <th>Age</th>
            <th>Availability</th>
            <th>Type</th>
            <th>Vaccine</th>
        </tr>
    </thead>
");
#nullable restore
#line 13 "E:\VaccineAvailability\VaccineAvailability\Views\Home\_GridPartial.cshtml"
     foreach (var item in Model.centers.Where(x => x.sessions.Count> 1 && x.sessions[1].min_age_limit <= 20 && x.sessions[1].available_capacity > 0))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <td> ");
#nullable restore
#line 16 "E:\VaccineAvailability\VaccineAvailability\Views\Home\_GridPartial.cshtml"
    Write(item.name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 16 "E:\VaccineAvailability\VaccineAvailability\Views\Home\_GridPartial.cshtml"
               Write(item.address);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n    <td> ");
#nullable restore
#line 17 "E:\VaccineAvailability\VaccineAvailability\Views\Home\_GridPartial.cshtml"
    Write(item.pincode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td> ");
#nullable restore
#line 18 "E:\VaccineAvailability\VaccineAvailability\Views\Home\_GridPartial.cshtml"
    Write(item.sessions[0].min_age_limit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td> ");
#nullable restore
#line 19 "E:\VaccineAvailability\VaccineAvailability\Views\Home\_GridPartial.cshtml"
    Write(item.sessions[0].available_capacity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td> ");
#nullable restore
#line 20 "E:\VaccineAvailability\VaccineAvailability\Views\Home\_GridPartial.cshtml"
    Write(item.fee_type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td> ");
#nullable restore
#line 21 "E:\VaccineAvailability\VaccineAvailability\Views\Home\_GridPartial.cshtml"
    Write(item.sessions[0].vaccine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n</tr>\r\n");
#nullable restore
#line 23 "E:\VaccineAvailability\VaccineAvailability\Views\Home\_GridPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Root> Html { get; private set; }
    }
}
#pragma warning restore 1591
