#pragma checksum "S:\Projects\DatabaseProject\Housekeeping\Housekeeping\Pages\Main\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9ac83aa8d0fddc05292026811dd8abfcd6988bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Housekeeping.Pages.Main.Pages_Main_Index), @"mvc.1.0.razor-page", @"/Pages/Main/Index.cshtml")]
namespace Housekeeping.Pages.Main
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
#line 1 "S:\Projects\DatabaseProject\Housekeeping\Housekeeping\Pages\_ViewImports.cshtml"
using Housekeeping;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9ac83aa8d0fddc05292026811dd8abfcd6988bc", @"/Pages/Main/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98f61e6dfb8af163c35b6a53554b4a825b57b0a9", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Main_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<label>");
#nullable restore
#line 6 "S:\Projects\DatabaseProject\Housekeeping\Housekeeping\Pages\Main\Index.cshtml"
  Write(Model.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Housekeeping.Pages.Main.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Housekeeping.Pages.Main.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Housekeeping.Pages.Main.IndexModel>)PageContext?.ViewData;
        public Housekeeping.Pages.Main.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591