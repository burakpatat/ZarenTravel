#pragma checksum "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\BooleanFilter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d2fb4ad7ff704059ffb6dd42a0f30ebe7c8dda5"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorTable
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 2 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
    public partial class BooleanFilter<TableItem> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\BooleanFilter.razor"
 if (Column.FilterControl == this)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.OpenElement(1, "select");
            __builder.AddAttribute(2, "class", "form-control form-control-sm");
            __builder.AddAttribute(3, "value", 
#nullable restore
#line 6 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\BooleanFilter.razor"
                                                         Condition

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 6 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\BooleanFilter.razor"
                                                                                 (x) => Condition = (BooleanCondition)Enum.Parse(typeof(BooleanCondition), x.Value.ToString())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(5, "\n");
#nullable restore
#line 7 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\BooleanFilter.razor"
         foreach (var option in (BooleanCondition[])Enum.GetValues(typeof(BooleanCondition)))
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, "            ");
            __builder.OpenElement(7, "option");
            __builder.AddAttribute(8, "value", 
#nullable restore
#line 9 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\BooleanFilter.razor"
                            option

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 9 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\BooleanFilter.razor"
__builder.AddContent(9, option.GetDescription());

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\n");
#nullable restore
#line 10 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\BooleanFilter.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\n");
#nullable restore
#line 12 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\BooleanFilter.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
