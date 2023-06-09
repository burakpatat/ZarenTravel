#pragma checksum "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb9e570930143fb3e32abe8c2e339781610d585b"
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
    public partial class CustomSelect<TableItem> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
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
#line 6 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
                                                         Condition

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 6 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
                                                                                 (x) => Condition = (CustomSelectCondition)Enum.Parse(typeof(CustomSelectCondition), x.Value.ToString())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(5, "\n");
#nullable restore
#line 7 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
         foreach (CustomSelectCondition option in Enum.GetValues(typeof(CustomSelectCondition)))
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, "            ");
            __builder.OpenElement(7, "option");
            __builder.AddAttribute(8, "value", 
#nullable restore
#line 9 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
                            option

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 9 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
__builder.AddContent(9, option.GetDescription());

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\n");
#nullable restore
#line 10 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\n");
#nullable restore
#line 13 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
     if (Condition != CustomSelectCondition.IsNull && Condition != CustomSelectCondition.IsNotNull)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(13, "        ");
            __builder.OpenElement(14, "select");
            __builder.AddAttribute(15, "class", "form-control form-control-sm");
            __builder.AddAttribute(16, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 15 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
                                                                  (x) => FilterValue = x.Value

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(17, "\n");
#nullable restore
#line 16 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
             foreach (var option in Items)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(18, "                ");
            __builder.OpenElement(19, "option");
            __builder.AddAttribute(20, "value", 
#nullable restore
#line 18 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
                                option.Value

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(21, "selected", 
#nullable restore
#line 18 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
                                                          option.Value.Equals(FilterValue)

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 18 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
__builder.AddContent(22, option.Key);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\n");
#nullable restore
#line 19 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(24, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\n");
#nullable restore
#line 21 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
     
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(26, "\n");
            __Blazor.BlazorTable.CustomSelect.TypeInference.CreateCascadingValue_0(__builder, 27, 28, 
#nullable restore
#line 24 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
                       (ICustomSelect)this

#line default
#line hidden
#nullable disable
            , 29, "CustomSelect", 30, (__builder2) => {
                __builder2.AddMarkupContent(31, "\n    ");
#nullable restore
#line 25 "C:\WordyWellHero\WordyWellHero\src\BlazorTable\Filters\CustomSelect.razor"
__builder2.AddContent(32, ChildContent);

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(33, "\n");
            }
            );
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.BlazorTable.CustomSelect
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateCascadingValue_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::System.String __arg1, int __seq2, global::Microsoft.AspNetCore.Components.RenderFragment __arg2)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.CascadingValue<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "Name", __arg1);
        __builder.AddAttribute(__seq2, "ChildContent", __arg2);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
