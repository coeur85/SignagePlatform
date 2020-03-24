#pragma checksum "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/Components/SliderComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de3549be9a2764b19964b1b1fde5ec8dda706f38"
// <auto-generated/>
#pragma warning disable 1591
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
#line 1 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/Components/SliderComponent.razor"
using ScreenWebApp.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/SliderComponent")]
    public partial class SliderComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "carousel slide  carousel-fade");
            __builder.AddAttribute(2, "data-ride", "carousel");
            __builder.AddAttribute(3, "data-pause", "false");
            __builder.AddAttribute(4, "id", "slide_" + (
#nullable restore
#line 7 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/Components/SliderComponent.razor"
                                                                                               id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(5, "\n    ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "carousel-inner");
            __builder.AddMarkupContent(8, " \n\n       \n");
#nullable restore
#line 11 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/Components/SliderComponent.razor"
         for (int i = 0; i < Pictures.Count; i++)
        {
            
            string active = ( i == ActiveSlide) ? "active":  "";
            

#line default
#line hidden
#nullable disable
            __builder.AddContent(9, "                ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "carousel-item" + " " + (
#nullable restore
#line 16 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/Components/SliderComponent.razor"
                                           active

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(12, "\n                  \n                        ");
            __builder.OpenElement(13, "img");
            __builder.AddAttribute(14, "src", 
#nullable restore
#line 18 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/Components/SliderComponent.razor"
                                   Pictures[i].Base64

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(15, "class", "img-thumbnail bgomlaAddImg1080");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "    \n");
#nullable restore
#line 20 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/Components/SliderComponent.razor"
            
        }     

#line default
#line hidden
#nullable disable
            __builder.AddContent(18, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "            \n                             \n ");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "/Users/magdi/Documents/repo/SignagePlatformApp/ScreenWebApp/Components/SliderComponent.razor"
       
     
    [Parameter]
    public List<PictureModel> Pictures {get;set;}  
    [Parameter]
    public int ActiveSlide {get;set;}

    private int id{get; set;}
    
    

    protected override void OnParametersSet()
    {
        id = ActiveSlide;
        if(ActiveSlide > (Pictures.Count-1) ){
            ActiveSlide = (ActiveSlide - Pictures.Count);
        }
    }
  
 

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
