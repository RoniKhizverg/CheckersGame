#pragma checksum "C:\Users\oramr\Documents\GitHub\CheckersGame\Server\Views\TblGames\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4598462d3309289e5c0356e75725c8d7992ef6a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TblGames_Create), @"mvc.1.0.view", @"/Views/TblGames/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4598462d3309289e5c0356e75725c8d7992ef6a2", @"/Views/TblGames/Create.cshtml")]
    #nullable restore
    public class Views_TblGames_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Server.Model.TblGames>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\oramr\Documents\GitHub\CheckersGame\Server\Views\TblGames\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>TblGames</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Date"" class=""control-label""></label>
                <input asp-for=""Date"" class=""form-control"" />
                <span asp-validation-for=""Date"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Winner"" class=""control-label""></label>
                <input asp-for=""Winner"" class=""form-control"" />
                <span asp-validation-for=""Winner"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""UserId"" class=""control-label""></label>
                <input asp-for=""UserId"" class=""form-control"" />
                <span asp-validation-for=""UserId"" class=""text-danger""></span>
            </div");
            WriteLiteral(@">
            <div class=""form-group"">
                <label asp-for=""DurationGame"" class=""control-label""></label>
                <input asp-for=""DurationGame"" class=""form-control"" />
                <span asp-validation-for=""DurationGame"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 47 "C:\Users\oramr\Documents\GitHub\CheckersGame\Server\Views\TblGames\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Server.Model.TblGames> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
