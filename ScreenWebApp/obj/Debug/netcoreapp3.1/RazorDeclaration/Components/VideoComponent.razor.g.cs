#pragma checksum "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/Components/VideoComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17c5b070f821aad1a9ee7e40be13722143aa8340"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace ScreenWebApp.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/_Imports.razor"
using ScreenWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/_Imports.razor"
using ScreenWebApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/Components/VideoComponent.razor"
using ScreenWebApp.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/VideoComponent")]
    public partial class VideoComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 17 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/Components/VideoComponent.razor"
        
    [Parameter]
    public VideoModel Video {get;set;}

    
    private object appInstance {get;set;}
    
    

    protected override  void OnInitialized()
        {
             appInstance = DotNetObjectReference.Create(this);
            
        }
        
        
       
    
  

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ScreenWebApp.Interfaces.iVideo iVid { get; set; }
    }
}
#pragma warning restore 1591
