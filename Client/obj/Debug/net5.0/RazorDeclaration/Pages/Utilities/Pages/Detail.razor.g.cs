// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace WordyWellHero.Client.Pages.Utilities.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 2 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Blazored.FluentValidation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Identity.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Identity.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Identity.Roles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Identity.RoleClaims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Identity.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Preferences;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Interceptors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Dashboard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Communication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Audit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Misc.Document;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Misc.DocumentType;

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Shared.Constants.Permission;

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Shared.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Shared.Dialogs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Settings;

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Application.Requests.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Pages.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\WordyWellHero\WordyWellHero\src\Client\Pages\Utilities\Pages\Detail.razor"
using BlazorTable;

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Detail")]
    public partial class Detail : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 66 "C:\WordyWellHero\WordyWellHero\src\Client\Pages\Utilities\Pages\Detail.razor"
 
    [Inject]
    private HttpClient Http { get; set; }

    private ITable<PersonData> table;

    private PersonData[] data;

    private int rowNumber;

    private string errorMessage = "";

    protected override async Task OnInitializedAsync()
    {
        data = await Http.GetFromJsonAsync<PersonData[]>("sample-data/MOCK_DATA.json");
    }

    public class PersonData
    {
        public int? id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public bool? paid { get; set; }
        public decimal? price { get; set; }
        public CreditCard? cc_type { get; set; }
        public DateTime? created_date { get; set; }
    }

    public enum CreditCard
    {
        none = 0,
        [Description("MasterCard")]
        MasterCard = 1,
        Visa = 2
    }

    private void Try(Action action)
    {
        try
        {
            errorMessage = "";
            action();
        }
        catch (Exception e)
        {
            errorMessage = e.Message;
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime _jsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService _localStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUserManager _userManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ClientPreferenceManager _clientPreferenceManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpInterceptorManager _interceptor { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _httpClient { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDialogService _dialogService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISnackbar _snackBar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthorizationService _authorizationService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BlazorHeroStateProvider _stateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountManager _accountManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationManager _authenticationManager { get; set; }
    }
}
#pragma warning restore 1591
