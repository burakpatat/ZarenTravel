// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace WordyWellHero.Client.Pages.Identity
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
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using Blazored.FluentValidation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Identity.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Identity.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Identity.Roles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Identity.RoleClaims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Identity.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Preferences;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Interceptors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Dashboard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Communication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Audit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Misc.Document;

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Managers.Misc.DocumentType;

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Shared.Constants.Permission;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Shared.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Shared.Dialogs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Settings;

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Application.Requests.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Pages.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Infrastructure.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
using WordyWellHero.Client.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\WordyWellHero\WordyWellHero\src\Client\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    public partial class Security : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<Security> _localizer { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime _jsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService _localStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUserManager _userManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private DatabaseHelper dbHelper { get; set; }
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
