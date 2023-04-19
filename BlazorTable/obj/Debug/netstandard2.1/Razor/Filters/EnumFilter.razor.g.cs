#pragma checksum "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34de5c86c30be78dcb95a2d4d031ae164e60d045"
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
    public partial class EnumFilter<TableItem> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
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
#line 6 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
                                                         Condition

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 6 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
                                                                                 (x) => Condition = (EnumCondition)Enum.Parse(typeof(EnumCondition), x.Value.ToString())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(5, "\n");
#nullable restore
#line 7 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
         foreach (EnumCondition option in Enum.GetValues(typeof(EnumCondition)))
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, "            ");
            __builder.OpenElement(7, "option");
            __builder.AddAttribute(8, "value", 
#nullable restore
#line 9 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
                            option

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 9 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
__builder.AddContent(9, option.GetDescription());

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\n");
#nullable restore
#line 10 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\n");
#nullable restore
#line 13 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
     if (Condition != EnumCondition.IsNull && Condition != EnumCondition.IsNotNull)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(13, "        ");
            __builder.OpenElement(14, "select");
            __builder.AddAttribute(15, "class", "form-control form-control-sm");
            __builder.AddAttribute(16, "value", 
#nullable restore
#line 15 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
                                                             FilterValue

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(17, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 15 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
                                                                                       (x) => FilterValue = Enum.Parse(Column.Type.GetNonNullableType(), x.Value.ToString())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(18, "\n");
#nullable restore
#line 16 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
             foreach (var option in Enum.GetValues(Column.Type.GetNonNullableType()))
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(19, "                ");
            __builder.OpenElement(20, "option");
            __builder.AddAttribute(21, "value", 
#nullable restore
#line 18 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
                                option

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 18 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
__builder.AddContent(22, (option as Enum).GetDescription() ?? option);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\n");
#nullable restore
#line 19 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(24, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\n");
#nullable restore
#line 21 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\EnumFilter.razor"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591